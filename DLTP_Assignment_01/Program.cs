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
                    Console.WriteLine("Adressboken");
                    Console.WriteLine("Skriv 'ladda' för att ladda in Adressboken.");
                    Console.WriteLine("Skriv 'hjälp' för att få hjälp!");
                    string command;
                    bool loadedAddressBook = false;
                    Random rand = new Random();
                    do
                    {
                        Console.Write("> ");
                        command = Console.ReadLine();
                        if (command == "avsluta")
                        {
                            Console.WriteLine("Hejdå!");
                        }
                        else if(command == "ladda")
                        {
                            if(loadedAddressBook == false)
                            {
                                Console.WriteLine("Laddar adressbok...");
                                Columns();
                                string line;
                                while ((line = file.ReadLine()) != null)
                                {
                                    string[] words = line.Split('#');
                                    Console.WriteLine("{0} - {1} - {2} - {3}", words[0], words[1], words[2], words[3]);
                                    person.Add(new AddressBook(words[0], words[1], words[2], words[3]));
                                }
                                file.Close();
                                loadedAddressBook = true;
                            }
                            else
                            {
                                Console.WriteLine("Adressboken är redan inlagd!");
                            }
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
                            Columns();
                            for (int i = 0; i < person.Count; i++)
                            {
                                if (person[i] != null)
                                {
                                    Console.WriteLine("{0} - {1} - {2} - {3}",
                                                       person[i].fullName, person[i].streetAddress,
                                                       person[i].phoneNumber, person[i].eMail);
                                }
                            }
                        }
                        else if (command == "visa")
                        {
                            Columns();
                            for (int i = 0; i < person.Count; i++)
                            {
                                if (person[i] != null)
                                {
                                    Console.WriteLine("{0} - {1} - {2} - {3}",
                                                       person[i].fullName, person[i].streetAddress,
                                                       person[i].phoneNumber, person[i].eMail);
                                }
                            }
                        }
                        else if (command == "spara")
                        {
                            using (StreamWriter writer = new StreamWriter(fileName))
                            {
                                for (int i = 0; i < person.Count(); i++)
                                {
                                    writer.WriteLine("{0}#{1}#{2}#{3}",
                                                    person[i].fullName, person[i].streetAddress,
                                                    person[i].phoneNumber, person[i].eMail);
                                }
                                Console.WriteLine("Adressboken är sparad!");
                            }
                        }
                        else if (command == "ta bort")
                        {
                            Console.Write("Ange namnet på den du vill ta bort ur adressboken: ");
                            string name = Console.ReadLine();
                            bool removedName = false;
                            for (int i = 0; i < person.Count; i++)
                            {
                                if (name == person[i].fullName)
                                {
                                    Console.WriteLine($"Tog bort personen med namnet {name} ur adressbooken!");
                                    Console.WriteLine($"Hittade {name} på rad {i+1}");
                                    person.RemoveAt(i);
                                    removedName = true;
                                }
                            }
                            if (removedName == false)
                            {
                                Console.WriteLine($"Hittade ingen med namnet {name} i adressboken, har du stavat rätt?");
                            }
                        }
                        else if(command == "hjälp")
                        {
                            Console.WriteLine("Skriv 'ladda' för att ladda in Adressboken");
                            Console.WriteLine("Skriv 'ny' för att lägga till en ny person i adressboken");
                            Console.WriteLine("Skriv 'visa' för att visa adressboken");
                            Console.WriteLine("Skriv 'ta bort' för att ta bort en person ur adressboken");
                            Console.WriteLine("Skriv 'spara' för att spara ändringarna i adressboken");
                            Console.WriteLine("Skriv 'avsluta' för att avsluta programet");
                        }
                        else
                        {
                            Console.WriteLine($"Okänt kommando: {command}");
                            Console.WriteLine("Skriv 'hjälp' för att få hjälp!");
                        }
                    } while (command != "avsluta");
                }
            }
            static void Columns()
            {
                Console.WriteLine("Namn - Adress - Telefonnummer - Mailadress");
                Console.WriteLine("------------------------------------------");
            }
        }
    }
}
