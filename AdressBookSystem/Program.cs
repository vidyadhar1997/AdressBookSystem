using System;
using System.Collections.Generic;

namespace AdressBookSystem
{
    class Program
    {
        /// <summary>
        /// in main methode we added multiple adress book and display that adress book which we added,passes AdressBookBuilder class
        /// for add,edit,delete,display contacts of person in both the adress book with the help of dictionary
        /// as per user requirments
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To  Book System!");
            Dictionary<string, AdressBookBuilder> adressBookDictionary = new Dictionary<string, AdressBookBuilder>();
            Dictionary < string,List<string>> cityDisc = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> StateDisc = new Dictionary<string, List<string>>();
            while (true)
            {
                try
                {
                    Console.WriteLine("How many adress book you want = ");
                    int numOfAdressBook = Convert.ToInt32(Console.ReadLine());
                    for (int i = 1; i <= numOfAdressBook; i++)
                    {
                        Console.WriteLine("Enter the name of adress book = " + i + "=");
                        String adressBookName = Console.ReadLine();
                        AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
                        adressBookDictionary.Add(adressBookName, adressBookBuilder);
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter integer number,\n string is not allowes \n enter unique name for book \n duplicate name not allowed");
                }
            }
                    
            while (true)
            {
                try
                {
                    Console.WriteLine("You have created following adress book");
                    foreach (string k in adressBookDictionary.Keys)
                    {
                        Console.WriteLine(k);
                    }
                    Console.WriteLine("\n 1 for Add Contact \n 2 for Edit Existing Contact \n 3 for delete the person,\n 4 for display,\n 5 for Enter city or state ,\n 6 for exit");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("Enter the Adress book name where you want to add contact");
                            string addContactInAdressBook=Console.ReadLine();
                            if (adressBookDictionary.ContainsKey(addContactInAdressBook))
                            {
                                Console.WriteLine("Enter how many contact you want to add");
                                int numOfContact=Convert.ToInt32(Console.ReadLine());
                                for(int i=1;i<= numOfContact; i++)
                                {
                                    takeInputAndAddToContact(adressBookDictionary[addContactInAdressBook]);
                                }
                                adressBookDictionary[addContactInAdressBook].displayContact();
                            }
                            else
                            {
                                Console.WriteLine("No adress book found ", addContactInAdressBook);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the Adress book name where you want to edit contact = ");
                            string editContactInAdressBook = Console.ReadLine();
                            if (adressBookDictionary.ContainsKey(editContactInAdressBook))
                            {
                                Console.WriteLine("Enter first name to edit contact =");
                                String firstNameForEditContact = Console.ReadLine();
                                adressBookDictionary[editContactInAdressBook].editContact(firstNameForEditContact);
                                adressBookDictionary[editContactInAdressBook].displayContact();
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter the Adress book name where you want to delete contact = ");
                            string deleteContactInAdressBook = Console.ReadLine();
                            if (adressBookDictionary.ContainsKey(deleteContactInAdressBook))
                            {
                                Console.WriteLine("Enter first name to delete contact =");
                                String firstNameForDeleteContact = Console.ReadLine();
                                adressBookDictionary[deleteContactInAdressBook].deleteContact(firstNameForDeleteContact);
                                adressBookDictionary[deleteContactInAdressBook].displayContact();
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter the Adress book name to display contact = ");
                            String displayContactInAdressBook=Console.ReadLine();
                            adressBookDictionary[displayContactInAdressBook].displayContact();
                            break;
                        case 5:
                            Console.WriteLine("Enter 1 for city 2 for state ");
                            String area = Console.ReadLine();
                            if (area.Contains("1"))
                            {
                                cityDisc =  FindByCityOrState( adressBookDictionary, cityDisc);
                                displayPersonDisc(cityDisc);
                            }
                            else
                            {
                                StateDisc =  FindByCityOrState( adressBookDictionary, StateDisc);
                                displayPersonDisc(StateDisc);
                            }
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter The Valid Choise");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("please enter integer options only");
                }
            }
        }
        /// <summary>
        /// findByCityOrState wher we have to ask the user city or state  and print the details in particular adress book
        /// </summary>
        /// <param name="adressBookDictionary"></param>
        public static Dictionary<string, List<string>> FindByCityOrState(Dictionary<string, AdressBookBuilder>  adressBookDictionary, Dictionary<string, List<string>> areaDisc)
        { 
            Console.WriteLine("Enter the city or state where you want to find that person = ");
            string findPlace = Console.ReadLine();
            foreach (var element in adressBookDictionary)
            {
                List<string> listOfPersonsInPlace = element.Value.findPersons(findPlace);
                foreach (var name in listOfPersonsInPlace) 
                {
                    if (!areaDisc.ContainsKey(findPlace))
                    {
                        List<string> personList = new List<string>();
                        personList.Add(name);
                        areaDisc.Add(findPlace, personList);
                    }
                    else
                    { 
                        areaDisc[findPlace].Add(name);
                    }
                }
            }
            return areaDisc;
        }
        public static void displayPersonDisc(Dictionary<string, List<string>>  areaDisc)
        {
            foreach (var index in areaDisc)
            {
                foreach (var personName in index.Value)
                {
                    Console.WriteLine("personName:-" + personName+"display area:-"+index.Key);
                }
            }        
        }
        /// <summary>
        /// takeInputAndAddToContact methode for taking input from person and condition for input should not be empty
        /// </summary>
        /// <param name="adressBookBuilder"></param>
        public static void takeInputAndAddToContact(AdressBookBuilder adressBookBuilder)
        {
            Console.WriteLine("Enter first name = ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name = ");
            string lastName = Console.ReadLine(); 
            Console.WriteLine("Enter address= ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter city= ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter state= ");
            string state = Console.ReadLine();
            Console.WriteLine("Enter zip= ");
            string zip = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber= ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter email= ");
            string email = Console.ReadLine();
            if((firstName != "")|| (lastName != "")|| (address != "")||(city!="")||(state!="")||(zip!="")||(email!="")||(phoneNumber!=""))
            {
                adressBookBuilder.addContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            }
            else
            {
                Console.WriteLine("Empty string not allowed \n for add contacts please give the input in string");
            }
        }
    }
}