using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{

    class Program
    {

        public struct Person
        {
            public int Number;
            public string FirstName;
            public string LastName;
            public int index;

            public override string ToString()
            {

                return "| Index: " + index + "| Firstname: " + FirstName + " | Lastname: " + LastName + " | Number: " + Number + " |";

            }

        }


        static void Main(string[] args)
        {

            List<Person> phoneList = new List<Person>();
            int userChoice;
            Boolean quit = false;
            Console.WriteLine("Welcome in PhoneBook application!");
            int i = 0;

            do
            {

                Console.WriteLine("\nWhat you like to do?");
                Console.WriteLine("1. Show all contacts");
                Console.WriteLine("2. Add new contact");
                Console.WriteLine("3. Delete contact.");
                Console.WriteLine("4. Sort by FirstName.");
                Console.WriteLine("5. Sort by LastName.");
                Console.WriteLine("6. Search contats by phone number.");
                Console.WriteLine("7. Quit");
                userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        {
                            if (phoneList.Count == 0)
                            {
                                Console.WriteLine("\nYou don't have any contacts");
                            }
                            else
                                Console.WriteLine();
                            foreach (var list in phoneList)
                            {
                                Console.WriteLine(list);

                            }
                            break;
                        }


                    case 2:
                        {
                            phoneList.Add(new Person()
                            {
                                index = i,
                                FirstName = FirstName(),
                                LastName = LastName(),
                                Number = Number()
                            });
                            i++;
                            break;
                        }

                    case 3:
                        {
                            if (phoneList.Count == 0)
                            {
                                Console.WriteLine("Error. You don't have any contacts.");
                            }
                            else
                            {
                                Console.WriteLine("Which contact do you wanna to remove?");
                                Console.WriteLine("Enter an index: ");
                                int remove = int.Parse(Console.ReadLine());
                                phoneList.RemoveAt(remove);
                                Console.WriteLine("Contact has been deleted.");
                            }
                            break;
                        }

                    case 4:
                        {
                            phoneList.Sort((con1, con2) => con1.FirstName.CompareTo(con2.FirstName));
                            Console.WriteLine("PhoneBook have been sorted by FirstName");
                            break;
                        }
                    case 5:
                        {
                            phoneList.Sort((con1, con2) => con1.LastName.CompareTo(con2.LastName));
                            Console.WriteLine("PhoneBook have been sorted by LastName");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("\nEnter an a phone number.");
                            int searchNumber = int.Parse(Console.ReadLine());
                            if (phoneList.Exists(x => x.Number == searchNumber))
                            {
                                Console.WriteLine("Search result:\n {0} ", phoneList.Find(x => x.Number == searchNumber));
                            }
                            else
                            {
                                Console.WriteLine("The specified number doesn't exist in Phonebook");
                            }
                            break;

                        }

                    case 7:
                        {
                            quit = true;

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nYou've entered invalid character. Please enter an a number from 1 to 4.");
                            continue;
                        }


                }

            } while (!quit);
        }


        public static string FirstName()
        {
            Console.WriteLine("\nEnter your FirstName: ");
            string firstName = Console.ReadLine();
            return firstName;

        }

        public static string LastName()
        {
            Console.WriteLine("\nEnter your LastName: ");
            string lastName = Console.ReadLine();
            return lastName;
        }

        public static int Number()
        {
            Console.WriteLine("\nEnter a number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }


    }
}

