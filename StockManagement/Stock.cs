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
        StockUtility utility = JsonConvert.DeserializeObject<StockUtility>(File.ReadAllText(@"C:\Users\ven\source\repos\StockManagement\StockManagement\Jsonfile.json"));
        
        //To display all the stock records
        public void StockManage()
        {
            foreach (StockUtility.StocksRecords s in utility.Stock)

            {
                Console.WriteLine("\nName of the stock :" + s.Name + "\nTotal stocks of company : " + s.NumberOfShares + "\nStock price : " + s.Share);
            }
        }

        //To calculate the each share
        public void CalculateEachValue()
        {
            double val = 0, price = 0;
            int share = 0;
            for (int i = 0; i < utility.Stock.Count; i++)
            {
                var jsonObj = utility.Stock[i];
                price = jsonObj.Share;
                share = jsonObj.NumberOfShares;
                val = price * share;
                Console.WriteLine("Value of the particular stock " + jsonObj.Name + " is " + val + "\n");
            }
        }

        //To calculate Total share
        public void CalculateTotalValue()
        {
            double val = 0, price = 0, totalVal = 0;
            int share = 0;
            for (int i = 0; i < utility.Stock.Count; i++)
            {
                var jsonObj = utility.Stock[i];
                price = jsonObj.Share;
                share = jsonObj.NumberOfShares;
                val = price * share;
                totalVal += val;

            }
            Console.WriteLine("Total stock value is : " + totalVal);

        }
        public void StockAccount(string fileName)
        {
            utility = JsonConvert.DeserializeObject<StockUtility>(File.ReadAllText(@"C:\Users\ven\source\repos\StockManagement\StockManagement\Jsonfile.json"));
            StockManage();
        }
    }
}
