using System.Collections.Generic;

namespace Task10_1
{
    interface IWorkerWithTranslationGroup
    {
        Dictionary<string, string> ReadDictionary(
            string filePath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task10_1\Files\Dictionary.txt");

        void WriteToDictionary(string key, string value, 
            string filePath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task10_1\Files\Dictionary.txt");
    }
}
