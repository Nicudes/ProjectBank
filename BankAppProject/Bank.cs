using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Media;

namespace BankAppProject
{

    class Bank
    {
        static SoundPlayer Player = new SoundPlayer();

        //variabeln är till för att konton som skapas ska från nr 1001.
        private static int idNumberMaker = 1000;

        //CreateClient är till för att skapa ett klient objekt.
        public static void CreateClient()
        {
            int id = ++idNumberMaker;
            string fullName = null;
            string lastName = null;
            string firstOrLast = "first";
            bool ValidateName;

            Console.WriteLine("Creating client");
            Console.WriteLine("----------------");

            do
            {
                ValidateName = false;

                string input = CheckNameValidity(firstOrLast);
                char[] letters = input.ToCharArray();

                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == letters[0])
                    {
                        MakeLetterUpper(letters, i);
                    }
                }

                if (firstOrLast == "first")
                {
                    fullName = new string(letters);
                    firstOrLast = "last";
                }
                else if (firstOrLast == "last")
                {
                    lastName = new string(letters);
                    fullName += " " + lastName;
                    ValidateName = true;
                }

            } while (!ValidateName);

            //Vi skapar objektet creationDate av typen DateTime för att logga när kund är skapad.
            DateTime creationDate = DateTime.Now;

            CheckingAccount checkingAccount = new CheckingAccount();
            SavingsAccount savingsAccount = new SavingsAccount();

            //Vi skapar ett objekt utifrån en konstruktor i client som vi använder för att se kundens alla uppgifter. 
            Client client = new Client(fullName, id, creationDate, checkingAccount, savingsAccount);
            Console.WriteLine();
            Player.SoundLocation = "confirm.wav";
            Player.Play();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------");
            Console.WriteLine("Client created");
            Console.WriteLine("----------------");
            Console.WriteLine($"Name: {fullName}\nID: {id}\nAccount created at: {creationDate}\nChecking Account: {checkingAccount.amount}\nSavings Account: {savingsAccount.amount}");
            Console.WriteLine("----------------");
            Console.ResetColor();

            //Den skapade klienten läggs till i vår klientlista.
            Client.clientList.Add(client);

            Console.WriteLine();
            Colours.Red("Press any key to return to Main Menu");
            Console.ReadKey();
            Menu.MainMenu();
        }

        public static void MakeLetterUpper(char[] letters, int i)
        {
            char letter = letters[i];
            string letterString = letter.ToString().ToUpper();
            letter = char.Parse(letterString);
            letters[i] = letter;
        }

        public static string CheckNameValidity(string firstOrLast)
        {
            bool InvalidInput;
            string input = "";

            do
            {
                InvalidInput = true;

                Console.WriteLine();
                Console.Write($"Enter {firstOrLast} name: ");
                input = Console.ReadLine();

                if (input.All(char.IsLetter) && !string.IsNullOrWhiteSpace(input))
                {
                    InvalidInput = false;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Colours.Red("Name can not be white space\n");
                }
                else if (!input.All(char.IsLetter))
                {
                    Colours.Red("Name can only consist of letters A-Ö.\n");
                }
            } while (InvalidInput);

            return input;
        }

        //I denna metod skapar vi hårdkodade klienter som läggs till i början av programmet.
        public static void AddExistingClients()
        {
            string[] clientNames = { "Pelle", "Johan", "Okhuy", "Smandy", "Licke", "Kroken" };

            foreach (string name in clientNames)
            {
                CheckingAccount checkingAccount = new CheckingAccount(0);
                SavingsAccount savingsAccount = new SavingsAccount(5000);
                DateTime dateTime = new DateTime(2017, 1, 11);

                Client client = new Client(name, ++idNumberMaker, dateTime, checkingAccount, savingsAccount);

                Client.clientList.Add(client);
            }
        }

        public static void RemoveExistingClients()
        {
            //Visa klienterna
            //Fråga vilken man vill ta bort
            //bekräfta att man vill ta bort {namn}
            //Klient raderad

            Client clientToRemove = new Client();
            bool foundClient = false;
         
            do
            {
                Console.Clear();

                BankAccount.ShowAllAccounts();
                Console.WriteLine();

                Console.Write("Which client do you want to remove?: ");
                decimal id = Transactions.CheckIfNumber("id");

                foreach (Client client in Client.clientList)
                {
                    if (id == client.id)
                    {
                        clientToRemove = client;
                        foundClient = true;
                    }
                }

                if (!foundClient)
                {
                    Transactions.ErrorMessage();
                } 
            } while (!foundClient);

            string choice;
            do
            {
                Console.Write($"Are you sure you want to remove {clientToRemove.name}? Y/N: ");
                choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {
                    Client.clientList.Remove(clientToRemove);
                }
                else if (choice == "N")
                {
                    Console.WriteLine("Going back to main menu");
                    Console.ReadKey();
                    Menu.MainMenu();
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                } 
            } while (choice != "Y" && choice != "N");

            Colours.Red($"[DELETED] {clientToRemove.name}");

            Console.ReadKey();
            Menu.MainMenu();
        }
    }
}
