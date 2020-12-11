using System;
using System.Collections.Generic;
using System.Text;

namespace AdressBookSystem
{
    /// <summary>
    /// Interface with addContact,editContact,deleteContact,displayContact methods without body
    /// </summary>
    interface IContacts
    {
        public void addContact(String firstName, String lastName, String address, String city, String state, String zip, String phoneNumber, String email);
        public void editContact(string firstName);
        public void deleteContact(string firstName);
        public void displayContact();
    }
}
