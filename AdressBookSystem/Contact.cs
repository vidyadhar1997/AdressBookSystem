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
        /// <summary>
        /// Parameterized constructor initializes a new instance of the contact class <see cref="Contact"/> class.
        /// </summary>
        /// <param name="firstName">The first name of person</param>
        /// <param name="lastName">The last name of person</param>
        /// <param name="address">The address of person</param>
        /// <param name="city">The city of person</param>
        /// <param name="state">The state of person</param>
        /// <param name="zip">The zip code of person</param>
        /// <param name="phoneNumber">The phone number of person</param>
        /// <param name="email">The email.</param>
        public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
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

        /// <summary>
        /// To the string for return contacts details
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Console.WriteLine("Contacts After sorting by first name = ");
            return  "\n FirstName = " + firstName + "\n Last Name = " + lastName + "\n Address = " + address + "\n City = " + city + "\n State = " + state + "\n Zip = " + zip + "\n Phone Number = " + phoneNumber + "\n Email = " + email;
        }
    }
}

