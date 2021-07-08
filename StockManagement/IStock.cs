using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    interface IStock
    {
        public void StockManage();
        public void CalculateEachValue();
        public void CalculateTotalValue();
        public void StockAccount(string fileName);
        public void Sell(int amount, string company);
        public void Buy(int amount, string company);
        public void SellStockAccount(List<AccountManager.Account> accountlist, string company, int amount);
        public void AddStockAccount(List<AccountManager.Account> accountlist, string company, int amount);
        public void DateAndTime();
    }
}
}
