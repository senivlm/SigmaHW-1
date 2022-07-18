
namespace Task13
{
    delegate bool ReprofilHandler(List<Cassa> casses, out Status choiseStatus, out string choiseCass);

    internal static class Constants
    {
        public const string defaultStatus = "";
        public const int defaultStatusNumber = -1;
        public const string defaultName = "";
        public const int defaultAge = -1;
        public const double defaultCoordinate = -1.0;
        public const int defaultServiceTime = -1;
        public const int defaultCountCreatePerson = 15;

        public const int minServiceTime = 1;
        public const int minCoordinate = 0;

        public const int maxCoordinate = 4;
        public const int maxAge = 100;
        public const int maxServiceTime = 100;
        public const int maxTimeService = 10;

        public const int maxQuequeQuantity = 2;
        public const int timeCounter = 1;
        public const int periodWriting = 10;

        public const int defaultCassaCordinate_X = 4;
        public static char[] symbolSeparate = { ' ', '[', ']', '-', '|', '/', '{', '}', '<' , '>' };
        public static int cassNumber = 0;
        public static int indefinedCassNumber = 0;
        public const int quantutyPersonsGenerate = 30;
        public const int attemptsFullQuantity = 2;
    }
}
