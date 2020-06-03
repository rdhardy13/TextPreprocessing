using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextPreprocessing.Processors
{
    public static class EnglishFluentProcessing
    {
        //--------------------------------------------------------------------------//

        public static List<string> PreparationSteps(this string textToPrepare, IPreparationStepProcessor processor)
        {
            return processor.PrepareString(textToPrepare);
        }

        //--------------------------------------------------------------------------//

        public static List<string> RemoveStopWords(this List<string> textsToRemoveStopWords, IStopWordProcessor processor)
        {
            return processor.RemoveStopWords(textsToRemoveStopWords);
        }

        //--------------------------------------------------------------------------//

        public static List<string> RemovePunctuation(this List<string> textsToRemovePunctuation, IRemovePunctuationProcessor processor)
        {
            return processor.RemovePunctuation(textsToRemovePunctuation);
        }

        //--------------------------------------------------------------------------//

        public static List<string> ClearEmptyStringsFromList(this List<string> textsToClear)
        {
            List<string> list = new List<string>();
            foreach (string str in textsToClear)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    list.Add(str);
                }
            }
            return list;
        }

        //--------------------------------------------------------------------------//

        public static List<string> ReTokenizeList(this List<string> textsToReTokenize)
        {
            string str = "";
            foreach (string text in textsToReTokenize)
            {
                str = string.Concat(str, text.Trim(), " ");
            }

            return str.Split(new char[] { ' ' }).ToList();
        }

        //--------------------------------------------------------------------------//

        public static List<string> ExpandContractions(this List<string> textsToExpand, IExpandContractionProcessor processor)
        {
            return processor.ExpandContractions(textsToExpand);
        }

        //--------------------------------------------------------------------------//

        public static List<string> StemWords(this List<string> textsToStem, IStemmingProcessor processor)
        {
            return processor.StemWords(textsToStem);
        }

        //--------------------------------------------------------------------------//

        public static string ReconstituteString(this List<string> tokensToReconstitute)
        {
            string str = "";
            foreach (string token in tokensToReconstitute)
            {
                str = string.Concat(str, token.Trim(), " ");
            }

            return str.Trim();
        }
    }
}
