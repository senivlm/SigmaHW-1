using System.Text;

namespace Task13
{
    internal class Simulator
    {
        public event ReprofilHandler QueueOverflowEvent;
        public event Func<bool> CloseQueueEvent;
        private ICassGenerator _cassGen;
        private IPersonGenerator _pGen;
        private List<Cassa> _casses;
        private List<Person> _persons;
        private int _countAttempts = default;
        private bool _isStopRead = false;

        #region Ctors
        public Simulator(ICassGenerator cassGen, IPersonGenerator pGen)
        {
            _cassGen = cassGen;
            _pGen = pGen;
        }

        public Simulator() : this(new CassGenerator(), new PersonGenerator()) { }
        #endregion

        public void Cordinate(List<Person> persons, List<Cassa> casses, IWriterTinnedPersons writer)
        {
            ReadCasses();
            ReadPersons();
            MergeCasses(casses);
            MergePersons(persons);

            StringBuilder sb = new();
            bool isProcess = true;
            int counter = default;
            int time = default;
            int currentCassIndex = default;

            while (isProcess)
            {
                time++;

                if (time % Constants.periodWriting == 0)
                {
                    CloseCasses();
                }

                if (time % Constants.timeCounter == 0 && counter < _persons.Count)
                {
                    if (!_isStopRead)
                    {
                        currentCassIndex = AddToQueue(ref counter);
                    }
                    else
                    {
                        if (_casses.All(p => p.GetEnqueueCount <= (Constants.maxQuequeQuantity / 2)))
                        {
                            _isStopRead = false;
                            _countAttempts = default;
                        }
                    }
                }

                int number = default;
                foreach (var item in _casses)
                {
                    ++number;
                    if (!item.IsEmpty() && --item.Peek().TimeServise <= 0)
                    {
                        DequeueFromQueue(sb, number, item);
                    }

                    if (time % Constants.periodWriting == 0)
                    {
                        SendToResult(writer, sb);
                    }
                }

                if (_persons.Count == counter && _casses.All(p => p.GetEnqueueCount == 0))
                {
                    SendToResult(writer, sb);

                    isProcess = IsContinue();
                    counter = default;
                }

                Thread.Sleep(1000);
            }
        }

        #region SubMethods

        private void CloseCasses()
        {
            bool? answer = CloseQueueEvent?.Invoke();
            if (!(answer is null) && answer is true)
            {
                string cassName = Interviewer.ChoiseCassName(_casses);
                _casses.Find(p=> p.GetName == cassName).IsClosed = true;
                RebuildClosedCases(cassName);
                CloseCasses();
            }
        }

        private void RebuildClosedCases(string choiseCassName)
        {

            foreach (var cass in _casses)             
            {
                if (cass.IsClosed)
                {
                    int count = cass.GetEnqueueCount;
                    for (int i = 0; i < count; i++)
                    {
                        _persons.Add(cass.Dequeue());
                    }
                }
            }
        }

        private void RebuildQueues(Status choiseStatus, string choiseCassName)
        {
            List<Person> personsForChoiseStatus = new();
            Dictionary<Person, int> tempPersons = new();
            int curentIndex = -1;
            int counter = default;

            foreach (var item in _casses)
            {
                counter++;
                if (item.GetName == choiseCassName) curentIndex = counter;

                int countPersons = item.GetEnqueueCount;
                for (int i = 0; i < countPersons; i++)
                {
                    if (item.PeekStatus().Equals((choiseStatus).ToString()))
                    {
                        personsForChoiseStatus.Add(item.Dequeue());
                    }
                    else
                    {
                        tempPersons.Add(item.Dequeue(), counter);
                    }
                }
            }

            _casses[curentIndex - 1].ChangeComparator(new PersonStatusPriorityComparer(), (int)choiseStatus);
            foreach (var item in personsForChoiseStatus)
            {
                _casses[curentIndex - 1].Enqueue(item);
            }

            foreach (var item in tempPersons)
            {
                if (item.Value != _casses[item.Value - 1].GetCassNumber)
                {
                    _casses[item.Value - 1].Enqueue(item.Key);
                }
                else
                {
                    int index = GetFreeNearestQueueIndex(_casses, item.Key);
                    _casses[index].Enqueue(item.Key);
                }
            }
        }

        private void ReadCasses(int countCassCreate = Constants.defaultCassaCordinate_X)
        {
            _casses = _cassGen.GenerateCasses(countCassCreate);
        }

        private bool IsContinue()
        {
            bool isProcess = Interviewer.IsQuit();
            if (isProcess)
            {
                _pGen.Clear();
                _pGen.WriteRandomGenerate(Constants.quantutyPersonsGenerate);
                ReadPersons();
            }

            return isProcess;
        }

        private void ReadPersons()
        {
            _persons = _pGen.ReadPersons();
        }

        private void MergePersons(List<Person> persons)
        {
            if (persons is null) return;
            _persons.AddRange(persons);
        }

        private void MergeCasses(List<Cassa> cassas)
        {
            if (cassas is null) return;
            _casses.AddRange(cassas);
        }

        private int GetFreeNearestQueueIndex(List<Cassa> casses, Person person)
        {
            int counter = int.MaxValue;
            int minIndex = -1;
            int midIndex = -1;
            int maxIndex = -1;

            if (_casses.Any(p => p.IsConcreteStatus & !p.IsClosed))
            {
                int currentStatus = -1;

                foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
                {

                    currentStatus++;
                    if (item.ToString().Equals(person.Status.ToString()))
                    {
                        break;
                    }
                }
                int result = _casses.FindIndex(p => p.GetConcreteStatus.Equals(currentStatus) & !p.IsClosed);
                if (result >= 0) return result;

            }

            for (int i = 0; i < casses.Count; i++)
            {
                if (casses[i].GetEnqueueCount < counter
                    & casses[i].GetEnqueueCount < Constants.maxQuequeQuantity
                    & !casses[i].IsConcreteStatus
                    & !casses[i].IsClosed)
                {
                    counter = casses[i].GetEnqueueCount;
                    minIndex = i;
                }
            }

            if (casses.Where(p => p.GetEnqueueCount == 0).Count() > 1)
            {
                maxIndex = casses.FindIndex(p => p.GetEnqueueCount == 0 && !p.IsConcreteStatus
                & !p.IsClosed);

                if (maxIndex > 0)
                {
                    return maxIndex;
                }
            }

            if (casses.FindAll(p => p.GetEnqueueCount == counter).Count > 1)
            {
                maxIndex = FindNearestIndex(casses, person);
            }

            if (maxIndex > 0 && !_casses[maxIndex].IsConcreteStatus
                & !_casses[maxIndex].IsClosed) return maxIndex;



            if (midIndex > 0 && !_casses[midIndex].IsConcreteStatus
                & !_casses[midIndex].IsClosed) return midIndex;

            if (minIndex > 0 && !_casses[minIndex].IsConcreteStatus
                & !_casses[minIndex].IsClosed) return minIndex;

            return default;
        }

        private int FindNearestIndex(List<Cassa> casses, Person person)
        {
            double counter = double.MaxValue;
            int tempIndex = default;

            string cass;
            string pers = person.Coordinate.ToString();
            pers = pers.Remove(0, pers.IndexOf(',') + 1);

            for (int i = 0; i < casses.Count; i++)
            {
                if (Math.Abs(casses[i].GetCordinate - person.Coordinate) < counter)
                {
                    cass = casses[i].GetCordinate.ToString();
                    cass = cass.Remove(0, cass.IndexOf(',') + 1);

                    if (casses[i].GetEnqueueCount < Constants.maxQuequeQuantity & cass == pers)
                    {
                        return i;
                    }
                    else
                    {
                        if (casses[i].GetEnqueueCount < Constants.maxQuequeQuantity)
                            tempIndex = i;
                    }
                }
            }

            if (_casses[tempIndex].IsConcreteStatus) return tempIndex;

            return tempIndex++;
        }

        private static void SendToResult(IWriterTinnedPersons writer, StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                writer.WritePerson(sb.ToString(0, sb.Length - "\r\n".Length));
                sb.Clear();
            }
        }

        private int AddToQueue(ref int counter)
        {
            int currentCassIndex;
            Console.WriteLine($"{_persons[counter]}");

            currentCassIndex = GetFreeNearestQueueIndex(_casses, _persons[counter]);

            if (_casses[currentCassIndex].Enqueue(_persons[counter++]))
            {
                if (QueueOverflowEvent is null) QueueOverflowEvent += Interviewer.ReprofilToSpecificStatus;

                if (QueueOverflowEvent.Invoke(_casses, out Status choiseStatus, out string choiseCassName
                    ).Equals(true))
                {
                    RebuildQueues(choiseStatus, choiseCassName);
                }

                counter--;
                _countAttempts++;

                if (_countAttempts == Constants.attemptsFullQuantity)
                {
                    _isStopRead = true;
                }
            }

            return currentCassIndex;
        }

        private static void DequeueFromQueue(StringBuilder sb, int number, Cassa item)
        {
            Console.WriteLine($"{item.Peek()}>> serviced at [Cassa#{number} {{{item}}}]");

            sb.Append($"[{DateTime.Now.ToShortTimeString()}]\t\t" +
                $"{item.Dequeue().ToStringWithoutServiceTime()}>> serviced at [{{{item.GetName} {{{item}}}]\r\n");
        }

        #endregion
    }
}
