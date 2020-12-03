using System;

namespace AdressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To adress Book System!");
            Program program = new Program();
            Console.WriteLine("Enter first name = ");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter last name = ");
            string lName = Console.ReadLine();
            Console.WriteLine("Enter address= ");
            String address=Console.ReadLine();
            Console.WriteLine("Enter city= ");
            String city = Console.ReadLine();
            Console.WriteLine("Enter state= ");
            String state = Console.ReadLine();
            Console.WriteLine("Enter zip= ");
            String zip = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber= ");
            String phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter email= ");
            String email = Console.ReadLine();

            AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
            adressBookBuilder.AddContact(fName, lName, address, city, state, zip, phoneNumber, email);
            adressBookBuilder.displayContact();



        }
    }
}
