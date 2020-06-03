using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextPreprocessing.Processors
{
    public class EnglishExpandContractionProcessor : IExpandContractionProcessor
    {
        public EnglishExpandContractionProcessor()
        {
        }

        private string CheckRuleForD(string wordToExpand)
        {
            string str;
            
            string str1 = wordToExpand;
            switch (str1)
            {
                case "he'd":
                    {
                        str = "he had";
                        break;
                    }
                case "how'd":
                    {
                        str = "how did";
                        break;
                    }
                case "i'd":
                    {
                        str = "i would";
                        break;
                    }
                case "it'd":
                    {
                        str = "it would";
                        break;
                    }
                case "she'd":
                    {
                        str = "she had";
                        break;
                    }
                case "that'd":
                    {
                        str = "that would";
                        break;
                    }
                case "there'd":
                    {
                        str = "there would";
                        break;
                    }
                case "they'd":
                    {
                        str = "they had";
                        break;
                    }
                case "we'd":
                    {
                        str = "we had";
                        break;
                    }
                case "what'd":
                    {
                        str = "what did";
                        break;
                    }
                case "where'd":
                    {
                        str = "where did";
                        break;
                    }
                case "who'd":
                    {
                        str = "who had";
                        break;
                    }
                case "why'd":
                    {
                        str = "why did";
                        break;
                    }
                default:
                    {
                        str = (str1 == "you'd" ? "you had" : wordToExpand);
                        break;
                    }
            }
            
            return str;
        }

        private string CheckRuleForDve(string wordToExpand)
        {
            string str = (!Regex.IsMatch(wordToExpand, "'d've$") ? wordToExpand : Regex.Replace(wordToExpand, "'d've$", " would have"));
            return str;
        }

        private string CheckRuleForEer(string wordToExpand)
        {
            string str = (!Regex.IsMatch(wordToExpand, "e'er$") ? wordToExpand : Regex.Replace(wordToExpand, "e'er$", "ever"));
            return str;
        }

        private string CheckRuleForLl(string wordToExpand)
        {
            string str = (!Regex.IsMatch(wordToExpand, "'ll$") ? wordToExpand : Regex.Replace(wordToExpand, "'ll$", " will"));
            return str;
        }

        private string CheckRuleForMisc(string wordToExpand)
        {
            string str;

            string str1 = wordToExpand;
            switch (str1)
            {
                case "finna":
                    {
                        str = "fixing to";
                        break;
                    }
                case "gimme":
                    {
                        str = "give me";
                        break;
                    }
                case "gonna":
                    {
                        str = "going to";
                        break;
                    }
                case "gotta":
                    {
                        str = "got to";
                        break;
                    }
                case "i'm'a":
                    {
                        str = "i am about to";
                        break;
                    }
                case "i'm'o":
                    {
                        str = "i am going to";
                        break;
                    }
                case "i'm":
                    {
                        str = "i am";
                        break;
                    }
                case "ma'am":
                    {
                        str = "madam";
                        break;
                    }
                case "o'clock":
                    {
                        str = "oclock";
                        break;
                    }
                case "o'er":
                    {
                        str = "over";
                        break;
                    }
                case "ol'":
                    {
                        str = "old";
                        break;
                    }
                case "'tis":
                    {
                        str = "it is";
                        break;
                    }
                case "'twas":
                    {
                        str = "it was";
                        break;
                    }
                case "y'all":
                    {
                        str = "you all";
                        break;
                    }
                default:
                    {
                        str = (str1 == "dog" ? "dog" : wordToExpand);
                        break;
                    }
            }
            return str;
        }

        private string CheckRuleForNt(string wordToExpand)
        {
            string str;

            string str1 = wordToExpand;
            if (str1 == "ain't")
            {
                str = "is not";
            }
            else if (str1 == "daresn't" || str1 == "dasn't")
            {
                str = "dare not";
            }
            else if (str1 == "shan't")
            {
                str = "shall not";
            }
            else if (str1 == "won't")
            {
                str = "will not";
            }
            else if (str1 == "can't")
            {
                str = "cannot";
            }
            else
            {
                str = (!Regex.IsMatch(wordToExpand, "n't$") ? wordToExpand : Regex.Replace(wordToExpand, "n't$", " not"));
            }

            return str;
        }

        private string CheckRuleForRe(string wordToExpand)
        {
            string str = (!Regex.IsMatch(wordToExpand, "'re$") ? wordToExpand : Regex.Replace(wordToExpand, "'re$", " are"));
            return str;
        }

        private string CheckRuleForS(string wordToExpand)
        {
            string str;
 
            string str1 = wordToExpand;
            switch (str1)
            {
                case "everyone's":
                    {
                        str = "everyone is";
                        break;
                    }
                case "he's":
                    {
                        str = "he is";
                        break;
                    }
                case "how's":
                    {
                        str = "how is";
                        break;
                    }
                case "it's":
                    {
                        str = "it is";
                        break;
                    }
                case "let's":
                    {
                        str = "let us";
                        break;
                    }
                case "she's":
                    {
                        str = "she is";
                        break;
                    }
                case "somebody's":
                    {
                        str = "somebody is";
                        break;
                    }
                case "someone's":
                    {
                        str = "someone is";
                        break;
                    }
                case "something's":
                    {
                        str = "something is";
                        break;
                    }
                case "that's":
                    {
                        str = "that is";
                        break;
                    }
                case "there's":
                    {
                        str = "there is";
                        break;
                    }
                case "this's":
                    {
                        str = "this is";
                        break;
                    }
                case "what's":
                    {
                        str = "what is";
                        break;
                    }
                case "when's":
                    {
                        str = "when is";
                        break;
                    }
                case "where's":
                    {
                        str = "where is";
                        break;
                    }
                case "which's":
                    {
                        str = "which is";
                        break;
                    }
                case "who's":
                    {
                        str = "who is";
                        break;
                    }
                case "why's":
                    {
                        str = "why is";
                        break;
                    }
                default:
                    {
                        str = (!Regex.IsMatch(wordToExpand, "'s$") ? wordToExpand : Regex.Replace(wordToExpand, "'s$", "s"));
                        break;
                    }
            }

            return str;
        }

        private string CheckRuleForVe(string wordToExpand)
        {
            string str = (!Regex.IsMatch(wordToExpand, "'ve$") ? wordToExpand : Regex.Replace(wordToExpand, "'ve$", " have"));

            return str;
        }

        public List<string> ExpandContractions(List<string> textsToExpand)
        {
            if (textsToExpand.Count == 0)
            {
                throw new ArgumentException("Empty list (count = 0) passed to ExpandContractions.");
            }
            List<string> list = new List<string>();
            foreach (string str in textsToExpand)
            {

                string str1 = this.CheckRuleForNt(str);
                if (str1 == str)
                {
                    string str2 = this.CheckRuleForDve(str);
                    if (str2 == str)
                    {
                        string str3 = this.CheckRuleForVe(str);
                        if (str3 == str)
                        {
                            string str4 = this.CheckRuleForD(str);
                            if (str4 == str)
                            {
                                string str5 = this.CheckRuleForS(str);
                                if (str5 == str)
                                {
                                    string str6 = this.CheckRuleForLl(str);
                                    if (str6 == str)
                                    {
                                        string str7 = this.CheckRuleForRe(str);
                                        if (str7 == str)
                                        {
                                            string str8 = this.CheckRuleForEer(str);
                                            if (str8 == str)
                                            {
                                                string str9 = this.CheckRuleForMisc(str);
                                                if (str9 != str)
                                                {
                                                    list.Add(str9);
                                                    continue;
                                                }
                                            }
                                            else
                                            {
                                                list.Add(str8);
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            list.Add(str7);
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        list.Add(str6);
                                        continue;
                                    }
                                }
                                else
                                {
                                    list.Add(str5);
                                    continue;
                                }
                            }
                            else
                            {
                                list.Add(str4);
                                continue;
                            }
                        }
                        else
                        {
                            list.Add(str3);
                            continue;
                        }
                    }
                    else
                    {
                        list.Add(str2);
                        continue;
                    }
                }
                else
                {
                    list.Add(str1);
                    continue;
                }

                str.Replace("'", string.Empty);
                list.Add(str);
            }
            return list;
        }
    }
}