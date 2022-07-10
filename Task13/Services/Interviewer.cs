
namespace Task13
{

    internal static class Interviewer
    {
        public static bool IsQuit()
        {
            Console.WriteLine("\t\t\t ! All clients were servised..." +
                "\n\t\t\t  Load new Clients?" +
                "\n\t\t\t  Y/y or N/n");

            string? answer = "";
            Console.Write("\t\t\t >>");
            answer = Console.ReadLine()?.ToLower();

            if (answer is null || answer.Equals("n"))
            {
                return false;
            }

            if (answer is null || answer.Equals("y"))
            {
                return true;
            }

            return IsQuit();
        }

        public static bool ReprofilToSpecificStatus(List<Cassa> casses, out Status choiseStatus, out string choiseCassName)
        {
            Console.WriteLine("\t\t\t ! Do you want reprofil some cass to a specific status?" +
                                        "\n\t\t\t  Y/y or N/n");

            string? answer = "";
            Console.Write("\t\t\t >>");
            answer = Console.ReadLine()?.ToLower();

            if (answer is null || answer.Equals("n"))
            {
                choiseStatus = Status.Ordinary;
                choiseCassName = Constants.indefinedCassNumber.ToString();
                return false;
            }

            if (answer is null || answer.Equals("y"))
            {
                choiseStatus = ChoiseStatus();
                choiseCassName = ChoiseCassName(casses);
                return true;
            }

            Console.WriteLine();
            return ReprofilToSpecificStatus(casses, out choiseStatus, out choiseCassName);
        }

        public static Status ChoiseStatus()
        {
            int counter = default;
            Console.WriteLine("\t\t\t Chose need number status:");
            foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
            {
                Console.WriteLine($"\t\t\t Chose <<{++counter}>> if you need {item}");
            }

            counter = default;
            Console.Write("\t\t\t >>");
            int numberStatus = Constants.defaultStatusNumber;
            if (int.TryParse(Console.ReadLine(), out numberStatus))
            {
                foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
                {
                    if(numberStatus == ++counter) return item;
                }

                return ChoiseStatus();
            }
            else
            {
                return ChoiseStatus();
            }
        }

        public static string ChoiseCassName(List<Cassa> casses)
        {
            int counter = default;
            Console.WriteLine("\t\t\t Chose need Cass number:");
            foreach (var item in casses)
            {
                Console.WriteLine($"\t\t\t Chose <<{++counter}>> if you need" + item.GetName);
            }

            Console.Write("\t\t\t >>");
            counter = default;
            int numberStatus = Constants.defaultStatusNumber;
            if (int.TryParse(Console.ReadLine(), out numberStatus))
            {
                foreach (var item in casses)
                {
                    if (numberStatus == ++counter) return item.GetName;
                }

                return ChoiseCassName(casses);
            }
            else
            {
                return ChoiseCassName(casses);
            }
        }

        public static bool IsCloseCase()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t ! Do you want close cases?"
                               + "\n\t\t\t Y/y or N/n");


            string? answer = "";
            Console.Write("\t\t\t >>");
            answer = Console.ReadLine()?.ToLower();

            if (answer is null || answer.Equals("n"))
            {
                return false;
            }

            if (answer is null || answer.Equals("y"))
            {
                return true;
            }

            Console.WriteLine();
            return false;
        }
    }
}
