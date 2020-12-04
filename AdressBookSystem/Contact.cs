using System;
using System.Collections.Generic;
using System.Text;

namespace AdressBookSystem
{
    class Contact
    {
        public String firstName;
        public String lastName;
        public String address;
        public String city;
        public String state;
        public String zip;
        public String phoneNumber;
        public String email;

        public Contact(String firstName, String lastName, String address, String city, String state, String zip, String phoneNumber, String email)
<<<<<<< HEAD
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        /*public Contact(String fName, String lName, String address, String city, String state, String zip, String phoneNumber, String email)
=======
>>>>>>> UC6-RefactorToAddMultipleAdressBook
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
<<<<<<< HEAD
        }*/

=======
        }
       
>>>>>>> UC6-RefactorToAddMultipleAdressBook
        public string toString()
        {
            return "first Name=" + firstName + ",last name=" + lastName + ",address="
            + address + ",city=" + city + ",state=" + state + ",zip" +
            zip + ",phone number=" + phoneNumber + "email=" + email;
        }
    }
}

