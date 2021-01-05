using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdressBookSystem
{
    public class AddressBookOperation
    {
        public List<Contact> contactsList = new List<Contact>();

        /// <summary>
        /// Adds the employee to payroll.
        /// </summary>
        /// <param name="employeelist">The employeelist.</param>
        public void addContactToPayroll(List<Contact> employeelist)
        {
            employeelist.ForEach(contactData =>
            {
                Console.WriteLine("Employee being added = " + contactData.firstName);
                this.addContactPayroll(contactData);
                Console.WriteLine("Employee added =" + contactData.firstName);
            });
            Console.WriteLine(this.contactsList.ToString());
        }

        /// <summary>
        /// Adds the employee to payroll.
        /// </summary>
        /// <param name="employeeData">The employee data.</param>
        public void addContactPayroll(Contact contactData)
        {
            contactsList.Add(contactData);

        }
        
        /// <summary>
        /// Add the contacts to address book with thread.
        /// </summary>
        /// <param name="contactsList">The contacts list.</param>
        public void addContactToPayrollWithThread(List<Contact> contactsList)
        {
            contactsList.ForEach(contactData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added = " + contactData.firstName);
                    this.addContactPayroll(contactData);
                    Console.WriteLine("Employee added =" + contactData.firstName);
                });

                thread.Start();
            });
            Console.WriteLine(this.contactsList.Count);
        }
    }
}

