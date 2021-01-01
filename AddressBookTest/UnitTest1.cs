using AdressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens the employee payroll when retrieve then return employee payroll from data base.
        /// </summary>
        [TestMethod]
        public void GivenAddressBook_WhenRetrieve_ThenShouldReturnAddressDataBase()
        {
            int expected = 2;
            AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
            int count = adressBookBuilder.getAllEmployee();
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Givens the address books when enter first name then should update contact in address book.
        /// </summary>
        [TestMethod]
        public void GivenAddressBooks_WhenEnterFirstName_ThenShouldUpdateContactInAddressBook()
        {
            bool expected = true;
            AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
            Contact contact = new Contact();
            contact.lastName = "hudge";
            contact.address = "karve negar";
            contact.city = "pune";
            contact.state = "maha";
            contact.zip = "413512";
            contact.phoneNumber = "9607610044";
            contact.email = "kajolp@123";
            bool result=adressBookBuilder.UpdateExiContactToDataBase(contact, "suraj");
            Assert.AreEqual(expected, result);
        }
        
        /// <summary>
        /// Givens the address book in particular range when retrieve then should return address book data base.
        /// </summary>
        [TestMethod]
        public void GivenAddressBookInParticularRange_WhenRetrieve_ThenShouldReturnAddressBookDataBase()
        {
            int expected = 2;
            AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
            int countofContacts = adressBookBuilder.getAllEmployeeInParticularPeriod();
            Assert.AreEqual(expected, countofContacts);
        }
        
        /// <summary>
        /// Givens the address book when city or state then should return counto f contacts in address book data base.
        /// </summary>
        [TestMethod]
        public void GivenAddressBook_WhenCityOrState_ThenShouldReturnCountoFContactsInAddressBookDataBase()
        {
            int expected = 2;
            AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
            int countofContacts = adressBookBuilder.personBelongingCityOrState();
            Assert.AreEqual(expected, countofContacts);
        }
        
        /// <summary>
        /// Givens the address books when insert contacts then should inserted in database.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void GivenAddressBooks_WhenInsertContacts_ThenShouldInsertedInDb()
        {
            bool expected = true;
            AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
            Contact contact = new Contact();
            contact.firstName = "Kaji";
            contact.lastName = "paw";
            contact.address = "karve";
            contact.city = "pune";
            contact.state = "maha";
            contact.zip = "413512";
            contact.phoneNumber = "9607610044";
            contact.email = "kajolp@123";
            contact.start_date = new System.DateTime(2016, 01, 01);
            bool result = adressBookBuilder.addNewContactInDb(contact);
            Assert.AreEqual(expected, result);
        }
    }
}
