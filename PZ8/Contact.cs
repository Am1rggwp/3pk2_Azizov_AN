﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_8
{
    abstract class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public abstract string GetContactInfo();
    }
   

}
