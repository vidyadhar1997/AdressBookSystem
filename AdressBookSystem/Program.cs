using System;

namespace AdressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AdressBookBuilder adressBookBuilder = new AdressBookBuilder();
            while (true)
            {
                Console.WriteLine("\n 1 for Add Contact \n 2 for Edit Existing Contact \n 3 for delete the person,\n 4 for exit ");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Welcome To  Book System!");
                        Program program = new Program();
                        Console.WriteLine("Enter first name = ");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter last name = ");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Enter address= ");
                        String address = Console.ReadLine();
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

                        Console.WriteLine("Enter how many adress book you want");
                        int number = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < number; i++)
                        {
                            adressBookBuilder.addContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                        }
                        adressBookBuilder.displayContact();
                        break;
                    case 2:
                        Console.WriteLine("Enter first name = ");
                        string search = Console.ReadLine();
                        adressBookBuilder.editContact(search);
                        break;
                    case 3:
                        Console.WriteLine("Enter first name = ");
                        string delete = Console.ReadLine();
                        adressBookBuilder.deleteContact(delete);
                        adressBookBuilder.displayContact();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter The Valid Choise");
                        break;
                }
            }
        }
    }
}