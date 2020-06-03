using System;
using System.Collections.Generic;
using System.Linq;

namespace TextPreprocessing.Processors
{
    public class PreProcessingFlowManager : IPreProcessingFlowManager
    {
        public string PreProcessByLanguage(string textToPreProcess, PreProcessingLanguage language)
        {
            if (string.IsNullOrEmpty(textToPreProcess))
            {
                throw new ArgumentException("TextToPreProcess cannot be null or empty.");
            }

            return language switch
            {
                PreProcessingLanguage.English => PreProcessText(new EnglishPreparationStepsProcessor(),
                                                                new EnglishRemovePunctuationProcessor(),
                                                                new EnglishStopWordProcessor(),
                                                                new EnglishExpandContractionProcessor(),
                                                                new EnglishStemmingProcessor(),
                                                                textToPreProcess),
                _ => throw new NotImplementedException("Language not supported.")
            };
        }

        //--------------------------------------------------------------------------//

        public string PreProcessText(IPreparationStepProcessor preparationStepProcessor, IRemovePunctuationProcessor removePunctuationProcessor, IStopWordProcessor stopWordProcessor, IExpandContractionProcessor expandContractionProcessor, IStemmingProcessor stemmingProcessor, string toPreProcess)
        {
            if (preparationStepProcessor == null) throw new ArgumentException("preparationStepProcessor cannot be null");
            if (removePunctuationProcessor == null) throw new ArgumentException("removePunctuationProcessor cannot be null");
            if (stopWordProcessor == null) throw new ArgumentException("stopWordProcessor cannot be null");
            if (stemmingProcessor == null) throw new ArgumentException("stemmingProcessor cannot be null");
            if (string.IsNullOrEmpty(toPreProcess)) throw new ArgumentException("toPreProcess cannot be null or empty");

            // The order of these steps were reconstituted from code decompiled from an assembly (I "lost" the original soure code).
            // This needs to be fully reviewed to ensure the repeated steps are actually necessary.
            return toPreProcess
                .PreparationSteps(preparationStepProcessor)
                .ClearEmptyStringsFromList()
                .RemoveStopWords(stopWordProcessor)
                .RemovePunctuation(removePunctuationProcessor)
                .ReTokenizeList()
                .ClearEmptyStringsFromList()
                .ExpandContractions(expandContractionProcessor)
                .ReTokenizeList()
                .ClearEmptyStringsFromList()
                .StemWords(stemmingProcessor)
                .ClearEmptyStringsFromList()
                .ReconstituteString();
        }
    }
}