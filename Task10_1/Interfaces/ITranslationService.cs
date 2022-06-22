
using System.Collections.Generic;

namespace Task10_1
{
    internal interface ITranslationService
    {
        List<string> ChangeWords(List<string> text, Dictionary<string, string> vocabluary);
    }
}
