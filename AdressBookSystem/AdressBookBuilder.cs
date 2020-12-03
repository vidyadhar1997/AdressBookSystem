using System;
using System.Collections.Generic;
using System.Text;

namespace AdressBookSystem
{
    class AdressBookBuilder
    {
        public List<Contact> contactList;
        public AdressBookBuilder()
        {
            this.contactList = new List<Contact>();
        }
        public void AddContact(String fName, String lName, String address, String city, String state, String zip, String phoneNumber, String email)
        {
            Contact contact = new Contact(fName,lName,address,city,state,zip,phoneNumber,email);
            contactList.Add(contact);
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
