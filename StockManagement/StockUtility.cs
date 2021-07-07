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


        public class StocksRecords
        {
            public string Name { get; set; }
            public int NumberOfShares { get; set; }

            public int Share { get; set; }

        }
    }
}
