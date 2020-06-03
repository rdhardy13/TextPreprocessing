using System;
using System.Collections.Generic;

namespace TextPreprocessing.Processors
{
    public interface IStemmingProcessor
    {
        List<string> StemWords(List<string> wordsToStem);
    }
}