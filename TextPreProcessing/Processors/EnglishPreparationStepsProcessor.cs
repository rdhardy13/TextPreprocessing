using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextPreprocessing.Processors
{
    public class EnglishPreparationStepsProcessor : IPreparationStepProcessor
    {
        public EnglishPreparationStepsProcessor()
        {
        }

        public List<string> PrepareString(string toPrepare)
        {
            if (string.IsNullOrEmpty(toPrepare))
            {
                throw new ArgumentException("Null or empty string passed to PrepareString.");
            }
            string lower = toPrepare.ToLower();

            foreach (Match match in Regex.Matches(lower, "\\w-\\w"))
            {
                string str = Regex.Replace(match.Value, "-", "_");
                lower = Regex.Replace(lower, match.Value, str);
            }

            return Enumerable.ToList<string>(lower.Split(new char[] { ' ', '\t', '\n', '.', '?', '!', ':', ';', ',' }));
        }
    }
}