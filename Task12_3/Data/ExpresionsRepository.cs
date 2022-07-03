using System.Text;

namespace Task12_3.Data
{
    internal class ExpresionsRepository
    {
        private List<string> _expresions;

        public ExpresionsRepository()
        {
            _expresions = new();
        }

        public ExpresionsRepository(List<string> expresions)
        {
            _expresions?.AddRange(expresions);
        }

        public void Add(string expression)
        {
            _expresions?.Add(expression);
        }

        public void AddRange(List<string> expresions)
        {
            _expresions?.AddRange(expresions);
        }

        public void Remove(string expression)
        {
            if (_expresions.Contains(expression))
            {
                _expresions?.Remove(expression);
            }
        }

        public string GetFirst()
        {
            if (_expresions.Count == 0) return "NaN";
            return _expresions[0];
        }

        public string TakeFirst()
        {
            if (_expresions.Count == 0) return "NaN";

            var first = _expresions[0];
            _expresions.Remove(first);
            return first;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var item in _expresions)
            {
                sb.Append("[" + item + "]\n");
            }
            return sb.ToString();
        }
    }
}
