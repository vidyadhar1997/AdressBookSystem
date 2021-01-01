using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdressBookSystem
{
    public class AdressBookBuilder : IContacts
    {
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = AddressBook; Integrated Security = True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        /// <summary>
        /// Checks the connection.
        /// </summary>
        public void checkConnection()
        {
            try
            {
                this.sqlConnection.Open();
                Console.WriteLine("connection established");
                this.sqlConnection.Close();
            }
            catch
            {
                Console.WriteLine("not established");
            }
        }

        public List<Contact> contactList;

        /// <summary>
        /// Initializes a new instance of the list <see cref="AdressBookBuilder"/> class.
        /// </summary>
        public AdressBookBuilder()
        {
            this.contactList = new List<Contact>();
        }

        /// <summary>
        /// Adds the contact but contact is not be duplicated
        /// </summary>
        /// <param name="firstName">The first name of person</param>
        /// <param name="lastName">The last name of person</param>
        /// <param name="address">The address of person</param>
        /// <param name="city">The city of person</param>
        /// <param name="state">The state of person</param>
        /// <param name="zip">The zip code of person</param>
        /// <param name="phoneNumber">The phone number of person</param>
        /// <param name="email">The email of person</param>
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            bool duplicate = equals(firstName);
            if (!duplicate)
            {
                Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                contactList.Add(contact);
            }
            else
            {
                Console.WriteLine("Cannot add duplicate contacts when you give first name same");
            }
        }

        /// <summary>
        /// Equalses the specified first name for duplicate name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        private bool equals(string firstName)
        {
            if (this.contactList.Any(e => e.firstName == firstName))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Edits the contact with the help of first name of person
        /// </summary>
        /// <param name="firstName">The first nameof person</param>
        public void editContact(string firstName)
        {
            int flag = 1;
            foreach (Contact contact in contactList)
            {
                if (firstName.Equals(contact.firstName))
                {
                    flag = 0;
                    Console.WriteLine("Enter last name = ");
                    contact.lastName = Console.ReadLine();
                    Console.WriteLine("Enter address= ");
                    contact.address = Console.ReadLine();
                    Console.WriteLine("Enter city= ");
                    contact.city = Console.ReadLine();
                    Console.WriteLine("Enter state= ");
                    contact.state = Console.ReadLine();
                    Console.WriteLine("Enter zip= ");
                    contact.zip = Console.ReadLine();
                    Console.WriteLine("Enter phoneNumber= ");
                    contact.phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter email= ");
                    contact.email = Console.ReadLine();
                    break;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("Contact not found");
            }
        }

        /// <summary>
        /// Deletes the contact of person with the help of first name
        /// </summary>
        /// <param name="firstName">The first name of person</param>
        public void deleteContact(string firstName)
        {
            int flag = 1;
            foreach (Contact contact in contactList)
            {
                if (firstName.Equals(contact.firstName))
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

        /// <summary>
        /// Displays the contact of persons
        /// </summary>
        public void displayContact()
        {
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\nFirst name = " + contact.firstName);
                Console.WriteLine("Last name = " + contact.lastName);
                Console.WriteLine("Address = " + contact.address);
                Console.WriteLine("city = " + contact.city);
                Console.WriteLine("state = " + contact.state);
                Console.WriteLine("zip = " + contact.zip);
                Console.WriteLine("phoneNumber = " + contact.phoneNumber);
                Console.WriteLine("email = " + contact.email);
            }
        }

        /// <summary>
        /// Find  the persons by place ie state or city.
        /// </summary>
        /// <param name="place">The place.</param>
        /// <returns>person information</returns>
        public List<string> findPersons(string place)
        {
            List<string> personFounded = new List<string>();
            foreach (Contact contacts in contactList.FindAll(e => (e.city.Equals(place))).ToList())
            {
                string name = contacts.firstName + " " + contacts.lastName;
                personFounded.Add(name);
            }
            if (personFounded.Count == 0)
            {
                foreach (Contact contacts in contactList.FindAll(e => (e.state.Equals(place))).ToList())
                {
                    string name = contacts.firstName + " " + contacts.lastName;
                    personFounded.Add(name);
                }
            }
            return personFounded;
        }

        /// <summary>
        /// Sort methode for sort entites in adress book.
        /// </summary>
        public void sortByFirstName()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.firstName, b.firstName)));
            Console.WriteLine("Contacts after sorting By City = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

        /// <summary>
        /// Sort methode for sort entites in adress book by city.
        /// </summary>
        public void sortByCity()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.city, b.city)));
            Console.WriteLine("Contacts after sorting By City = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

        /// <summary>
        /// Sort methode for sort entites in adress book by state.
        /// </summary>
        public void sortByState()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.state, b.state)));
            Console.WriteLine("Contacts after sorting By State = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

        /// <summary>
        /// Sort methode for sort entites in adress book by zip.
        /// </summary>
        public void sortByZip()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.zip, b.zip)));
            Console.WriteLine("Contacts after sorting By Zip = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

        /// <summary>
        /// Writes the in text file.
        /// </summary>
        public void writeInTxtFile()
        {
            FileReadWrite.writeInTxtFile(contactList);
        }

        /// <summary>
        /// Reads from text file.
        /// </summary>
        public void readFromTxtFile()
        {
            FileReadWrite.readFromTxtFile();
        }

        /// <summary>
        /// Writes the in CSV file.
        /// </summary>
        public void writeInCSVFile()
        {
            FileReadWrite.writeIntoCsvFile(contactList);
        }

        /// <summary>
        /// Reads from CSV file.
        /// </summary>
        public void readFromCSVFile()
        {
            FileReadWrite.readFromCSVFile();
        }

        /// <summary>
        /// Writes the in JSON file.
        /// </summary>
        public void writeInJSONFile()
        {
            FileReadWrite.writeIntoJSONFile(contactList);
        }

        /// <summary>
        /// Reads from JSON file.
        /// </summary>
        public void readFromJSONFile()
        {
            FileReadWrite.readFromJSONFile();
        }

        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getAllEmployee()
        {
            try
            {
                int count = 0;
                Contact contact = new Contact();
                using (this.sqlConnection)
                {
                    this.sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllEmployee", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count++;
                            contact.firstName = sqlDataReader.GetString(0);
                            contact.lastName = sqlDataReader.GetString(1);
                            contact.address = sqlDataReader.GetString(2);
                            contact.city = sqlDataReader.GetString(3);
                            contact.state = sqlDataReader.GetString(4);
                            contact.zip = sqlDataReader.GetString(5);
                            contact.phoneNumber = sqlDataReader.GetString(6);
                            contact.email = sqlDataReader.GetString(7);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", contact.firstName, contact.lastName, contact.address, contact.city, contact.state, contact.zip, contact.phoneNumber, contact.email);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return count;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        /// <summary>
        /// Updates the exi contact to data base.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool UpdateExiContactToDataBase(Contact contact, string firstName)
        {
            try
            {
                using (this.sqlConnection)
                {
                    string query = @"update AddressBook set lastName=@lastName,address=@address,city=@city,
                    state=@state,zip=@zip,phoneNumber=@phoneNumber,email=@email where firstName=@firstName";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", contact.lastName);
                    cmd.Parameters.AddWithValue("@address", contact.address);
                    cmd.Parameters.AddWithValue("@city", contact.city);
                    cmd.Parameters.AddWithValue("@state", contact.state);
                    cmd.Parameters.AddWithValue("@zip", contact.zip);
                    cmd.Parameters.AddWithValue("@phoneNumber", contact.phoneNumber);
                    cmd.Parameters.AddWithValue("@email", contact.email);
                    this.sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
       
        /// <summary>
        /// Gets all employee in particular period.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getAllEmployeeInParticularPeriod()
        {
            try
            {
                int count = 0;
                Contact contact = new Contact();
                using (this.sqlConnection)
                {
                    this.sqlConnection.Open();
                    string query = @"select * from AddressBook where start_date between CAST('2018-01-01' as date) and GETDATE();";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count++;
                            contact.firstName = sqlDataReader.GetString(0);
                            contact.lastName = sqlDataReader.GetString(1);
                            contact.address = sqlDataReader.GetString(2);
                            contact.city = sqlDataReader.GetString(3);
                            contact.state = sqlDataReader.GetString(4);
                            contact.zip = sqlDataReader.GetString(5);
                            contact.phoneNumber = sqlDataReader.GetString(6);
                            contact.email = sqlDataReader.GetString(7);
                            contact.start_date = sqlDataReader.GetDateTime(8);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", contact.firstName, contact.lastName, contact.address, contact.city, contact.state, contact.zip, contact.phoneNumber, contact.email,contact.start_date);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return count;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        /// <summary>
        /// Persons the state of the belonging city or state.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public int personBelongingCityOrState()
        {
            try
            {
                int count = 0;
                Contact contact = new Contact();
                using (this.sqlConnection)
                {
                    string query = @"select * from AddressBook where city='amravati' Or state='maha';";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count++;
                            contact.firstName = sqlDataReader.GetString(0);
                            contact.lastName = sqlDataReader.GetString(1);
                            contact.address = sqlDataReader.GetString(2);
                            contact.city = sqlDataReader.GetString(3);
                            contact.state = sqlDataReader.GetString(4);
                            contact.zip = sqlDataReader.GetString(5);
                            contact.phoneNumber = sqlDataReader.GetString(6);
                            contact.email = sqlDataReader.GetString(7);
                            contact.start_date = sqlDataReader.GetDateTime(8);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", contact.firstName, contact.lastName, contact.address, contact.city, contact.state, contact.zip, contact.phoneNumber, contact.email, contact.start_date);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return count;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        
        /// <summary>
        /// Adds the new contact in database.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool addNewContactInDb(Contact contact)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddAddressBookDetails", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstName", contact.firstName);
                    cmd.Parameters.AddWithValue("@lastName", contact.lastName);
                    cmd.Parameters.AddWithValue("@address", contact.address);
                    cmd.Parameters.AddWithValue("@city", contact.city);
                    cmd.Parameters.AddWithValue("@state", contact.state);
                    cmd.Parameters.AddWithValue("@zip", contact.zip);
                    cmd.Parameters.AddWithValue("@phoneNumber", contact.phoneNumber);
                    cmd.Parameters.AddWithValue("@email", contact.email);
                    cmd.Parameters.AddWithValue("@start_date", contact.start_date);
                    this.sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}