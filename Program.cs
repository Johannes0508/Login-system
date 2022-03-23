using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static List<Person> registeredPersons;
        static void Main(string[] args)
        {
            registeredPersons = new List<Person>(); 
            PrintMenu();
        }

        private static void PrintMenu()
        {
            Console.Clear();

            Console.WriteLine("===~Menu~===");
            Console.WriteLine("------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("------------");
            Console.WriteLine("2. Register");
            Console.WriteLine("------------");
            Console.WriteLine("3. List Registered Users");
            Console.WriteLine("------------");
            Console.WriteLine("4. Information");
            Console.WriteLine("------------");
            Console.WriteLine("5. Quit");
            Console.WriteLine("------------");
            string retVal = Console.ReadLine();

            switch (retVal) //switch case så att man kan navigera mellan alla och sedan avsluta programmet
            {
                case "1":
                    PrintLogin();
                    break;

                case "2":
                    PrintRegister();
                    break;

                case "3":
                    PrintUsers();
                    break;

                case "4":
                    Printinfo();
                    break;

                case "5":
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to exit...");
                    break;
            }

            
        }

        private static void PrintUsers()
        {
            Console.Clear();
            Console.WriteLine("===~Users~===");
            foreach (Person p in registeredPersons) //att varje login ska lagras i registeredPersons
            {
                Console.WriteLine(p.name);
            }

            if (registeredPersons.Count == 0) //om det inte finns några logins så ska det stå att det inte finns
            {
                Console.WriteLine("No users found!");
            }

            ContinoueStatement();
        }

        private static void PrintRegister() //frågar om användar namn och lösenord som sedan sparas i listan
        {
            Console.Clear();
            Console.WriteLine("===~Register~===");
            Console.WriteLine("State your name");
            string name = Console.ReadLine();
            Console.WriteLine("State your password");
            string password = Console.ReadLine();

            registeredPersons.Add(new Person(name, password));
            Console.WriteLine("User created");
            ContinoueStatement();
        }

        private static void PrintLogin()
        {
            Console.Clear();

            if (registeredPersons.Count > 0) //kollar om det finns något i registeredPersons
            {
                Console.WriteLine("===~Login~===");
                Console.WriteLine("Login name");
                string name = Console.ReadLine();
                Console.WriteLine("And password");
                string password = Console.ReadLine();

                bool exists = UserExists(name, password);

                if (exists) //kollar om namn och lösenord passar med varandra
                {
                    Console.WriteLine("Logged in!!");
                    Console.WriteLine("Press any key to continoue");
                    Console.ReadLine();
                    PrintMenu();
                }
                else // kollar om namn och lösenord inte passar
                {
                    Console.WriteLine("Login failed");
                    ContinoueStatement();
                }
            }
            else //för en vidare till register sidan om man inte har.
            {
                Console.WriteLine("No users registered, redirecting to Login screen...");
                PrintRegister();
            }
        }

        private static void Printinfo() // informations sidan
        {
            Console.Clear();
            Console.WriteLine("Hej hej det här är nånting hejdå!");
            ContinoueStatement();

        }

        static bool UserExists(string name, string password)
        {
            foreach (Person p in registeredPersons)
            {
                if (p.name == name && p.password == password) //att om namnet som vi har skapat och det vi skriver in finns så blir det true. 
                {
                    return true;
                }
            }
            return false;
        }

        static void ContinoueStatement() //förtydligar bara att man ska trycka på en knapp för att komma vidare.
        {
            Console.WriteLine("Press any key to continoue");
            Console.ReadLine();
            PrintMenu();
        }
    }

    class Person
    {
        public string name;
        public string password;
        public Person(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
