using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_11
{
    class Book
    {
        public string NameBook { get; set; }
        public string YearIssue { get; set; }
        public string Auvtor { get; set; }
        

        public Book(string name, string years, string auvtor)
        {
            NameBook = name; YearIssue = years; Auvtor = auvtor;
        }

    }
}
