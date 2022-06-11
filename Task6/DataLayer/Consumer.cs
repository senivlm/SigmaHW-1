using System;

namespace Task6
{
    internal class Consumer
    {
        //private int quarter;
        private int roomNumber;
        private string name;
        private double startMetrData;
        private double endMetrData;
        private DateTime withdrawalDateFirst;
        private DateTime withdrawalDateSecond;
        private DateTime withdrawalDateThrid;

        public DateTime WithdrawalDateFirst
        {
            get { return withdrawalDateFirst; }
            set
            {
                if (value != null)
                    withdrawalDateFirst = value;
            }
        }

        public DateTime WithdrawalDateSecond
        {
            get { return withdrawalDateSecond; }
            set
            {
                if (value != null)
                    withdrawalDateSecond = value;
            }
        }

        public DateTime WithdrawalDateThrid
        {
            get { return withdrawalDateThrid; }
            set
            {
                if (value != null)
                    withdrawalDateThrid = value;
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
            roomNumber = default;
            name = "NaN";
            startMetrData = default;
            endMetrData = default;
            withdrawalDateFirst = default;
            withdrawalDateSecond = default;
            withdrawalDateThrid = default;
        }

        public Consumer(int roomNumber, string FullName)
        {
            this.roomNumber = roomNumber;
            name = FullName;
        }

        public Consumer(int roomNumber, string FullName, double startMetrData, 
            double endMetrData, DateTime withdrawalDateFirst, DateTime withdrawalDateSecond, 
            DateTime withdrawalDateThird)
        {
            this.roomNumber = roomNumber;
            name = FullName;
            this.startMetrData = startMetrData;
            this.endMetrData = endMetrData;
            this.withdrawalDateFirst = withdrawalDateFirst;
            this.withdrawalDateSecond = withdrawalDateSecond;
            this.withdrawalDateThrid = withdrawalDateThird;
        }

        public override string ToString()
        {
            return String.Format($"[{string.Format("{0:d3}", roomNumber)}] {Name} [{startMetrData}] [{endMetrData}] [{withdrawalDateFirst.ToString("dd.MM.yy")} , {withdrawalDateSecond.ToString("dd.MM.yy")} , {withdrawalDateThrid.ToString("dd.MM.yy")}]");
        }
    }
}


