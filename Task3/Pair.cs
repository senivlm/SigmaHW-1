namespace Task3
{
    internal class Pair
    {
        private int number;
        private int frequency;

        public Pair()
        {
            number = 0;
            frequency = 0;
        }

        public Pair(int number, int freq)
        {
            this.number = number;
            this.frequency = freq;
        }

        public int Number { get => number; set => number = value; }

        public int Frequency { get => frequency; set => frequency = value; }

        public override string ToString()
        {
            return $"Number: {Number} - Frequency: {Frequency}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Pair))
            {
                return false;
            }

            return this.Number == ((Pair)obj).Number;

        }

        public override int GetHashCode()
        {
            return number.GetHashCode() ^ frequency.GetHashCode();
        }
    }
}
