using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextPreprocessing.Processors
{
    public class EnglishRemovePunctuationProcessor : IRemovePunctuationProcessor
    {
        private readonly string PunctuationRegexPattern = "[^\\w\\s']";

        public EnglishRemovePunctuationProcessor()
        {
        }

        public List<string> RemovePunctuation(List<string> textsToRemovePunctuation)
        {
            if (textsToRemovePunctuation.Count == 0)
            {
                throw new ArgumentException("Empty list (count = 0) passed to RemovePunctuation.");
            }
            List<string> list = new List<string>();
            foreach (string str in textsToRemovePunctuation)
            {

                list.Add(Regex.Replace(str, this.PunctuationRegexPattern, ""));
                
            }
            return list;
        }
    }
}