using System;

namespace Task9.BLL
{
    internal class RunApp
    {
        FileLogger logger;
        Menu menu;
        PriceList priceList;

        public RunApp()
        {
            logger = new FileLogger();
            logger.UpdateCourse();
            menu = new Menu(logger.ReadMenu());
            priceList = new PriceList(logger.ReadPriceList());

        }

        public bool Run()
        {
            try
            {
                Console.WriteLine("Today menu list");
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine("-" + menu[i].Name.ToString());
                }

                double totalSum = default;
                MenuService.TryGetMenuTotalSum(menu, priceList, out totalSum);
                Console.WriteLine("Total price all menu: is [" + totalSum + "] UAH");

                double totalWeight = default;
                MenuService.TryGetMenuTotalWeight(menu, out totalWeight);
                Console.WriteLine("Total weight all menu: is [" + totalWeight + "] gramm");

                string fullInfo = MenuService.TryGetMenuTotalWeight(menu, priceList);
                Console.WriteLine(fullInfo);

                logger.WriteToResultinUAH(fullInfo, totalSum, totalWeight);

                Console.WriteLine("for reload click all button");
                Console.ReadKey();
                return false;
            }
            catch (PriceIngridientNotFound ex)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("input ingridirnt cost");
                    double input = default;
                    if (double.TryParse(Console.ReadLine(), out input))
                    {
                        logger.WriteToPriceList(ex.Message, input);
                        Run();
                    }
                    else
                    {
                        Console.WriteLine("incorrect");
                        continue;
                    }
                }
                Console.WriteLine("Attempts ended..adding ingredient failed...program ended");
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

    }
}
