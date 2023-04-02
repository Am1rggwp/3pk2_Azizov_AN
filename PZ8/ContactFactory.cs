using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_8
{
    class ContactFactory
    {
        public static Contact CreateContact(string type)
        {
            switch (type)
            {
                case "person":
                    return new Person();
                case "company":
                    return new Company();
                case "school":
                    return new School();
                default:
                    throw new ArgumentException($"Unknown contact type '{type}'");
            }
        }
    }

}
