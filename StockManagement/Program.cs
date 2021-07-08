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
            //getting path of json file
            string filePath = @"C:\Users\ven\source\repos\StockManagement\StockManagement\Jsonfile.json";
            string accountPath = @"C:\Users\ven\source\repos\StockManagement\StockManagement\Accountjsonfile.json";

            //Deserialize  the Json file
            StockUtility stockUtility = JsonConvert.DeserializeObject<StockUtility>(File.ReadAllText(filePath));
            AccountManager accountUtility = JsonConvert.DeserializeObject<AccountManager>(File.ReadAllText(accountPath));

            Console.WriteLine("Enter 1 to display stocks");
            var s = stockUtility.stocksList;

            switch (Console.ReadLine())
            {
                case "1":
                    StockUtility.StockManage(s);
                    break;



                    string flag = "Y";
                    while (flag == "Y")
                    {
                        Console.WriteLine("Please Enter :\n1-Display user account\n2-To buy a share\n3-To sell a share\n4-To Display Account report");
                        int ch = Convert.ToInt32(Console.ReadLine());
                        var u = accountUtility.AccountList;
                        switch (ch)
                        {
                            case 1:
                                StockUtility.StockAccount(accountPath);
                                break;
                            case 2:
                                Console.WriteLine("Enter amount: ");
                                int amount = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter company name in which you want to buy share: ");
                                string companyname = Console.ReadLine();
                                StockUtility.Buy(amount, companyname);
                                File.WriteAllText(accountPath, JsonConvert.SerializeObject(accountUtility));
                                break;
                            case 3:
                                Console.WriteLine("Enter amount: ");
                                int amount1 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter company name in which you want to sell share: ");
                                string companyname1 = Console.ReadLine();
                                StockUtility.Sell(amount1, companyname1);
                                File.WriteAllText(accountPath, JsonConvert.SerializeObject(accountUtility));
                                break;
                            case 4:
                                StockUtility.StockPurchased();
                                StockUtility.StockSold();
                                StockUtility.DateAndTime();
                                break;
                            default:
                                Console.WriteLine("Enter a valid option!!!");
                                break;
                        }
                    }
                    Console.WriteLine("\nDo you want to continue?(Y/N)");
                    Console.ReadLine();
            }
        }
    }

        }


