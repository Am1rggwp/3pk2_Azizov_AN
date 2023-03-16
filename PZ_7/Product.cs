using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_7
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual double GetDiscount(Client c)
        {
            if (c.AllPurchases > 1000)
            {
                return 0.10;
            }
            else if (
                c.AllPurchases > 30000)
            {
                return 0.25;
            }
            else if
                (c.AllPurchases > 70000)
            {
                return 0.55;
            }
            else
                return 1;
        }
    }
}

