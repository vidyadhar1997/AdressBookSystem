using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdressBookSystem
{
    public class FileReadWrite
    {
        public static string textFilePath = @"\bridgeLabzFellowship\AdressBookSystem\AdressBookSystem\Contact.txt";
        public static string csvFilePath = @"\bridgeLabzFellowship\AdressBookSystem\AdressBookSystem\Contact.csv";

        /// <summary>
        /// Write into txt file.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        public static void writeInTxtFile(List<Contact> contacts)
        {
            if (File.Exists(textFilePath))
            {
                using (StreamWriter streamWriter = File.AppendText(textFilePath))
                {
                    foreach (Contact contact in contacts)
                    {
                        streamWriter.WriteLine(contact);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("SucessFully write into txt file");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }

        /// <summary>
        /// Read from the file txt.
        /// </summary>
        public static void readFromTxtFile()
        {
            if (File.Exists(textFilePath))
            {
                using (StreamReader streamReader = File.OpenText(textFilePath))
                {
                    string data = "";
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }

        /// <summary>
        /// Write into CSV file
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        public static void writeintoCsvFile(List<Contact> contacts)
        {
            if (File.Exists(csvFilePath))
            {
                using (StreamWriter streamWriter = File.AppendText(csvFilePath))
                {
                    foreach (Contact contact in contacts)
                    {
                        streamWriter.WriteLine(contact.firstName + "," + contact.lastName + "," + contact.address + "," + contact.city + "," + contact.state + "," + contact.zip + "," + contact.phoneNumber + "," + contact.email);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("SucessFully write into CSV file");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }

        /// <summary>
        /// Read from the CSV file.
        /// </summary>
        public static void readFromCSVFile()
        {
            string[] csvData = File.ReadAllLines(csvFilePath);
            foreach (string data in csvData)
            {
                string[] csv = data.Split(",");
                foreach (string dataCsv in csv)
                {
                    Console.WriteLine(dataCsv);
                }
            }
        }
    }
}
