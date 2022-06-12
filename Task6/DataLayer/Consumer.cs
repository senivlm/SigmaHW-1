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

        public int GetDifferenceDay() => DateTime.Now.Day - WithdrawalDateThrid.Day;


        public override string ToString()
        {
            return ($"[{string.Format("{0:d3}", roomNumber)}]\t" +
                $"{string.Format("{0,-10}", Name)}\t[{startMetrData}]\t" +
                $"[{endMetrData}]\t[{withdrawalDateFirst.ToString("dd.MM.yy")} | " +
                $"{withdrawalDateSecond.ToString("dd.MM.yy")} | " +
                $"{withdrawalDateThrid.ToString("dd.MM.yy")}]");

        }





    }
}


/*
Rooms	LastName	Start		End			January		February		 Marth
[001]	Semenov		[00123,55]  [00125,25]  [01.01.21 | Feb - 01.02.21 | Mar - 01.03.21]
[002]	Bogdanov	[00129,55]  [00155,35]  [02.01.21 | Feb - 02.02.21 | Mar - 02.03.21]
[003]	Kerimov		[00955,55]  [01033,25]  [03.01.21 | Feb - 03.02.21 | Mar - 03.03.21]
[004]	Anisimova	[12345,55]  [12346,25]  [04.01.21 | Feb - 04.02.21 | Mar - 04.03.21]
[005]	Tin			[95565,55]  [99999,99]  [05.01.21 | Feb - 05.02.21 | Mar - 05.03.21]
*/

