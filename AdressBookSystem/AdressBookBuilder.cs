using System;
using System.Collections.Generic;
using System.Text;

namespace AdressBookSystem
{
    class AdressBookBuilder:IContacts
    {
        public List<Contact> contactList;
        public AdressBookBuilder()
        {
            this.contactList = new List<Contact>();
        }
        
        public void addContact(String fName, String lName, String address, String city, String state, String zip, String phoneNumber, String email)
        {
            Contact contact = new Contact(fName,lName,address,city,state,zip,phoneNumber,email);
            contactList.Add(contact);
        }
        
        public void editContact(string fName)
        {

            int flag = 1;
            foreach (Contact contact in contactList)
            {
                if (fName.Equals(contact.fName))
                {
                    flag = 0;
                    Console.WriteLine("Enter last name = ");
                    string lName = Console.ReadLine();
                    Console.WriteLine("Enter address= ");
                    String address = Console.ReadLine();
                    Console.WriteLine("Enter city= ");
                    String city = Console.ReadLine();
                    Console.WriteLine("Enter state= ");
                    String state = Console.ReadLine();
                    Console.WriteLine("Enter zip= ");
                    String zip = Console.ReadLine();
                    Console.WriteLine("Enter phoneNumber= ");
                    String phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter email= ");
                    String email = Console.ReadLine();
                    break;
                }

            }
            if (flag == 1)
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void deleteContact(string fName)
        {
            int flag = 1;
            foreach (Contact contact in contactList)
            {
                if (fName.Equals(contact.fName))
                {
                    flag = 0;
                    contactList.Remove(contact);
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
            foreach(Contact contact in contactList)
            {
                Console.WriteLine("\nFirst name = " + contact.fName);
                Console.WriteLine("Last name = " + contact.lName);
                Console.WriteLine("Address = " + contact.address);
                Console.WriteLine("city = " + contact.city);
                Console.WriteLine("state = " + contact.state);
                Console.WriteLine("zip = " + contact.zip);
                Console.WriteLine("phoneNumber = " + contact.phoneNumber);
                Console.WriteLine("email = " + contact.email);

            }
        }
    }
}
