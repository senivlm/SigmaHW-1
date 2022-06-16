using System;
using System.Collections.Generic;
using Task8_1.Enums;

namespace Task8_1
{

    internal class ConsumerRepository
    {
        private List<Consumer>[] _consumers = new List<Consumer>[4];

        public int CountRoomOne
        {
            get { return _consumers[0].Count; }
        }

        public int CountRoomTwo
        {
            get { return _consumers[1].Count; }
        }

        public int CountRoomThree
        {
            get { return _consumers[2].Count; }
        }

        public int CountRoomFour
        {
            get { return _consumers[3].Count; }
        }

        public ConsumerRepository(Consumer consumer, int quarter)
        {
            if (consumer == null | quarter < 0 | quarter > 4)
            {
                return;
            }
            AddConsumer(consumer, quarter);
        }

        public ConsumerRepository()
        {
            _consumers = new List<Consumer>[4];
        }

        //          Інформацію про квартири вважати однаковою, якщо збігається номер квартири та власник.
        public static List<Consumer> operator +(ConsumerRepository one, ConsumerRepository two)
        {
            Consumer temp = default;
            List<Consumer> allConsumers1 = one.GetAllConsumers();
            List<Consumer> allConsumers2 = two.GetAllConsumers();

            List<Consumer> result = new List<Consumer>(allConsumers1.Count + allConsumers2.Count);

            foreach (var item in allConsumers1)
            {
                temp = allConsumers2.Find(p => p.Name == item.Name);

                if (temp != default)
                {
                    int r = temp.RoomNumber;
                    string name = temp.Name;
                    double start = temp.StartMetrData;
                    double end = temp.EndMetrData;
                    DateTime first = temp.WithdrawalDateFirst;
                    DateTime second = temp.WithdrawalDateSecond;
                    DateTime three = temp.WithdrawalDateThrid;
                    result.Add(new Consumer()
                    {
                        RoomNumber = r,
                        Name = name,
                        StartMetrData = start,
                        EndMetrData = end,
                        WithdrawalDateFirst = first,
                        WithdrawalDateSecond = second,
                        WithdrawalDateThrid = three
                    });
                    temp = default;
                }
            }

            return result;

        }

        //      Інформацію про квартири вважати однаковою, якщо збігається номер квартири та власник.
        public static List<Consumer> operator -(ConsumerRepository one, ConsumerRepository two)
        {
            Consumer temp = default;
            List<Consumer> allConsumers1 = one.GetAllConsumers();
            List<Consumer> allConsumers2 = two.GetAllConsumers();


            foreach (var item in allConsumers1)
            {
                temp = allConsumers2.Find(p => p.Name == item.Name);

                if (temp != default)
                {
                    allConsumers1.Remove(item);
                }
                temp = default;
            }

            return allConsumers1;

        }

        public void AddConsumer(List<Consumer> consumers, int quarter)
        {
            if (consumers == null | quarter < 0 | quarter > 4)
            {
                return;
            }

            if (quarter == 1)
            {
                _consumers[0] = consumers;
            }

            if (quarter == 2)
            {
                _consumers[1] = consumers;
            }

            if (quarter == 3)
            {
                _consumers[2] = consumers;
            }

            if (quarter == 4)
            {
                _consumers[3] = consumers;
            }
        }      

        public void AddConsumer(Consumer consumer , int quarter)
        {

            if (consumer == null | quarter < 0 | quarter > 4)
            {
                return;
            }

            if (quarter == 1)
            {
                _consumers[0].Add(consumer);
            }

            if(quarter == 2)
            {
                _consumers[1].Add(consumer);
            }

            if(quarter == 3)
            {
                _consumers[2].Add(consumer);
            }

            if(quarter == 4)
            {
                _consumers[4].Add(consumer);
            }

        }

        public List<Consumer> GetConsumers(Quarter quarter)
        {

            if (quarter == Quarter.First)
            {
                return _consumers[0];
            }

            if (quarter == Quarter.Second)
            {
                return _consumers[1];
            }

            if (quarter == Quarter.Thrid)
            {
                return _consumers[2];
            }

            if (quarter == Quarter.Fourth)
            {
                return _consumers[3];
            }
            else
            {
                throw new ArgumentException();
            }

           
        }

        public List<Consumer> GetConsumers(int quarter)
        {
            if (quarter < 0 | quarter > 4)
            {
                
            }
            if (quarter == 1)
            {
                return _consumers[0];
            }

            if (quarter == 2)
            {
                return _consumers[1];
            }

            if (quarter == 3)
            {
                return _consumers[2];
            }

            if (quarter == 4)
            {
                return _consumers[3];
            }
            else
            {
                throw new ArgumentException();
            }

            
        }

        public Consumer GetConsumer(int quarter, int room)
        { 
            if (quarter < 0 | quarter > 4)
            {
                throw new ArgumentException();
            }

            List<Consumer> consumers = GetConsumers(quarter);

            return consumers?.Find(p => p.RoomNumber == room);
           
        }

        public int GetConsumerCount(Quarter quarter)
        {
            if (quarter == Quarter.First)
            {
                return CountRoomOne;
            }

            if (quarter == Quarter.Second)
            {
                return CountRoomTwo;
            }

            if (quarter == Quarter.Thrid)
            {
                return CountRoomThree;
            }

            if (quarter == Quarter.Fourth)
            {
                return CountRoomFour;
            }

            throw new ArgumentException();
        }

        public List<Consumer> GetAllConsumers()
        {
            List<Consumer> list = new List<Consumer>();
            list.AddRange(GetConsumers(1));
            list.AddRange(GetConsumers(2));
            list.AddRange(GetConsumers(3));
            list.AddRange(GetConsumers(4));
            return list;
        }

    }
}
