using System;
using System.Collections.Generic;
using System.Text;

namespace AdressBookSystem
{
    interface IContacts
    {
        public void addContact(String fName, String lName, String address, String city, String state, String zip, String phoneNumber, String email);
        public void editContact(string fName);
        public void deleteContact(string fName);
        public void displayContact();
    }
}
