using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_8
{
    class Company : Contact
    {
        public string Address { get; set; }

        public override string GetContactInfo()
        {
            return $"{Name}\n{Address}\n{PhoneNumber}";
        }
    }
}
