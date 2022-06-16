using System.Collections.Generic;

namespace Task6.DataLayer
{
    internal class ConsumptionСalculator
    {
        private double kWattPrice = 1.99;

        public double KWattPrice
        {
            get => kWattPrice;

            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    kWattPrice = value;
                }
            }

        }

        public double TotalPaymentAmount(int room, ConsumerRepository cRepo)
        {
            double result = default;

            List<Consumer> consumers = new List<Consumer>();
            consumers = cRepo.GetAllConsumers();

            List<Consumer> allRoomAmouts = consumers.FindAll(p => p.RoomNumber == room);

            foreach (var item in allRoomAmouts)
            {
                result += item.GetPay();
            }

            return result;

        }

        public string TotalPaymentAmountToString(int room, ConsumerRepository cRepo)
        {
            double result = TotalPaymentAmount(room, cRepo);

            return $"Total Payment Amount:     [{result}]";
        }

        public int GetDaysAfterLastVerification(int room, ConsumerRepository cRepo)
        {
            int result = default;
            List<Consumer> consumers = new List<Consumer>();
            consumers = cRepo.GetAllConsumers();

            List<Consumer> allRoomAmouts = consumers.FindAll(p => p.RoomNumber == room);

            foreach (var item in allRoomAmouts)
            {
                result += item.GetDifferenceDay();
            }

            return result;
        }

        public string GetDaysAfterLastVerificationToString(int room, ConsumerRepository cRepo)
        {
            double result = GetDaysAfterLastVerification(room, cRepo);

            return $"Total Last Payment Amount:     [{result}] days after";
        }

        public string GetMostDebtor(ConsumerRepository cRepo)
        {
            double result = default;
            Consumer storageResult = default;
            List<Consumer> consumers = cRepo.GetAllConsumers();           

            foreach (var item in consumers)
            {
                if (item.GetPay() > result)
                {
                    result = item.GetPay();
                    storageResult = item;
                }
            }

            return $"{storageResult} \nhas a most debtor";
        }
    }
}
