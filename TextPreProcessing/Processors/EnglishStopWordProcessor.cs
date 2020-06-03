using System;
using System.Collections.Generic;

namespace TextPreprocessing.Processors
{
    public class EnglishStopWordProcessor : IStopWordProcessor
    {
        private readonly List<string> StopWords;

        public EnglishStopWordProcessor()
        {
            List<string> list = new List<string>();
            list.Add("a");
            list.Add("about");
            list.Add("above");
            list.Add("after");
            list.Add("again");
            list.Add("against");
            list.Add("all");
            list.Add("am");
            list.Add("an");
            list.Add("and");
            list.Add("any");
            list.Add("are");
            list.Add("aren't");
            list.Add("as");
            list.Add("at");
            list.Add("be");
            list.Add("because");
            list.Add("been");
            list.Add("before");
            list.Add("being");
            list.Add("below");
            list.Add("between");
            list.Add("both");
            list.Add("but");
            list.Add("by");
            list.Add("can't");
            list.Add("cannot");
            list.Add("could");
            list.Add("couldn't");
            list.Add("did");
            list.Add("didn't");
            list.Add("do");
            list.Add("does");
            list.Add("doesn't");
            list.Add("doing");
            list.Add("don't");
            list.Add("down");
            list.Add("during");
            list.Add("each");
            list.Add("few");
            list.Add("for");
            list.Add("from");
            list.Add("further");
            list.Add("had");
            list.Add("hadn't");
            list.Add("has");
            list.Add("hasn't");
            list.Add("have");
            list.Add("haven't");
            list.Add("having");
            list.Add("he");
            list.Add("he'd");
            list.Add("he'll");
            list.Add("he's");
            list.Add("her");
            list.Add("here");
            list.Add("here's");
            list.Add("hers");
            list.Add("herself");
            list.Add("him");
            list.Add("himself");
            list.Add("his");
            list.Add("how");
            list.Add("how's");
            list.Add("i");
            list.Add("i'd");
            list.Add("i'll");
            list.Add("i'm");
            list.Add("i've");
            list.Add("if");
            list.Add("in");
            list.Add("into");
            list.Add("is");
            list.Add("isn't");
            list.Add("it");
            list.Add("it's");
            list.Add("its");
            list.Add("itself");
            list.Add("let's");
            list.Add("me");
            list.Add("more");
            list.Add("most");
            list.Add("mustn't");
            list.Add("my");
            list.Add("myself");
            list.Add("no");
            list.Add("nor");
            list.Add("not");
            list.Add("of");
            list.Add("off");
            list.Add("on");
            list.Add("once");
            list.Add("only");
            list.Add("or");
            list.Add("other");
            list.Add("ought");
            list.Add("our");
            list.Add("ours");
            list.Add("ourselves");
            list.Add("out");
            list.Add("over");
            list.Add("own");
            list.Add("same");
            list.Add("shan't");
            list.Add("she");
            list.Add("she'd");
            list.Add("she'll");
            list.Add("she's");
            list.Add("should");
            list.Add("shouldn't");
            list.Add("so");
            list.Add("some");
            list.Add("such");
            list.Add("than");
            list.Add("that");
            list.Add("that's");
            list.Add("the");
            list.Add("their");
            list.Add("theirs");
            list.Add("them");
            list.Add("themselves");
            list.Add("then");
            list.Add("there");
            list.Add("there's");
            list.Add("these");
            list.Add("they");
            list.Add("they'd");
            list.Add("they'll");
            list.Add("they're");
            list.Add("they've");
            list.Add("this");
            list.Add("those");
            list.Add("through");
            list.Add("to");
            list.Add("too");
            list.Add("under");
            list.Add("until");
            list.Add("up");
            list.Add("very");
            list.Add("was");
            list.Add("wasn't");
            list.Add("we");
            list.Add("we'd");
            list.Add("we'll");
            list.Add("we're");
            list.Add("we've");
            list.Add("were");
            list.Add("weren't");
            list.Add("what");
            list.Add("what's");
            list.Add("when");
            list.Add("when's");
            list.Add("where");
            list.Add("where's");
            list.Add("which");
            list.Add("while");
            list.Add("who");
            list.Add("who's");
            list.Add("whom");
            list.Add("why");
            list.Add("why's");
            list.Add("with");
            list.Add("won't");
            list.Add("would");
            list.Add("wouldn't");
            list.Add("you");
            list.Add("you'd");
            list.Add("you'll");
            list.Add("you're");
            list.Add("you've");
            list.Add("your");
            list.Add("yours");
            list.Add("yourself");
            list.Add("yourselves");
            this.StopWords = list;
        }

        public List<string> RemoveStopWords(List<string> textsToRemoveStopWords)
        {
            if (textsToRemoveStopWords.Count == 0)
            {
                throw new ArgumentException("Empty list (count = 0) passed to RemoveStopWords.");
            }
            List<string> list = new List<string>();
            foreach (string textsToRemoveStopWord in textsToRemoveStopWords)
            {

                bool flag = false;
                foreach (string stopWord in this.StopWords)
                {
                    if (textsToRemoveStopWord == stopWord)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    list.Add(textsToRemoveStopWord);
                }
            }
            return list;
        }
    }
}