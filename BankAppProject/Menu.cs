﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BankAppProject
{
    class Menu
    {
        static int counter = 0;
        static string choice;
        // Vi skapar en array med alla menyval
        static string[] menuList = { "Create client", "Show all clients", "Savings accounts", "Checking accounts", "Show all transactions","Add existing clients", "Exit" };

        public static void MainMenu()
        {
            Console.Title = "Main Menu";
            Console.Clear();

        // Vi skapar en boolean som kollar av om det finns några klienter i vår klientlista
            bool NoClients = !Client.clientList.Any();
            counter = 1;

            Console.WriteLine("Main Menu");
            Console.WriteLine("---------\n");

        // Vi vill inte visa alla menyval ifall det inte finns några klienter i vår klientlista
            for (int i = 0; i < menuList.Length; i++)
            {
        // Om det inte finns några klienter så ska inte arrayplatserna 1,2,3 eller 4 skrivas ut.
                if (NoClients && i == 1 || NoClients && i == 2 || NoClients && i == 3 || NoClients && i == 4 || NoClients && i == 5)
                {

                }
                else
                {
                    Console.WriteLine($"{counter++}) {menuList[i]}");
                }
            }
            Console.WriteLine();

            Console.Write("Input: ");
            choice = Console.ReadLine();
            Console.Clear();
           

            while (true)
            {
                if (NoClients)
                {
                    SwitchMenu1();
                }
                else
                {
                    SwitchMenu2();
                }
            }
        }
        public static void CheckPassword()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            Console.SetCursorPosition((Console.WindowWidth - 25) / 2, Console.CursorTop);
            Console.WriteLine("Welcome to the BANK APP \n");
            Console.SetCursorPosition((Console.WindowWidth - 27) / 2, Console.CursorTop);
            Console.WriteLine("Please enter the password:\n");


            for (int i = 0; i < 3; i++)
            {
                string password = MaskingPassword();
                if (password == "admin")
                {
                    MainMenu();
                    break;
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth - 40) / 2, Console.CursorTop);
                    Console.WriteLine("Incorrect password, Please try again:\n");
                }
            }
            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.CursorTop);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.CursorTop);
            Console.WriteLine("Too many incorrect input!");
            for (int i = 9; i > 0; i--)
            {
                Console.SetCursorPosition((Console.WindowWidth - 25) / 2, Console.CursorTop);
                Console.Write($"Please wait {i} seconds");
                Thread.Sleep(1000);
            }
            CheckPassword();
        }
        public static string MaskingPassword()
        {
            string password = "";
            Console.SetCursorPosition((Console.WindowWidth - password.Length) / 3 + 10, Console.CursorTop);
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // Tar bort en bokstav från listan av password
                        password = password.Substring(0, password.Length - 1);
                        //ställer in vart cursor ska vara
                        int pos = Console.CursorLeft;
                        // Flytar cursor ett steg till vänster
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // Ersätter den förgående bokstaven med ett mellanslag 
                        Console.Write(" ");
                        // Flyttar cursor ett steg till vänster igen
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }


        public static void SwitchMenu1()
        {
            switch (choice)
            {
                case "1":
                    Bank.CreateClient();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;

                default:
                    MainMenu();
                    break;
            }
        }

        public static void SwitchMenu2()
        {
            switch (choice)
            {
                case "1":
                    Bank.CreateClient();
                    break;
                case "2":
                    BankAccount.ShowAllAccounts();
                    TransactionMenu();
                    break;
                case "3":
                    SavingsAccount sa = new SavingsAccount();
                    sa.ShowAccount();
                    break;
                case "4":
                    CheckingAccount ca = new CheckingAccount();
                    ca.ShowAccount();
                    break;
                case "5":
                    Transactions.ShowTransactions();
                    break;
                case "6":
                    if(Bank.addedClients == false)
                    {
                        Bank.AddExistingClients();
                        MainMenu();
                    }
                    else if (Bank.addedClients == true)
                    {
                        Console.WriteLine("You have already added existing clients!");
                        Console.ReadKey();
                        MainMenu();
                    }
                    break;
                case "7":
                    Environment.Exit(0);
                    break;

                default:
                    MainMenu();
                    break;
            }
        }

        public static void TransactionMenu()
        {
            Console.Title = "Transaction Menu";
            Console.WriteLine();
            Console.WriteLine("Transaction Menu");
            Console.WriteLine("----------------");
            Console.WriteLine();

            Console.WriteLine("1) Deposit");
            Console.WriteLine("2) Transfer");
            Console.WriteLine("3) Remove clients");
            Console.WriteLine("4) Return to main menu");
            Console.WriteLine();
            Console.Write("Input: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            do
            {
                switch (choice)
                {
                    case "1":
                        Transactions.ExecuteDeposit();
                        break;
                    case "2":
                        Transactions.ExecuteTransactions();
                        break;
                    case "3":
                        Bank.RemoveExistingClients();
                        break;
                    case "4":
                        MainMenu();
                        break;
                    default:
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.WriteLine(new string(' ', Console.BufferWidth - (Console.CursorTop - 1)));
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        choice = Console.ReadLine();
                        Console.WriteLine("Wrong input, please try again!");
                        break;
                } 
            } while (true);
        }
    }
}
