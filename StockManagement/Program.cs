using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Console.WriteLine("1.Display the all stocks");
            Console.WriteLine("2.Calculating each share");
            Console.WriteLine("3.Calculating Total share");
            Console.WriteLine("Enter the Option!!!!");
            switch (Console.ReadLine())
            {
                case "1":
                    stock.StockManage();
                    break;
                case "2":
                    stock.CalculateEachValue();
                    break;
                case "3":
                    stock.CalculateTotalValue();
                    break;
                default:
                    Console.WriteLine("Enter the valid option");
                    break;
            }
        }
    }
}
