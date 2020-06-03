using System;
using System.Collections.Generic;

namespace TextPreprocessing.Processors
{
    public interface IStopWordProcessor
    {
        List<string> RemoveStopWords(List<string> textsToRemoveStopWords);
    }
}