
using System.Collections;

namespace Task13
{
    internal class Person
    {
        public Guid Id { get; }
        private string _name;
        private int _serviceTime;
        private int _age;
        private double _coordinate;
        private string _status;

        public int TimeServise
        {
            get => _serviceTime;
            set
            {
                _serviceTime = value;
            }
        }

        public string Status { get => _status; }

        public int Age { get => _age; }

        public double Coordinate { get => _coordinate; }

        public Person() : 
            this(Constants.defaultStatus, Constants.defaultName,
                Constants.defaultAge, Constants.defaultCoordinate, 
                Constants.defaultServiceTime) { }

        public Person(string status, string name, int age, double coordinate, int serviseTime)
        {
            Id = Guid.NewGuid();
            _name = name;
            _age = age;
            _coordinate = coordinate;
            _status = status;
            _serviceTime = serviseTime;
        }

        public int StatusId()
        {
            foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
            {
                if (Status.Equals(item.ToString()))
                    return (int)item;
            }

            return Constants.defaultStatusNumber;
        }

        public override string ToString()
        {
            return $"{_status,-10} {_name,-10} {_age,-6} {_coordinate,-10} {_serviceTime,-4}";
        }

        public string ToStringWithoutServiceTime()
        {
            return $"{_status,-10} {_name,-10} {_age,-6} {_coordinate,- 10}";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
