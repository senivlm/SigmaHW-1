
using System.Collections.Generic;

namespace Task9
{
    internal static class MenuService
    {
        public static double courseUAHToUSD { get; private set; } = default;
        public static double courseUAHToEUR { get; private set; } = default;

        public static void SetCourseUAHToUSD(double value)
        {
            if (value > 0)
            {
                courseUAHToUSD = value;
            }
            //Теж лишня вітка
            else
            {
                return;
            }

        }

        public static void SetCourseUAHToEUR(double value)
        {
            if (value > 0)
            {
                courseUAHToEUR = value;
            }
            else
            {
                return;
            }

        }
// Прохання коментувати українською, або англійською.
        // общая сумма всего меню
        public static bool TryGetMenuTotalSum(Menu menu, PriceList priceList, out double menuTotalSum)
        {
            menuTotalSum = default;
            for (int i = 0; i < menu.Length; i++)
            {
                if (!TryGetDishPrice(menu[i], priceList, out double sumPrice))
                {
                    return false;
                }
                menuTotalSum += sumPrice;
            }
            return true;
        }

        // общая сумма каждого блюда
        public static bool TryGetDishPrice(Dish dish, PriceList priceList, out double sumPrice)
        {
            sumPrice = default;
            foreach (string key in dish.Keys)
            {
                if (!priceList.TryGetProductPrice(key, out double poductPrice))
                {
                    return false;
                }
                sumPrice += poductPrice * dish[key];
            }
            return true;

        }

        //вес каждого ингридиента
        public static bool TryGetMenuIngrOneIdientSumWeight(Menu menu, string ingridientName, out double weight)
        {
            if (menu == null || ingridientName == "")
            {
                weight = default;
                return false;
            }

            double totalWeight = default;

            for (int i = 0; i < menu.Length; i++)
            {
                if (menu[i].TryGetIngridientWeight(ingridientName, out weight))
                {
                    totalWeight += weight;
                }
            }
            weight = totalWeight;
            return true;
        }

        // общий вес всего меню
        public static bool TryGetMenuTotalWeight(Menu menu, out double menuTotalWeight)
        {
            double totalWeight = default;

            for (int i = 0; i < menu.Length; i++)
            {
                double result = default;
                foreach (var item in menu[i].Keys)
                {
                    menu[i].TryGetIngridientWeight(item, out result);
                    totalWeight += result;
                }
            }

            menuTotalWeight = totalWeight;
            return true;
        }

        // метод просчёта по весам всего меню итог сумма веса каждого товара
        public static string TryGetMenuTotalWeight(Menu menu, PriceList priceList)
        {
            Dictionary<string, (double, double)> temp = new Dictionary<string, (double, double)>();
            string result = default;
            for (int i = 0; i < menu.Length; i++)
            {
                double cost = default;
                double weight = default;
                foreach (var item in menu[i].Keys)
                {
                    menu[i].TryGetIngridientWeight(item, out weight);
                    priceList.TryGetProductPrice(item, out cost);
                    if (cost == 0) throw new PriceIngridientNotFound(item);
                    if (temp.ContainsKey(item))
                    {
                        double p = temp[item].Item1;
                        double w = temp[item].Item2;
                        temp[item] = (p + (CountPrice(cost, weight)), w + weight);
                    }
                    else
                    {
                        if (cost == 0) throw new PriceIngridientNotFound(item);
                        temp.Add(item, (CountPrice(cost, weight), weight));
                    }
                }

            }

            foreach (var item in temp)
            {
                result += $"Ingridient {item.Key,-10}: total sum = {item.Value.Item1,-5}" +
                    $" total weight = {item.Value.Item2,-8}\r\n";
            }

            return result;
        }

        private static double CountPrice(double cost, double weight)
        {// Константа 100 є залежною від прейскуранта.Бажано її винести з сервісу
            return (cost * weight) / 100;
        }
    }

}
