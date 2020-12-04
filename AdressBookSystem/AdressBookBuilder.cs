using System;
using System.Collections.Generic;
using System.Text;

namespace AdressBookSystem
{
    class AdressBookBuilder:IContacts
    {
        Dictionary<string,Contact>dictionaryKeyValuePairs;
        
        public AdressBookBuilder()
        {
            this.dictionaryKeyValuePairs = new Dictionary<string, Contact>();
        }
        
        public void addContact(String firstName, String lastName, String address, String city, String state, String zip, String phoneNumber, String email)
        {
            Contact contact = new Contact(firstName,lastName,address,city,state,zip,phoneNumber,email);
            dictionaryKeyValuePairs.Add(firstName, contact);
        }
        
        public void editContact(string firstName)
        {
            int flag = 1;
            foreach (KeyValuePair<string, Contact> dictionary in dictionaryKeyValuePairs)
            {
                if (firstName.Equals(dictionary.Key))
                {
                    flag = 0;
                    Console.WriteLine("Enter last name = ");
                    contact.lastName = Console.ReadLine();
                    Console.WriteLine("Enter address= ");
                    contact.address = Console.ReadLine();
                    Console.WriteLine("Enter city= ");
                    contact.city = Console.ReadLine();
                    Console.WriteLine("Enter state= ");
                    contact.state = Console.ReadLine();
                    Console.WriteLine("Enter zip= ");
                    contact.zip = Console.ReadLine();
                    Console.WriteLine("Enter phoneNumber= ");
                    contact.phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter email= ");
                    contact.email = Console.ReadLine();
                    break;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void deleteContact(string firstName)
        {
            int flag = 1;
            foreach (KeyValuePair<string,Contact>dictionary in dictionaryKeyValuePairs)
            {
                if (firstName.Equals(dictionary.Key))
                {
                    flag = 0;
                    dictionaryKeyValuePairs.Remove(firstName);

                    Console.WriteLine("Sucessfully deleted");
                    break;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void displayContact()
        {
            foreach(KeyValuePair<string, Contact> dictionary in dictionaryKeyValuePairs)
            {
                Console.WriteLine("\nFirst name = " + dictionary.Value.firstName);
                Console.WriteLine("Last name = " + dictionary.Value.lastName);
                Console.WriteLine("Address = " + dictionary.Value.address);
                Console.WriteLine("city = " + dictionary.Value.city);
                Console.WriteLine("state = " + dictionary.Value.state);
                Console.WriteLine("zip = " + dictionary.Value.zip);
                Console.WriteLine("phoneNumber = " + dictionary.Value.phoneNumber);
                Console.WriteLine("email = " + dictionary.Value.email);
            }
        }
    }
}
