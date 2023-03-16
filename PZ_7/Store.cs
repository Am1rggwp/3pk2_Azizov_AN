using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_7
{
    internal class Store
    {
        public string AllPurshares { get; set; }
        public void SaveOrder(Client c, Product[] pro)
        {
            AllPurshares += $"\nКлиент {c.Name}\nПокупка:";
           
            foreach (Product p in pro)
            {
                AllPurshares += p.Name + ' ';
                c.AllPurchases += p.Price * p.GetDiscount(c);
            }
        }
    }
}
