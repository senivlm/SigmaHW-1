using System;

namespace Task6
{
    internal class Consumer
    {
        private int quarter;
        private int roomNumber;
        private string name;
        private double startMetrData;
        private double endMetrData;
        private DateTime withdrawalDate;

        public int Quarter
        {
            get { return quarter; }
            set
            {
                if (value > 0)
                    Quarter = value;
            }
        }

        public int RoomNumber
        {
            get { return roomNumber; }
            set
            {
                if (value > 0)
                    roomNumber = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null && value.Length > 2)
                    name = value;
            }
        }

        public double StartMetrData
        {
            get { return startMetrData; }
            set
            {
                if (value > 0)
                    startMetrData = value;
            }
        }

        public double EndMetrData
        {
            get { return endMetrData; }
            set
            {
                if (value > startMetrData)
                    endMetrData = value;
            }
        }

        public Consumer()
        {
            quarter = default;
            roomNumber = default;
            name = "NaN";
            startMetrData = default;
            endMetrData = default;
            withdrawalDate = default;
        }

        public Consumer(int quarter, int roomNumber, string FullName)
        {
            this.quarter = quarter;
            this.roomNumber = roomNumber;
            name = FullName;
        }

        public Consumer(int quarter, int roomNumber, string FullName, double startMetrData, double endMetrData, DateTime withdrawalDate)
        {
            this.quarter = quarter;
            this.roomNumber = roomNumber;
            name = FullName;
            this.startMetrData = startMetrData;
            this.endMetrData = endMetrData;
            this.withdrawalDate = withdrawalDate;
        }

        public void SetWithdrawalDate (DateTime withdrawalDate)
        {
            this.withdrawalDate = withdrawalDate;
        }

        public override string ToString()
        {
            return String.Format($"{quarter} - {roomNumber}:\n{name} {startMetrData} {endMetrData} {withdrawalDate}");
        }
    }
}


