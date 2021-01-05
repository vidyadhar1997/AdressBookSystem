using AdressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookTest
{
    [TestClass]
    public class AddressBookForThreadingTest
    {
        /// <summary>
        /// given list and db when insert for address book then calculate execution time
        /// </summary>
        [TestMethod]
        public void givenListAndDbforAddressBook_WhenInsert_ThenCalculateExacutionTime()
        {
            List<Contact> contactllist = new List<Contact>();
            contactllist.Add(new Contact() { firstName = "dhiraj", lastName = "hudge", address = "tawarja", city = "latur", state = "maha",zip="413512",phoneNumber = "823440009",email="dghity@gmail.com",start_date = new DateTime(2018, 01, 04)});
            contactllist.Add(new Contact() { firstName = "suraj", lastName = "pawar", address = "mataji", city = "pune", state = "kar", zip = "413512", phoneNumber = "823440009", email = "auraj@gmail.com", start_date = new DateTime(2020, 01, 04) });
            contactllist.Add(new Contact() { firstName = "rahul", lastName = "kumar", address = "gandhi chiowk", city = "mumbai", state = "mp", zip = "413512", phoneNumber = "823440009", email = "dghity@gmail.com", start_date = new DateTime(2019, 01, 04)});
            contactllist.Add(new Contact() { firstName = "raj", lastName = "pan", address = "adarsh colony", city = "delhi", state = "maha", zip = "413512", phoneNumber = "823440009", email = "dghity@gmail.com", start_date = new DateTime(2020, 02, 04)});
            contactllist.Add(new Contact() { firstName = "klumar", lastName = "paliya", address = "shivaji chowk", city = "hariytana", state = "maha", zip = "413512", phoneNumber = "823440009", email = "dghity@gmail.com", start_date = new DateTime(2020, 01, 05)});

            AddressBookOperation addressBookOperation = new AddressBookOperation();
            DateTime startTime = DateTime.Now;
            addressBookOperation.addContactToPayroll(contactllist);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Durations without the thread = " + (endTime - startTime));
            AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
            Contact contact = new Contact
            {
                firstName="suraj",
                lastName="hudge",
                address="nandi stop",
                city="latur",
                state="maharashtra",
                zip="413512",
                phoneNumber="8147713169",
                email="dhiruh@gmaqil.com",
                start_date=new DateTime(2018,01,01)
            };
            DateTime startTimeForDb = DateTime.Now;
            adressBookBuilder.addNewContactInDb(contact);
            DateTime endTimeForDb = DateTime.Now;
            Console.WriteLine("Durations without the thread = " + (startTimeForDb - endTimeForDb));

            DateTime startTimeWithThread = DateTime.Now;
            addressBookOperation.addContactToPayrollWithThread(contactllist);
            DateTime endTimeWithThread = DateTime.Now;
            Console.WriteLine("Durations with the thread = " + (startTimeWithThread - endTimeWithThread));
        }
    }
}
