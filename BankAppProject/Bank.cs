﻿using System;
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
        public static bool addedClients;
        static SoundPlayer Player = new SoundPlayer();

        //variabeln är till för att konton som skapas ska från nr 1001.
        private static int idNumberMaker = 1000;

        //CreateClient är till för att skapa ett klient objekt.
        public static void CreateClient()
        {
            Console.Title = "Create Client";
            int id = ++idNumberMaker;
            string fullName = null;
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
        //Vi vill göra första bokstaven i namnet till stor bokstav
                        char letterChar = letters[i];
                        letterChar = char.ToUpper(letterChar);
                        letters[i] = letterChar;
                    }
                }

                if (firstOrLast == "first")
                {
                    fullName = new string(letters);
                    firstOrLast = "last";
                }
                else if (firstOrLast == "last")
                {
        //Vi slår ihop namnen till ett och samma.
                    fullName += " " + new string(letters);
                    ValidateName = true;
                }

            } while (!ValidateName);

            //Vi skapar objektet creationDate av typen DateTime för att logga när kund är skapad.
            DateTime creationDate = DateTime.Now;

            CheckingAccount checkingAccount = new CheckingAccount(0);
            SavingsAccount savingsAccount = new SavingsAccount(5000);

            //Vi skapar ett objekt utifrån en konstruktor i client som vi använder för att se kundens alla uppgifter. 
            Client client = new Client(fullName, id, creationDate, checkingAccount, savingsAccount);
            Console.WriteLine();
            #region Easter Egg
            if (client.name == "Snake Snakesson")
            {
                Snakeclass.Snake.SnakeGame();
                Console.Clear();
                Console.SetWindowSize(100, 40);
            }
            #endregion
            Player.SoundLocation = "confirm.wav";
            Player.Play();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------");
            Console.WriteLine("Client created");
            Console.WriteLine("----------------");
            Console.WriteLine($"Name: {fullName}\nID: {id}\nAccount created at: {creationDate}\nChecking Account: {checkingAccount.amount} kr\nSavings Account: {savingsAccount.amount} kr");
            Console.WriteLine("----------------");
            Console.ResetColor();

            //Den skapade klienten läggs till i vår klientlista.
            Client.clientList.Add(client);

            Console.WriteLine();
            Colours.Red("Press any key to return to Main Menu");
            Console.ReadKey();
            Menu.MainMenu();
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

        //Om alla chars i en input är en bokstav och hela strängen inte består av bara mellanslag
                if (input.All(char.IsLetter) && !string.IsNullOrWhiteSpace(input))
                {
                    InvalidInput = false;
                }
        //Om input bara är mellanslag eller ingenting skrivs ett felmeddelande ut
                if (string.IsNullOrWhiteSpace(input))
                {
                    Colours.Red("Name can not be white space\n");
                }
        //Om inte alla chars i input är bokstäver skrivs ett felmeddelande ut
                else if (!input.All(char.IsLetter))
                {
                    Colours.Red("Name can only consist of letters A-Ö.\n");
                }
            } while (InvalidInput);
        // Returnerar en string
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
            addedClients = true;
            Console.WriteLine("You have added existing clients!\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();           
        }

        public static void RemoveExistingClients()
        {
            Console.Title = "Remove Client";
            Client clientToRemove = new Client();
            bool foundClient = false;
         
            do
            {
                Console.Clear();
                foreach (Client client in Client.clientList)
                {
                    Console.WriteLine($"{client.id}) {client.name}");
                }

                Console.WriteLine();

                Console.Write("Enter the id of the client you wish to remove?: ");
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
                    Colours.Red("No such client was found\n");
                    Transactions.ErrorMessage();
                } 
            } while (!foundClient);

            string choice;
            do
            {
                Colours.Red($"Are you sure you want to remove {clientToRemove.name}? "); Console.Write("Y/N: ");

                choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {
                    Client.clientList.Remove(clientToRemove);
                }
                else if (choice == "N")
                {
                    Console.WriteLine("Going back to main menu");
                    Console.WriteLine();
                    Console.ReadKey();
                    Menu.MainMenu();
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                } 
            } while (choice != "Y" && choice != "N");

            Console.WriteLine();
            Colours.Red($"[DELETED] {clientToRemove.name}");

            Console.ReadKey();
            Menu.MainMenu();
        }
    }
}
