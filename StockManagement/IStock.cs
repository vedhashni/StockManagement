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
    }
}
}
