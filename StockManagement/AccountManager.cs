using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    class AccountManager
    {
        public List<Account> AccountList { get; set; }

        public class Account
        {
            public string holderName { get; set; }
            public string BankName { get; set; }
            public int shares { get; set; }
            public int price { get; set; }
        }
    }
}
