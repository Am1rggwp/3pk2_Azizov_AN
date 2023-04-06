using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_9
{
    class Client
    {
        private Origin origin;

        public Client()
        {
            this.origin = new Origin();
        }

        public void ClientDouble(double value)
        {
            this.origin.OriginDouble(value);
        }

        public void ClientInt(int value)
        {
            this.origin.OriginInt(value * 2);
        }

        public void ClientChar(char value)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(value);
            }
            Console.WriteLine();
        }
    }
}
