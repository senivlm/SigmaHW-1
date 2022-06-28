using System;

namespace Task10_1.MyExceptions
{
    internal class EmptyDictionaryPairValueException : Exception
    {
        public string Message { get; set; }
        private int countAttempt;

        public int CountAttempt
        {
            get { return countAttempt; }
            set
            {
                if (value < 0)
                {
                    return;
                }
                countAttempt = value;
            }
        }

        public EmptyDictionaryPairValueException()
        {
            Message = "";
        }

        public EmptyDictionaryPairValueException(string message)
        {
            this.Message = message;
        }
    }
}
