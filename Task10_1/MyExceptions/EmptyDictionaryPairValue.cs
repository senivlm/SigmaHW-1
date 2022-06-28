using System;

namespace Task10_1.MyExceptions
{
    internal class EmptyDictionaryPairValueException : Exception
    {// Знову властивість з малої
        public string message { get; set; }
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
            message = "";
        }

        public EmptyDictionaryPairValueException(string message)
        {
            this.message = message;
        }
    }
}
