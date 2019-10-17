using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;

            do
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("---------");
                Console.WriteLine();
                Console.WriteLine("1. Bank.Create client");
                Console.WriteLine("2. Bank.ShowClient()");
                Console.WriteLine("3. Bank.CreateAccount()");
                Console.WriteLine("4. Bank.ShowTransactions()");
                Console.WriteLine("5. CheckingsAccount.ShowAccounts()");
                Console.WriteLine("6. CheckingsAccount.CheckForBonus()");
                Console.WriteLine("7. SavingsAccount.ShowAccounts()");
                Console.WriteLine("8. SavingsAccount.CheckForBonus()");
                Console.WriteLine("9. Transactions.ConfirmTransactions()");
                Console.WriteLine("10. Transactions.ExecuteTransactions()");
                Console.WriteLine("");
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
                        Bank.ShowClient();
                        break;

                    case "3":
                        Bank bank = new Bank();
                        bank.CreateAccount();
                        break;

                    case "4":
                        Bank bank1 = new Bank();
                        bank1.ShowTransactions();
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

                    case "9":
                        Transactions trans = new Transactions();
                        trans.ConfirmTransactions();
                        break;

                    case "10":
                        Transactions trans1 = new Transactions();
                        trans1.ExecuteTransactions();   
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
