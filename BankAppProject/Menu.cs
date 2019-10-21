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
        static string[] menuList = { "Create client", "Show all clients", "Savings accounts", "Checkings accounts", "Show all transactions", "Make a transaction", "masterMenu", "Exit" };

        public static void MainMenu()
        {
            Console.Clear();

            bool NoClients = !Client.ClientList.Any();
            counter = 1;

            for (int i = 0; i < menuList.Length; i++)
            {
                if (NoClients && i == 1 || NoClients && i == 2 || NoClients && i == 3 || NoClients && i == 4 || NoClients && i == 5)
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
                    masterMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Incorrect input!");
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
                //case "3":
                //    SavingsAccount.ShowSavingAccounts();
                //    break;
                //case "4":
                //    CheckingsAccount.ShowCheckingAccounts();
                //    break;
                case "5":
                    Transactions.ShowTransactions();
                    break;
                case "6":
                    Transactions.ExecuteTransactions();
                    break;
                case "7":
                    masterMenu();
                    break;
                case "8":
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
                    Transactions.ExecuteTransactions();
                    break;
                case "3":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Incorrect input!");
                    break;
            }
        }
        public static void masterMenu()
        {
            string choice;

            do
            {
                Console.Clear();
                Console.WriteLine("Master Menu");
                Console.WriteLine("-----------");
                Console.WriteLine();
                Console.WriteLine("1. Bank.Create client");
                Console.WriteLine("2. BankAccounts.ShowAllAccounts()");
                Console.WriteLine("3. Menu.MainMenu()");
                Console.WriteLine("5. CheckingsAccount.ShowAccounts()");
                Console.WriteLine("6. CheckingsAccount.CheckForBonus()");
                Console.WriteLine("7. SavingsAccount.ShowAccounts()");
                Console.WriteLine("8. SavingsAccount.CheckForBonus()");
                Console.WriteLine("9. Transactions.ConfirmTransactions()");
                Console.WriteLine("10. Transactions.ExecuteTransactions()");
                Console.WriteLine("11. Transactions.ExecuteDeposit()");
                Console.WriteLine("12. Transactions.ShowTransactions()");
                Console.WriteLine("'exit' to exit program");
                Console.WriteLine();

                Console.Write("Input: ");

                choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Bank.CreateClient();
                        //MainMenu();
                        break;

                    case "2":
                        BankAccount.ShowAllAccounts();
                        break;

                    case "3":
                        Menu.MainMenu();
                        break;

                    case "5":
                        CheckingsAccount cA = new CheckingsAccount();
                        cA.ShowAccounts();
                        break;

                    //case "6":
                    //    CheckingsAccount ca1 = new CheckingsAccount();
                    //    ca1.CheckForBonus();
                    //    break;

                    case "7":
                        SavingsAccount sA = new SavingsAccount();
                        sA.ShowAccounts();
                        break;

                    //case "8":
                    //SavingsAccount sA1 = new SavingsAccount();
                    //sA1.CheckForBonus();
                    //    break;

                    //case "9":
                    //    Transactions trans = new Transactions();
                    //    trans.ConfirmTransactions();
                    //    break;

                    case "10":
                        Transactions.ExecuteTransactions();
                        break;
                    case "11":
                        Transactions.ExecuteDeposit();
                        break;
                    case "12":
                        Transactions.ShowTransactions();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            } while (choice != "exit");
        }
    }
}
