using System;
using System.Collections.Generic;

namespace TextPreprocessing.Processors
{
    public interface IExpandContractionProcessor
    {
        List<string> ExpandContractions(List<string> textsToExpand);
    }
}