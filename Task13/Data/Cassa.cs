
namespace Task13
{
    internal class Cassa
    {
        private readonly double _cordinate;

        private bool _isFull = false;
        private bool _isClosed = false;
        private bool _isConcreteStatus = false;

        private int _concreteStatus;
        private int _cassNumber;
        private string _cassName;

        PriorityQueue<Person, int> queuePersons;
        IComparer<Person> comparable;

        public int GetEnqueueCount => queuePersons.Count;

        public int GetCassNumber => _cassNumber;

        public bool IsConcreteStatus => _isConcreteStatus;

        public bool IsClosed
        {
            get => _isClosed;
            set
            {
                _isClosed = value;
            }
        }

        public int GetConcreteStatus => _concreteStatus;

        public double GetCordinate => _cordinate;

        public string GetName => _cassName;

        public Cassa()
        {
            queuePersons = new();
            _cordinate = 0;
            _cassNumber = Constants.indefinedCassNumber;
            _cassName = $"Cass#{GetCassNumber}";
            comparable = new PersonStatusPriorityComparer();
        }

        public Cassa(double cordinate, int cassNumber)
        {
            queuePersons = new();
            _cordinate = cordinate;
            _cassNumber = cassNumber;
            _cassName = $"Cass#{GetCassNumber}";
            comparable = new PersonStatusPriorityComparer();
        }

        public void ChangeComparator(IComparer<Person> updateComparer, int statusConcrete)
        {
            _isConcreteStatus = true;
            comparable = updateComparer;
            _concreteStatus = statusConcrete;
        }

        public void SetDefaultCimparator()
        {
            _isConcreteStatus = false;
            comparable = new PersonStatusPriorityComparer();
        }

        public bool IsEmpty()
        {
            return queuePersons.Count == 0;
        }

        public string GetCurrentStatus()
        {
            foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
            {
                if (_concreteStatus == (int)item)
                    return item.ToString();
            }
            return "NaN";
        }

        public bool IsQueuesFull()
        {
            if (queuePersons.Count == Constants.maxQuequeQuantity)
            {
                return true;
            }

            return false;
        }

        public bool Enqueue(Person person)
        {
            if (IsQueuesFull())
            {
                Console.WriteLine($"\n\t\t\t ! {_cassName}  is full for a person: \n \t\t\t - [{person}] ");
                return _isFull = true;
            }

            if (_isConcreteStatus is false & _isClosed is false)
            {
                if (queuePersons.Count == 0)
                {
                    queuePersons.Enqueue(person, person.StatusId());
                    return _isFull;
                }
                queuePersons.Enqueue(person, comparable.Compare(person, Peek()));
                return _isFull;
            }

            if (person.StatusId() == _concreteStatus & _isClosed is false)
            {
                if (queuePersons.Count == 0)

                {
                    queuePersons.Enqueue(person, _concreteStatus);
                    return _isFull;
                }
                queuePersons.Enqueue(person, comparable.Compare(person, Peek()));
                return _isFull;
            }

            return true;
        }

        public Person Dequeue()
        {
            _isFull = false;
            return queuePersons.Dequeue();
        }

        public Person Peek()
        {
            return queuePersons.Peek();
        }

        public string PeekStatus()
        {
            return queuePersons.Peek().Status;
        }

        public override string ToString()
        {
            if (_isClosed) return string.Format($"{_cordinate:f1} | [CLOSED]");
            if (_isConcreteStatus) return string.Format($"{_cordinate:f1} | [only for {GetCurrentStatus()} status]");
            return string.Format($"{_cordinate:f1}");
        }
    }
}

