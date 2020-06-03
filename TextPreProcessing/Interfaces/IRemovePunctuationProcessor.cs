using System;
using System.Collections.Generic;

namespace TextPreprocessing.Processors
{
    public interface IRemovePunctuationProcessor
    {
        List<string> RemovePunctuation(List<string> textsToRemovePunctuation);
    }
}