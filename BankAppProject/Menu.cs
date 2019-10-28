using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Menu
    {
        static int counter = 0;
        static string choice;
        static string[] menuList = { "Create client", "Show all clients", "Savings accounts", "Checkings accounts", "Show all transactions", "Exit" };

        public static void MainMenu()
        {
            Console.Clear();

            bool NoClients = !Client.clientList.Any();
            counter = 1;

            for (int i = 0; i < menuList.Length; i++)
            {
                if (NoClients && i == 1 || NoClients && i == 2 || NoClients && i == 3 || NoClients && i == 4)
                {

                }
                else
                {
                    Console.WriteLine($"{counter++}) {menuList[i]}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Input: ");
            choice = Console.ReadLine();
            Console.Clear();
           
    

            /* switchcase för
 * skapa kund - skapa kund metoden
 * visa kunder - foreach metoden - transaction menu
 * sparkonton - listasubmeny sparkonto
 * lönekonton
 * visa alla transaktioner - foreach lista av transakt.
 * avsluta*/

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
                    CheckingsAccount ca = new CheckingsAccount();
                    ca.ShowAccount();
                    break;
                case "5":
                    Transactions.ShowTransactions();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;

                default:
                    MainMenu();
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
            Console.WriteLine();
            Console.WriteLine("Transaction Menu");
            Console.WriteLine("----------------");
            Console.WriteLine();

            Console.WriteLine("1) Deposit");
            Console.WriteLine("2) Transfer");
            Console.WriteLine("3) Return to main menu");

            Console.WriteLine("Input: ");
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
