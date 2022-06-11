using System;
using System.Collections.Generic;;

namespace Task6
{
    enum Quarter { One, Two, Three, Four }

    internal class ConsumerRepository
    {
        public readonly Quarter quarter;       
        private List<Consumer> _consumersOneQuart;
        private List<Consumer> _consumersTwoQuart;
        private List<Consumer> _consumersThreeQuart;
        private List<Consumer> _consumersFourQuart;

        private int countRoomOne;
        private int countRoomTwo;
        private int countRoomThree;
        private int countRoomFour;

        public ConsumerRepository(Consumer consumer, Quarter quarter)
        {
            AddConsumer(consumer, quarter);
        }

        public ConsumerRepository()
        {
            _consumersOneQuart = new List<Consumer>();
            _consumersTwoQuart = new List<Consumer>();
            _consumersThreeQuart = new List<Consumer>();
            _consumersFourQuart = new List<Consumer>();
        }

        public void AddConsumer(Consumer consumer , Quarter quarter)
        {
            if(quarter == Quarter.One)
            {
                _consumersOneQuart.Add(consumer);
                countRoomOne++;
            }

            if(quarter == Quarter.Two)
            {
                _consumersTwoQuart.Add(consumer);
                countRoomTwo++;
            }

            if(quarter == Quarter.Three)
            {
                _consumersThreeQuart.Add(consumer);
                countRoomThree++;
            }

            if(quarter == Quarter.Four)
            {
                _consumersFourQuart.Add(consumer);
                countRoomFour++;
            }

        }

        public List<Consumer> GetConsumer(Quarter quarter)
        {
            if (quarter == Quarter.One)
            {
                return _consumersOneQuart;
            }

            if (quarter == Quarter.Two)
            {
                return _consumersTwoQuart;
            }

            if (quarter == Quarter.Three)
            {
                return _consumersThreeQuart;
            }

            if (quarter == Quarter.Four)
            {
                return _consumersFourQuart;
            }

            throw new ArgumentException();
        }

        public int GetConsumerCount(Quarter quarter)
        {
            if (quarter == Quarter.One)
            {
                return countRoomOne;
            }

            if (quarter == Quarter.Two)
            {
                return countRoomTwo;
            }

            if (quarter == Quarter.Three)
            {
                return countRoomThree;
            }

            if (quarter == Quarter.Four)
            {
                return countRoomFour;
            }

            throw new ArgumentException();
        }

    }
}
