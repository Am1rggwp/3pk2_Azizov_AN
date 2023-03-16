using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_7
{
    internal class Motherboard:Product
    {
        public string Socket { get; set; }
        public string Size { get; set; }
        public override double GetDiscount(Client c)
        {
            return base.GetDiscount(c) + 0.1;
        }
    }
}
