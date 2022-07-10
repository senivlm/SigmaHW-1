
namespace Task13
{
    internal static class PersonsParser
    {
        public static Person Parse(string text)
        {
            if (text == null | text == "") throw new NullReferenceException("Person not found");

            string[]? atributes = text?.Split(Constants.symbolSeparate,
                StringSplitOptions.RemoveEmptyEntries);

            string status = Constants.defaultStatus;
            string name = Constants.defaultName;
            int age = Constants.defaultAge;
            double coordinate = Constants.defaultCoordinate;
            int serviceTime = Constants.defaultServiceTime;

            for (int i = 0; i < atributes?.Length; i++)
            {
                if (status == Constants.defaultStatus && IsStatus(atributes[i], out status)) continue;

                if (name == Constants.defaultName && IsName(atributes[i], out name)) continue;

                if (age == Constants.defaultAge && IsAge(atributes[i], out age)) continue;

                if (coordinate == Constants.defaultCoordinate && IsCoordinate(atributes[i], out coordinate)) continue;

                if (serviceTime == Constants.defaultServiceTime && IsTimeService(atributes[i], out serviceTime)) continue;

            }

            if (IsPersonReady(status, name, age, coordinate, serviceTime))
            {
                return new Person(
                        status: status,
                        name: name,
                        age: age,
                        coordinate: coordinate,
                        serviseTime: serviceTime);
            }
            else
            {
                throw new NullReferenceException("Person not found");
            }
        }

        private static bool IsPersonReady(string status, string name, int age, double coordinate, int serviceTime)
        {
            if (status == Constants.defaultStatus | name == Constants.defaultName
                | age == Constants.defaultAge | coordinate == Constants.defaultCoordinate
                | serviceTime == Constants.defaultServiceTime)
            {
                return false;
            }

            return true;
        }

        private static bool IsStatus(string text, out string status)
        {
            foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
            {
                if (item.ToString().Equals(text))
                {
                    status = item.ToString();
                    return true;
                }
            }
            status = Constants.defaultStatus;
            return false;
        }

        private static bool IsName(string text, out string name)
        {
            foreach (var item in (Names[])Enum.GetValues(typeof(Names)))
            {
                if (item.ToString().Equals(text))
                {
                    name = item.ToString();
                    return true;
                }
            }

            name = Constants.defaultName;
            return false;
        }

        private static bool IsAge(string text, out int age)
        {
            if (int.TryParse(text, out int temp))
            {
                if (temp > 0 && temp <= Constants.maxAge)
                {
                    age = temp;
                    return true;
                }
            }
            age = Constants.defaultAge;
            return false;
        }

        private static bool IsCoordinate(string text, out double coordinate)
        {
            if (double.TryParse(text, out double temp))
            {
                if (temp > 0 && temp <= Constants.maxServiceTime)
                {
                    coordinate = temp;
                    return true;
                }
            }
            coordinate = Constants.defaultCoordinate;
            return false;
        }

        private static bool IsTimeService(string text, out int serviceTime)
        {
            if (int.TryParse(text, out int temp))
            {
                if (temp >= 0 && temp <= Constants.maxServiceTime)
                {
                    serviceTime = temp;
                    return true;
                }
            }
            serviceTime = Constants.defaultServiceTime;
            return false;
        }
    }
}
