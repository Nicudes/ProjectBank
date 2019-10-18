using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Menu
    {
        
        public static void MainMenu()
        {
            /* switchcase för
             * skapa kund - skapa kund metoden
             * visa kunder - foreach metoden - transaction menu
             * sparkonton - listasubmeny sparkonto
             * lönekonton
             * visa alla transaktioner - foreach lista av transakt.
             * avsluta*/

            Console.Clear();
            Console.WriteLine($"Menu");
            Console.WriteLine("-------");
            Console.WriteLine();
            Console.WriteLine("1) Create client");
            Console.WriteLine("2) Show all clients");
            Console.WriteLine("3) Savings accounts");
            Console.WriteLine("4) Checkings accounts");
            Console.WriteLine("5) Show all transactions");
            Console.WriteLine("6) Exit");
            Console.WriteLine();
            
            Console.WriteLine("Input: ");
            string choice = Console.ReadLine();
            Console.Clear();
            

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
                    SavingsAccount saveAcc = new SavingsAccount();
                    saveAcc.ShowAccounts();
                    break;
                case "4":
                    CheckingsAccount checkAcc = new CheckingsAccount();
                    checkAcc.ShowAccounts();
                    break;
                case "5":
                    break;
                case "6":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Incorrect input!");
                    break;
            }

        }

        

        public static void TransactionMenu()
        {
            /*
             * deposit - alltid till sitt eget lönekonto. Välja personens id + summan.
             * transfer - skriv in ditt kund id, skriv in den du vill skicka tills id, summa.
             * återgå till transactionMenu
             * return to mainmenu*/

            Console.WriteLine("Transaction Menu");
            Console.WriteLine("----------------");
            Console.WriteLine();

            Console.WriteLine("1) Deposit");
            Console.WriteLine("2) Transfer");
            Console.WriteLine("3) Return to main menu");

            Console.WriteLine("Input: ");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Transactions.ExecuteDeposit();
                    break;
                case "2":
                    //Kalla transfer metoden
                    break;
                case "3":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Incorrect input!");
                    break;
            }

        }


    }
}
