using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextPreprocessing.Processors
{
    public class EnglishStemmingProcessor : IStemmingProcessor
    {
        private Dictionary<string, string> StepOneASuffixes;

        private Dictionary<string, string> StepOneBSecondarySuffixes;

        private Dictionary<string, string> StepTwoSuffixes;

        private Dictionary<string, string> StepThreeSuffixes;

        private Dictionary<string, string> StepFourSuffixesSetOne;

        private Dictionary<string, string> StepFourSuffixesSetTwo;

        public EnglishStemmingProcessor()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("sses", "ss");
            dictionary.Add("ies", "i");
            dictionary.Add("ss", "ss");
            dictionary.Add("s", "");
            this.StepOneASuffixes = dictionary;
            Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
            dictionary1.Add("at", "ate");
            dictionary1.Add("bl", "ble");
            dictionary1.Add("iz", "ize");
            this.StepOneBSecondarySuffixes = dictionary1;
            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
            dictionary2.Add("ational", "ate");
            dictionary2.Add("tional", "tion");
            dictionary2.Add("enci", "ence");
            dictionary2.Add("anci", "ance");
            dictionary2.Add("izer", "ize");
            dictionary2.Add("abli", "able");
            dictionary2.Add("alli", "al");
            dictionary2.Add("entli", "ent");
            dictionary2.Add("eli", "e");
            dictionary2.Add("ousli", "ous");
            dictionary2.Add("ization", "ize");
            dictionary2.Add("ation", "ate");
            dictionary2.Add("ator", "ate");
            dictionary2.Add("alism", "al");
            dictionary2.Add("iveness", "ive");
            dictionary2.Add("fulness", "ful");
            dictionary2.Add("ousness", "ous");
            dictionary2.Add("aliti", "al");
            dictionary2.Add("iviti", "ive");
            dictionary2.Add("biliti", "ble");
            this.StepTwoSuffixes = dictionary2;
            Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
            dictionary3.Add("icate", "ic");
            dictionary3.Add("ative", "");
            dictionary3.Add("alize", "al");
            dictionary3.Add("iciti", "ic");
            dictionary3.Add("ical", "ic");
            dictionary3.Add("ful", "");
            dictionary3.Add("ness", "");
            this.StepThreeSuffixes = dictionary3;
            Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
            dictionary4.Add("al", "");
            dictionary4.Add("ance", "");
            dictionary4.Add("ence", "");
            dictionary4.Add("er", "");
            dictionary4.Add("ic", "");
            dictionary4.Add("able", "");
            dictionary4.Add("ible", "");
            dictionary4.Add("ant", "");
            dictionary4.Add("ement", "");
            dictionary4.Add("ment", "");
            dictionary4.Add("ent", "");
            this.StepFourSuffixesSetOne = dictionary4;
            Dictionary<string, string> dictionary5 = new Dictionary<string, string>();
            dictionary5.Add("ou", "");
            dictionary5.Add("ism", "");
            dictionary5.Add("ate", "");
            dictionary5.Add("iti", "");
            dictionary5.Add("ous", "");
            dictionary5.Add("ive", "");
            dictionary5.Add("ize", "");
            this.StepFourSuffixesSetTwo = dictionary5;
        }

        private int GetMeasureOfWord(string wordToMeasure)
        {
            int count = Regex.Matches(wordToMeasure, "([aeiou]+[^aeiou]+)").Count + Regex.Matches(wordToMeasure, "([^aeiou]y+[^aeiou]+)").Count;
            return count;
        }

        private string MeasureAndReplaceSuffixes(string wordToStem, Dictionary<string, string> suffixes, int measureValue)
        {
            string str;
            string str1 = wordToStem;
            foreach (KeyValuePair<string, string> suffix in suffixes)
            {
                if (suffix.Key.Length <= wordToStem.Length)
                {
                    if (Regex.IsMatch(str1, string.Concat(suffix.Key, "$")))
                    {
                        string str2 = Regex.Replace(str1, string.Concat(suffix.Key, "$"), "");
                        if (this.GetMeasureOfWord(str2) <= measureValue)
                        {
                            str = wordToStem;
                            return str;
                        }
                        else
                        {
                            str1 = string.Concat(str2, suffix.Value);
                            str = str1;
                            return str;
                        }
                    }
                }
            }
            str = str1;
            return str;
        }

        public List<string> StemWords(List<string> wordsToStem)
        {
            if (wordsToStem.Count == 0)
            {
                throw new ArgumentException("Empty list (count = 0) passed to StemWords.");
            }
            List<string> list = new List<string>();
            foreach (string str in wordsToStem)
            {
                string str1 = this.MeasureAndReplaceSuffixes(str, this.StepOneASuffixes, -1);
                string str2 = this.StepOneC(this.StepOneB(str1));
                string str3 = this.MeasureAndReplaceSuffixes(str2, this.StepTwoSuffixes, 0);
                string str4 = this.MeasureAndReplaceSuffixes(str3, this.StepThreeSuffixes, 0);
                string str5 = this.StepFour(str4);
                list.Add(this.StepFiveB(this.StepFiveA(str5)));
            }
            return list;
        }

        private string StepFiveA(string wordToStem)
        {
            string str;
            string str1 = wordToStem;
            if (!Regex.IsMatch(str1, "e$"))
            {
                str = wordToStem;
            }
            else
            {
                string str2 = Regex.Replace(str1, "e$", "");
                int measureOfWord = this.GetMeasureOfWord(str2);
                bool flag = Regex.IsMatch(str2, "[^aeiou][aeiouy][^aeiouwxy]$");
                if (measureOfWord <= 1)
                {
                    str = ((measureOfWord != 1 ? true : flag) ? str1 : str2);
                }
                else
                {
                    str = str2;
                }
            }
            return str;
        }

        private string StepFiveB(string wordToStem)
        {
            string str;
            string str1 = wordToStem;
            if ((this.GetMeasureOfWord(str1) <= 1 ? true : !Regex.IsMatch(str1, "ll$")))
            {
                str = str1;
            }
            else
            {
                str1 = Regex.Replace(str1, "l$", "");
                str = str1;
            }
            return str;
        }

        private string StepFour(string wordToStem)
        {
            string str;
            string str1 = wordToStem;
            string str2 = this.MeasureAndReplaceSuffixes(str1, this.StepFourSuffixesSetOne, 1);
            if (str2 == str1)
            {
                if (Regex.IsMatch(str1, "[st]ion$"))
                {
                    string str3 = Regex.Replace(str1, "ion$", "");
                    if (this.GetMeasureOfWord(str3) > 1)
                    {
                        str = str3;
                        return str;
                    }
                }
                string str4 = this.MeasureAndReplaceSuffixes(str1, this.StepFourSuffixesSetTwo, 1);
                str = (str4 == str1 ? str1 : str4);
            }
            else
            {
                str = str2;
            }
            return str;
        }

        private string StepOneB(string wordToStem)
        {
            string str;
            string str1 = wordToStem;
            if (str1.Length < 3)
            {
                str = str1;
                return str;
            }
            else if (!Regex.IsMatch(str1, "eed$"))
            {
                if (Regex.IsMatch(str1, "ed$"))
                {
                    string str2 = Regex.Replace(str1, "ed$", "");
                    if (this.VowelRemainsInStem(str2))
                    {
                        str1 = this.StepOneBSecondary(str2);
                        str = str1;
                        return str;
                    }
                }
                if (Regex.IsMatch(str1, "ing$"))
                {
                    string str3 = Regex.Replace(str1, "ing$", "");
                    if (this.VowelRemainsInStem(str3))
                    {
                        str1 = this.StepOneBSecondary(str3);
                        str = str1;
                        return str;
                    }
                }
                str = str1;
                return str;
            }
            else
            {
                string str4 = Regex.Replace(str1, "eed$", "ee");
                str = (this.GetMeasureOfWord(str4) <= 0 ? str1 : str4);
            }
            return str;
        }

        private string StepOneBSecondary(string wordToStem)
        {
            string str;
            string str1 = wordToStem;
            string str2 = this.MeasureAndReplaceSuffixes(wordToStem, this.StepOneBSecondarySuffixes, -1);
            if (str2 == str1)
            {
                if (str1.Length >= 2)
                {
                    char[] charArray = wordToStem.ToCharArray();
                    if ((charArray[Enumerable.Count<char>(charArray) - 1] != charArray[Enumerable.Count<char>(charArray) - 2] || !Regex.IsMatch(str1, "[^aeiou]{2}$") ? false : Regex.IsMatch(str1, "[^lsz]$")))
                    {
                        str1 = Regex.Replace(str1, "\\w$", "");
                        str = str1;
                        return str;
                    }
                }
                if ((this.GetMeasureOfWord(str1) != 1 ? true : !Regex.IsMatch(str1, "[^aeiou][aeiouy][^aeiouwxy]$")))
                {
                    str = str1;
                }
                else
                {
                    str1 = string.Concat(str1, "e");
                    str = str1;
                }
            }
            else
            {
                str = str2;
            }
            return str;
        }

        private string StepOneC(string wordToStem)
        {
            string str;
            string str1 = wordToStem;
            if (Regex.IsMatch(str1, "y$"))
            {
                string str2 = Regex.Replace(str1, "y$", "");
                if (this.VowelRemainsInStem(str2))
                {
                    str1 = string.Concat(str2, "i");
                    str = str1;
                    return str;
                }
            }
            str = str1;
            return str;
        }

        private bool VowelRemainsInStem(string stemToCheck)
        {
            return ((Regex.IsMatch(stemToCheck, "[aeiou]") ? false : !Regex.IsMatch(stemToCheck, "[^aeiou]y")) ? false : true);
        }
    }
}