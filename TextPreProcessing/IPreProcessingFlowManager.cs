using System;

namespace TextPreprocessing.Processors
{
    public interface IPreProcessingFlowManager
    {
        string PreProcessByLanguage(string toPreProcess, PreProcessingLanguage language);

        string PreProcessText(IPreparationStepProcessor preparationStepProcessor, IRemovePunctuationProcessor removePunctuationProcessor, IStopWordProcessor stopWordProcessor, IExpandContractionProcessor expandContractionProcessor, IStemmingProcessor stemmingProcessor, string toPreProcess);
    }
}