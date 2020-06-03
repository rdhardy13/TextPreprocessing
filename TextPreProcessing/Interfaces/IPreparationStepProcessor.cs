using System;
using System.Collections.Generic;

namespace TextPreprocessing.Processors
{
    public interface IPreparationStepProcessor
    {
        List<string> PrepareString(string toPrepare);
    }
}