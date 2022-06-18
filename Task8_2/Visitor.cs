using System;
using System.Collections.Generic;
using System.Text;


namespace Task8_2
{
    internal class Visitor
    {
        private string ip;
        private Dictionary<DayOfWeek, List<TimeSpan>> visits;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        public Visitor(string ip, DayOfWeek dof, TimeSpan visit)
        {
            visits = new Dictionary<DayOfWeek, List<TimeSpan>>();

            Ip = ip;
            visits.Add(dof, new List<TimeSpan>() { visit });
        }

        public List<TimeSpan> GetVisits(DayOfWeek dayOfWeek)
        {
            List<TimeSpan> result = new List<TimeSpan>();
            foreach (var item in visits)
            {
                if (item.Key == dayOfWeek)
                {
                    foreach (var i in item.Value)
                    {
                        result.Add(i);
                    }
                }
            }

            return result;
        }

        public List<TimeSpan> GetVisits()
        {
            List<TimeSpan> result = new List<TimeSpan>();
            foreach (var item in visits)
            {

                foreach (var i in item.Value)
                {
                    result.Add(i);
                }

            }

            return result;
        }

        public List<DayOfWeek> GetDays()
        {
            List<DayOfWeek> currentDays = new List<DayOfWeek>();
            foreach (var item in visits)
            {
                currentDays.Add(item.Key);
            }

            return currentDays;
        }

        public void AddVisit(TimeSpan time, DayOfWeek dayOfWeek)
        {
            foreach (var item in visits)
            {
                if (item.Key == dayOfWeek)
                {
                    item.Value.Add(time);
                }
                if (visits.ContainsKey(dayOfWeek))
                {
                    continue;
                }
                else
                {
                    visits.Add(dayOfWeek, new List<TimeSpan>() { time });
                    break;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"[{ip}]:\n");
            foreach (var item in visits)
            {
                sb.Append($"  -in {item.Key} visits:\t\n");
                foreach (var i in item.Value)
                {
                    sb.Append("\t\t" + i + "\n");
                }

            }
            string result = sb.ToString();
            return result;
        }
    }
}
