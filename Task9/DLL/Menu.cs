using System.Collections.Generic;

namespace Task9
{
    internal class Menu
    {
        private List<Dish> _dishes;

        public int Length => _dishes.Count;

        public Menu() => _dishes = new List<Dish>();

        public Menu(List<Dish> dishes)
        {
            _dishes = new List<Dish>();
            foreach (var item in dishes)
            {
                _dishes.Add(item);
            }
        }

        public Dish this[int index]
        {
            get => _dishes[index];
        }

        public void AddDish(Dish dish)
        {
            _dishes.Add(dish);
        }

        public override string ToString()
        {
            string result = default;
            foreach (var item in _dishes)
            {
                result += item.Name;
            }

            return result;
        }

    }
}
