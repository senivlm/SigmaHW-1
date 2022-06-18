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

        public double GetPay() => endMetrData - startMetrData;

        public int GetDifferenceDay()
        {
            if (withdrawalDateThrid.Day > 0)
            {
                return int.Parse(WithdrawalDateThrid.Day.ToString());
            }
            if (withdrawalDateSecond.Day > 0)
            {
                return int.Parse(WithdrawalDateSecond.Day.ToString());
            }
            if (withdrawalDateFirst.Day > 0)
            {
                return int.Parse(withdrawalDateThrid.Day.ToString());
            }
            else
            {
                return 0;
            }

        }

        public string WriteHat(int quarter)
        {
            if (quarter == 1)
            {
                return $"Rooms\tLastName	\tStart		\tEnd\t\t\t\tJanuary     February   Marth\r\n";
            }
            if (quarter == 2)
            {
                return $"Rooms\tLastName	\tStart		\tEnd\t\t\t\tApril       May        June\r\n";
            }
            if (quarter == 3)
            {
                return $"Rooms\tLastName	\tStart		\tEnd\t\t\t\tJuly        August     September\r\n";
            }
            if (quarter == 4)
            {
                return $"Rooms\tLastName	\tStart		\tEnd\t\t\t\tOctober     November   December\r\n";
            }
            else
            {
                return ($"{string.Format("{0,-8}", "№Room")}" +
                    $"{string.Format("{0,-16}", "Name")}" +
                    $"{string.Format("{0,-16}", "Start")}" +
                    $"{string.Format("{0,-16}", "End")}" +
                    $"{string.Format("{0,-11}", "NaN")}" +
                    $"{string.Format("{0,-11}", "NaN")}" +
                    $"{string.Format("{0,-11}", "NaN")}\r\n");
            }
        }

        public override string ToString()
        {

            return ($"[{string.Format("{0,-6:d3} ", roomNumber + "]")}" +
                $"{string.Format("{0,-16}", Name)}" +
                $"[{string.Format("{0,-15}", startMetrData + "]")}" +
                $"[{string.Format("{0,-15}", endMetrData + "]")}" +
                $"[{withdrawalDateFirst.Date.ToString("M")} | " +
                $"{withdrawalDateSecond.ToString("M")} | " +
                $"{withdrawalDateThrid.Date.ToString("M")}]");

        }

    }
}


