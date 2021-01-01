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
    }
}
