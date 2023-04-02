using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace PZ_8
{
    class PhoneBook
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(string type, string name, string phone, string address)
        {
            Contact contact = ContactFactory.CreateContact(type);
            contact.Name = name;
            contact.PhoneNumber = phone;

            switch (type)
            {
                case "person":
                case "company":
                case "school":
                    ((dynamic)contact).Address = address;
                    break;
                default:
                    throw new ArgumentException($"Unknown contact type '{type}'");
            }

            contacts.Add(contact);
        }

        public void DisplayContacts()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.GetContactInfo());
                Console.WriteLine();
            }
        }
    }
}
