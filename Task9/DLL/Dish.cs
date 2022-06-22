using System;
using System.Collections;
using System.Collections.Generic;


namespace Task9
{
    internal class Dish : IEnumerable
    {
        private string name;
        private Dictionary<string, double> _ingridients;

        public int Length => _ingridients.Count;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null) return;
                name = value;
            }
        }

        public Dish() => _ingridients = new Dictionary<string, double>();

        public Dish(string name)
        {
            this.name = name;
            _ingridients = new Dictionary<string, double>();
        }

        public Dish(string name, Dictionary<string, double> ingridients)
        {
            this.name = name;
            _ingridients = new Dictionary<string, double>();
            foreach (var item in ingridients)
            {
                _ingridients.Add(item.Key, item.Value);
            }

        }

        public void AddIngridient(string name, double weight)
        {
            if (_ingridients.ContainsKey(name))
            {
                throw new ArgumentException("this product is already on the list");
            }

            _ingridients.Add(name, weight);
        }

        public bool TryGetIngridientWeight(string name, out double weight)
        {
            if (name == null | !(_ingridients.ContainsKey(name)))
            {
                weight = default;
                return false;
            }
            _ingridients.TryGetValue(name, out weight);
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public double this[string key]
        {
            get
            {
                return _ingridients[key];
            }
        }

        public IEnumerable<string> Keys => _ingridients.Keys;

    }
}
