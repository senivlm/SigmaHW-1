using System;

namespace Task10_1.MyExceptions
{
    internal class EmptyDictionaryPairValueException : Exception
    {
        private string message;

        public string GetMessage()
        {
            return message;
        }

        public void SetMessage(string value)
        {
            message = value;
        }

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
            SetMessage("");
        }

        public EmptyDictionaryPairValueException(string message)
        {
            this.SetMessage(message);
        }
    }
}
