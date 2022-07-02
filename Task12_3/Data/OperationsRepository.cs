using System.Reflection;
using System.Text;

namespace Task12_3
{
    internal class ProceduresRepository
    {
        private const string startBracket = "(";
        private const string endBracket = ")";
        private Dictionary<string, int> _proceduresPriorities;
        private Dictionary<string, operFunkHandler> _proceduresFunks;
        private Dictionary<string, string> _funks;

        public Dictionary<string, operFunkHandler> Data { get => _proceduresFunks; }

        public ProceduresRepository()
        {
            _proceduresFunks = new();
            _proceduresPriorities = new();
            _funks = new()
            {
                { "+", "Plus" },
                { "-", "Subtract" },
                { "/", "Division" },
                { "*", "Multiply" },
                { "%", "Reminder" },
                { "^", "Xor" },
                { "sin", "Sin" },
                { "cos", "Cos" }
            };
        }

        public ProceduresRepository(Dictionary<string, int> procedures)
        {
            _proceduresFunks = new();
            _proceduresPriorities = new(procedures);
            _funks = new()
            {
                { "+", "Plus" },
                { "-", "Subtract" },
                { "/", "Division" },
                { "*", "Multiply" },
                { "%", "Reminder" },
                { "^", "Xor" },
                { "sin", "Sin" },
                { "cos", "Cos" }
            };
        }

        public ProceduresRepository(Dictionary<string, int> procedures, Dictionary<string, string> funks)
        {
            _proceduresFunks = new();
            _proceduresPriorities = new(procedures);
            _funks = new(funks);
        }

        public bool IsContain(string expression)
        {
            return _proceduresPriorities.ContainsKey(expression);
        }

        public void Add(int priority, string procedure)
        {
            if (_proceduresPriorities.ContainsKey(procedure))
            {
                // TODO: event add to log list duplicate
                Console.WriteLine("event add to log list duplicate");
            }

            _proceduresPriorities.Add(procedure, priority);
        }

        public void Delete(string procedure)
        {
            if (_proceduresPriorities.ContainsKey(procedure))
            {
                _proceduresPriorities.Remove(procedure);
            }
        }

        public void ChangePriority(int newPriority, string procedure)
        {
            if (_proceduresPriorities.ContainsKey(procedure))
            {
                _proceduresPriorities[procedure] = newPriority;
            }
        }

        public int GetPriority(string procedure)
        {
            if (!_proceduresPriorities.ContainsKey(procedure))
            {
                return -1;
            }
            return _proceduresPriorities[procedure];
        }

        public string GetStartBracket()
        {
            return startBracket;
        }

        public string GetEndtBracket()
        {
            return endBracket;
        }

        public operFunkHandler GetFunction(string procedure)
        {
            if (!_proceduresFunks.ContainsKey(procedure))
            {
                throw new ArgumentException("need to Add this function");
            }

            return _proceduresFunks[procedure];
        }

        public double GetFunktion(string procedure, double a, double b)
        {
            Type myType = typeof(ActionOperationRepository);
            object[] args = new object[] { a, b };
            double result = default;

            foreach (MethodInfo method in myType.GetMethods(BindingFlags.Public
            | BindingFlags.Static))
            {
                if (method.ReturnType.Name == "Double" && _funks.ContainsKey("+") && method.Name.Equals(_funks[procedure]))
                {
                    object? temp = method?.Invoke(myType, parameters: args);

                    if (ObjToDouble(temp, out result))
                    {
                        return result;
                    }
                }
            }

            Console.WriteLine("\n Error! Funktion not found! \n");
            return 0.0;
        }

        private bool ObjToDouble(object response, out double result)
        {
            string? temp = response?.ToString();
            if (temp == null)
            {
                result = default;
                return false;
            }

            return double.TryParse(temp, out result);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _proceduresPriorities)
            {
                sb.Append(item.Key + " " + item.Value);
            }
            return sb.ToString();
        }
    }
}
