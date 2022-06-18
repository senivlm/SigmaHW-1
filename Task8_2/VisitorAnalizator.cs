using System;
using System.Collections.Generic;

namespace Task8_2
{
    internal class VisitorAnalizator
    {
        private const string _VariableCount = "Counter";
        private const string _VariablePopularDay = "PopularDay";
        private const string _VariablePopularHour = "PopularHour";
        private List<Visitor> visitors;
        private Dictionary<string, Dictionary<string, int>> analitics;

        public VisitorAnalizator()
        {
            visitors = new List<Visitor>();
            analitics = new Dictionary<string, Dictionary<string, int>>();
        }

        public VisitorAnalizator(List<Visitor> list)
        {
            analitics = new Dictionary<string, Dictionary<string, int>>();
            int counter = default;
            string analiticKey = default;
            int[] day = new int[7];
            int[] hour = new int[24];

            foreach (Visitor visitor in list)
            {
                analiticKey = visitor.Ip;
                foreach (var visit in visitor.GetVisits())
                {
                    counter++;
                    hour[visit.Hours] += 1;
                }

                foreach (var visit in visitor.GetDays())
                {
                    switch (visit)
                    {
                        case DayOfWeek.Sunday:
                            day[0]++;
                            break;
                        case DayOfWeek.Monday:
                            day[1]++;
                            break;
                        case DayOfWeek.Tuesday:
                            day[2]++;
                            break;
                        case DayOfWeek.Wednesday:
                            day[3]++;
                            break;
                        case DayOfWeek.Thursday:
                            day[4]++;
                            break;
                        case DayOfWeek.Friday:
                            day[5]++;
                            break;
                        case DayOfWeek.Saturday:
                            day[6]++;
                            break;
                    }
                }

                analitics.Add(analiticKey, new Dictionary<string, int>()
                {
                    [_VariableCount] = counter,
                    [_VariablePopularDay] = GetPopular(day),
                    [_VariablePopularHour] = GetPopular(hour)
                });
                counter = default;
            }
            visitors = list;
        }

        public void DispalayAllVizitors()
        {
            foreach (var item in visitors)
            {
                Console.WriteLine(item);
                Console.WriteLine($"Count Visits for ip[{item.Ip}] is: [{GetCountVisitsPerWeek(item.Ip)}]");
                Console.WriteLine($"Most popular day Visits for ip[{item.Ip}] is: [{GetPopularDayperWeekVisits(item.Ip)}]");
                Console.WriteLine($"Most popular hour Visits for ip[{item.Ip}] is: [{GetPopularHourPerWeekVisits(item.Ip)}:00:00]");
                Console.WriteLine("***********************************************\n");
            }
        }

        public int GetCountVisitsPerWeek(string ip)
        {
            foreach (var item in analitics)
            {
                if (item.Key == ip)
                {
                    foreach (var count in item.Value)
                    {
                        if (count.Key.Equals(_VariableCount))
                        {
                            return count.Value;
                        }
                    }
                }
            }

            return 0;
        }

        public DayOfWeek GetPopularDayperWeekVisits(string ip)
        {
            foreach (var item in analitics)
            {
                if (item.Key == ip)
                {
                    foreach (var count in item.Value)
                    {
                        if (count.Key.Equals(_VariablePopularDay))
                        {
                            if (count.Value == 0) return DayOfWeek.Saturday;
                            if (count.Value == 1) return DayOfWeek.Monday;
                            if (count.Value == 2) return DayOfWeek.Tuesday;
                            if (count.Value == 3) return DayOfWeek.Wednesday;
                            if (count.Value == 4) return DayOfWeek.Thursday;
                            if (count.Value == 5) return DayOfWeek.Friday;
                            if (count.Value == 6) return DayOfWeek.Sunday;
                        }
                    }
                }
            }

            return DayOfWeek.Saturday;
        }

        public int GetPopularHourPerWeekVisits(string ip)
        {
            foreach (var item in analitics)
            {
                if (item.Key == ip)
                {
                    foreach (var count in item.Value)
                    {
                        if (count.Key.Equals(_VariablePopularHour))
                        {
                            return count.Value;
                        }
                    }
                }
            }

            return 0;
        }

        public int GetPopularHourPerWeekVisitsForAllSite()
        {
            int[] allDay = new int[24];
            List<TimeSpan> temp = new List<TimeSpan>();

            foreach (var visitor in visitors)
            {
                temp = visitor.GetVisits();
                foreach (var timeSp in temp)
                {
                    allDay[timeSp.Hours] += 1;
                }
            }

            return GetPopular(allDay);
        }

        private int GetPopular(int[] array)
        {
            int result = default;
            int buffer = default;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > buffer)
                {
                    result = i;
                    buffer += 1;
                }
            }
            return result;
        }
    }
}


/*

     Для кожного ip вкажіть кількість відвідувань на тиждень, 
     найбільш популярний день тижня,  
     найбільш популярний відрізок часу довжиною в одну годину. 

     Знайдіть також найбільш популярний відрізок часу в добі довжиною одну годину в цілому для сайту. 
 
     Продумайте, як оптимально здійснити повторювану дію для різних даних.
*/
