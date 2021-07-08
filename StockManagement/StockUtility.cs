using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    class StockUtility
    {
        public List<StocksRecords> Stock { get; set; }
        //public List<Account> account { get; set; }

        public class StocksRecords
        {
            /*public string Name { get; set; }
            public int NumberOfShares { get; set; }

            public int Share { get; set; }*/

        
        internal class Account
        {
            public string AccountName { get; set; }
                public string BankName { get; set; }
                public int numberOfShares { get; set; }
                public int sharePrice { get; set; }
            }
    }

    
}
}
