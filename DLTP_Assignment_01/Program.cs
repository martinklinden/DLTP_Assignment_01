using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DLTP_Assignment_01
{
    class Program
    {
        class AddressBook
        {
            public string fullName, streetAddress, phoneNumber, eMail;
            public AddressBook(string n, string a, string p, string e)
            {
                fullName = n;
                streetAddress = a;
                phoneNumber = p;
                eMail = e;
            }

            static void Main(string[] args)
            {
                List<AddressBook> person = new List<AddressBook>();
                string fileName = "/Users/misc/Desktop/adressbok.txt"; // mac
                using (StreamReader file = new StreamReader(fileName))
                {
                    /*string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] words = line.Split('#');
                        Console.WriteLine("{0} - {1} - {2} - {3}", words[0], words[1], words[2], words[3]);
                        person.Add(new AddressBook(words[0], words[1], words[2], words[3]));
                    }
                    file.Close();*/
                    Console.WriteLine("Adressboken");
                    Console.WriteLine("Skriv 'sluta' för att sluta!");
                    string command;
                    Random rand = new Random();
                    do
                    {
                        Console.Write("> ");
                        command = Console.ReadLine();
                        if (command == "sluta")
                        {
                            Console.WriteLine("Hejdå!");
                        }
                        else if(command == "ladda")
                        {
                            Console.WriteLine("Laddar adressbok...");
                            string line;
                            while ((line = file.ReadLine()) != null)
                            {
                                string[] words = line.Split('#');
                                Console.WriteLine("{0} - {1} - {2} - {3}", words[0], words[1], words[2], words[3]);
                                person.Add(new AddressBook(words[0], words[1], words[2], words[3]));
                            }
                            file.Close();
                        }
                        else if (command == "ny")
                        {
                            Console.Write("Ange namnet: ");
                            string name = Console.ReadLine();
                            Console.Write($"Ange en adress för {name}: ");
                            string street = Console.ReadLine();
                            Console.Write($"Ange ett telefonnummer för {name}: ");
                            string phone = Console.ReadLine();
                            Console.Write($"Ange en mailadress för {name}: ");
                            string mail = Console.ReadLine();
                            Console.WriteLine($"{name} - {street} - {phone} - {mail}\n");
                            person.Add(new AddressBook(name, street, phone, mail));
                            for (int i = 0; i < person.Count; i++)
                            {
                                if (person[i] != null)
                                {
                                    Console.WriteLine("{0} - {1} - {2} - {3}",
                                                       person[i].fullName, person[i].streetAddress, person[i].phoneNumber, person[i].eMail);
                                }
                            }
                        }
                        else if (command == "visa")
                        {
                            for (int i = 0; i < person.Count; i++)
                            {
                                if (person[i] != null)
                                {
                                    Console.WriteLine("{0} - {1} - {2} - {3}",
                                                       person[i].fullName, person[i].streetAddress, person[i].phoneNumber, person[i].eMail);
                                }
                            }
                        }
                        else if (command == "spara")
                        {
                            using (StreamWriter writer = new StreamWriter(fileName))
                            {
                                for (int i = 0; i < person.Count(); i++)
                                {
                                    writer.WriteLine("{0}#{1}#{2}#{3}", person[i].fullName, person[i].streetAddress, person[i].phoneNumber, person[i].eMail);
                                }
                            }
                        }
                        else if (command == "ta bort")
                        {
                            Console.Write("Ange namnet på den du vill ta bort ur adressboken: ");
                            string name = Console.ReadLine();
                            Console.WriteLine($"Tog bort personen med namnet {name} ur adressbooken!");
                            for (int i = 0; i < person.Count; i++)
                            {
                                if (name == person[i].fullName)
                                {
                                    Console.WriteLine($"Hittade {name} på rad {i+1}");
                                    person.RemoveAt(i);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Okänt kommando: {command}");
                        }
                    } while (command != "sluta");
                }
            }
        }
    }
}
