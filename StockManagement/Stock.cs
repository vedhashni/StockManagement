using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    class Stock : IStock
    {
        LinkedList<string> stockPurchased = new LinkedList<string>();
        LinkedList<string> stockSold = new LinkedList<string>();
        List<string> transactionTime = new List<string>();
        string filePath = @"C:\Users\ven\source\repos\StockManagement\StockManagement\Jsonfile.json";

        //To display all the stock records
        public void StockManage(LinkedList<StockUtility.Stock> stocksList)
        {
            int totalShare = 0, temporaryVal;

            foreach (var s in stocksList)
            {
                Console.WriteLine("Stock name is: {0} \nStock share is: {1} \nStock Price is: {2}", s.StockName, s.numOfShares, s.sharePrice);
                temporaryVal = s.numOfShares * s.sharePrice;
                totalShare += temporaryVal;
                Console.WriteLine("Total stock price for {0} is : {1}", s.StockName, temporaryVal);
            }
            Console.WriteLine("Total store is : " + totalShare);

        }

        public void DisplayAccount(List<AccountManager.Account> AccountList)
        {
            int totalShare = 0, temporaryVal;

            foreach (var a in AccountList)
            {
                Console.WriteLine("Stock holder {0}", a.holderName);
                Console.WriteLine("Stock name is: {0} \nStock share is: {1} \nStock Price is: {2}", a.BankName, a.shares, a.price);
                temporaryVal = a.shares * a.price;
                totalShare += temporaryVal;
                Console.WriteLine("Total stock price for {0} is : {1}", a.BankName, temporaryVal);
            }
            Console.WriteLine("Total share is : " + totalShare);

        }

        public void StockAccount(String acc)
        {

            AccountManager accountUtility = JsonConvert.DeserializeObject<AccountManager>(File.ReadAllText(acc));
            var u = accountUtility.AccountList;
            DisplayAccount(u);

        }
        public void Buy(int amount, string company)
        {
            string acc = @"C:\Users\ven\source\repos\StockManagement\StockManagement\Accountjsonfile.json";
            AccountManager accountUtility = JsonConvert.DeserializeObject<AccountManager>(File.ReadAllText(acc));
            var u = accountUtility.AccountList;
            AddStockAccount(u, company, amount);
            File.WriteAllText(acc, JsonConvert.SerializeObject(accountUtility));
            stockPurchased.AddLast("Company: " + company + " Amount: " + amount);
            DisplayAccount(u);
        }
        //Sell a stock
        public void Sell(int amount, string company)
        {
            string acc = @"C:\Users\ven\source\repos\StockManagement\StockManagement\Accountjsonfile.json";
            AccountManager accountUtility = JsonConvert.DeserializeObject<AccountManager>(File.ReadAllText(acc));
            var u = accountUtility.AccountList;
            SellStockAccount(u, company, amount);
            File.WriteAllText(acc, JsonConvert.SerializeObject(accountUtility));
            stockSold.AddLast("Company: " + company + " Amount: " + amount);
            DisplayAccount(u);
        }
        //SellStockAccount Method
        public void SellStockAccount(List<AccountManager.Account> accountlist, string company, int amount)
        {
            string filePath = @"C:\Users\ven\source\repos\StockManagement\StockManagement\Jsonfile.json";
            string acc = @"C:\Users\ven\source\repos\StockManagement\StockManagement\Accountjsonfile.json";
            AccountManager accountUtility = JsonConvert.DeserializeObject<AccountManager>(File.ReadAllText(acc));
            StockUtility stockUtility = JsonConvert.DeserializeObject<StockUtility>(File.ReadAllText(filePath));
            var s = StockUtility.Stock;

            foreach (var stockavail in s)
            {
                if (stockavail.BankName == company && stockavail.numberOfShares >= 0)
                {
                    foreach (var member in accountlist)
                    {

                        Account account1 = new Account();

                        if (member.BankName == company)
                        {

                            Console.WriteLine("\nEnter the stock holder: ");
                            account1.holderName = Console.ReadLine();
                            account1.BankName = company;
                            account1.shares = member.shares - 1;
                            account1.price = amount;
                            accountlist.Remove(member);
                            stockavail.numOfShares += 1;
                            accountlist.Add(account1);
                            File.WriteAllText(filePath, JsonConvert.SerializeObject(stockUtility));
                            DateTime time = DateTime.Now;
                            Console.WriteLine("Sold the Share at: " + time);
                            transactionTime.Add("Sold compant " + company + " at time " + Convert.ToString(time));

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Stocks not available");
                        }
                    }
                }
            }

        }
        //AddStockAccount Method
        public void AddStockAccount(List<AccountManager.Account> accountlist, string company, int amount)
        {
            if (stockavail.StockName == company && stockavail.numOfShares >= 1)
            {
                foreach (var member in accountlist.ToList())
                {

                    Account account1 = new Account();

                    if (member.BankName == company)
                    {

                        Console.WriteLine("\nEnter the stock holder: ");
                        account1.holderName = Console.ReadLine();
                        account1.BankName = company;
                        account1.shares = member.shares + 1;
                        account1.price = amount;
                        accountlist.Remove(member);
                        stockavail.numOfShares -= 1;
                        accountlist.Add(account1);
                        File.WriteAllText(filePath, JsonConvert.SerializeObject(stockUtility));
                        DateTime time = DateTime.Now;
                        Console.WriteLine("Bought the Share at: " + time);
                        transactionTime.Add("Bought company " + company + " at time " + Convert.ToString(time));

                    }
                }
            }

            Console.WriteLine("Total stock value is : " + totalVal);
        }

        //date and time of transaction using list
        public void DateAndTime()
        {
            Console.WriteLine("---------------The Date and Time of transactions occured-----------------");
            foreach (var t in transactionTime)
            {
                Console.WriteLine(t);
            }
        }

        public void StockPurchased()
        {
            Console.WriteLine("\n**List of stock purchased**\n");
            foreach (var t in stockPurchased)
            {
                Console.WriteLine(t);
            }
        }
        public void StockSold()
        {
            foreach (var t in stockSold)
            {
                Console.WriteLine(t);
            }

        }
    }
}
    

