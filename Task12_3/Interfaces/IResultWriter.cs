using System.Collections.Generic;

namespace Task12_3
{
    internal interface IResultWriter
    {
        void WriteCalculateResult(List<string> calculateExpressions,
            string filePath = @"..\..\..\Files\Result.txt");
    }
}
