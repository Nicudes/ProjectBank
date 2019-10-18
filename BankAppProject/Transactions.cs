using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Transactions
    {
        static List<Transactions> ListOfTransactions = new List<Transactions>();
        string dateAndTime;
        int amount;
        string transactionType;
        public bool IsTrue = false;

        public Transactions(string aDateAndTime, int aAmount, string aTransactionType)
        {
            dateAndTime = aDateAndTime;
            amount = aAmount;
            transactionType = aTransactionType;
        }

        public Transactions()
        {

        }

        public static void ShowTransactions()
        {
            foreach (Transactions trans in ListOfTransactions)
            {
                Console.WriteLine($"{trans.transactionType}: {trans.amount} kronor");
                Console.WriteLine($"Date and time: {trans.dateAndTime}");
                Console.WriteLine();
            }
            Console.ReadKey();
            /*Transcation TYPE: Deposit,
DATE: 2019 - 09 - 22 13:24:18,
AMOUNT: 10000krona,
TO ACCOUNT Type: Checking Account*/
        }

        public bool ConfirmTransactions()
        {
            //Kolla om transaction value <= Balance
            //Kolla om överföringen är från CheckingsAccount till Savingsaccount 
            //Kolla om överföringen är mellan olika CheckingsAccount
            //Kolla om det är en insättning
            //Om inte dessa krav uppfylls så skriv ut ett felmeddelande

            //Om det här uppfylls så
            return IsTrue = true;
        }

        public void ExecuteTransactions()
        {
            //Om ConfirmTransaction IsTrue är True så genomför transaktionen
            //Get set för den nya Balance i respektive konto 
            //Konto där överföringen genomförs get set - transaction amount
            //Mottagarkonto get set + transaction amount
            //Spara transaction information för client
            //Skriv dataTime och informationen för transaktionen


        }

        public static void ExecuteDeposit()
        {
            //Frågar efter kund ID
            /*
Enter the id of the customer: 1001
Enter the amount to deposit: 10000
Sucessfully Amount Deposited to your account.
Transcation TYPE: Deposit,
DATE: 2019 - 09 - 22 13:24:18,
AMOUNT: 10000krona,
TO ACCOUNT Type: Checking Account*/
            Console.WriteLine("--- Deposit Money ---");
            Console.WriteLine();

            Console.Write("Enter the ID of the customer: ");

            int id = int.Parse(Console.ReadLine());

            // Systemet kontrollerar att ID finns i kundlista

            foreach (Client client in Client.ClientList)
            {
                if (id == client.id)
                {
                    Console.WriteLine($"Name: {client.name}");
                    Console.Write("Enter the amount to deposit: ");
                    int amount = int.Parse(Console.ReadLine());

                    // Lägg till möjlighet att backa ur?
                    if (amount % 100 == 0)
                    {
                        Console.WriteLine($"Sucessfully deposited {amount} to your account!");
                        client.checkingsAccount += amount;
                        Console.WriteLine($"{client.name}, you now have {client.checkingsAccount} in your checking account");

                        // Kod som lägger till transaktion till lista
                        string dateAndTime = Convert.ToString(DateTime.Now);
                        Transactions trans = new Transactions(dateAndTime, amount, "Deposit");
                        ListOfTransactions.Add(trans);

                        Console.ReadKey();
                        Console.WriteLine();
                        ShowTransactions();
                        Console.ReadKey();
                        RepeatQuery();
                    }
                    else
                    {
                        Console.WriteLine("You have to deposit a larger amount!");
                        Console.WriteLine("You can only add amount in even 100´s");
                        RepeatQuery();
                    }
                }
                else
                {
                    Console.WriteLine("No such client was found");
                }
                Console.ReadKey();
            }
        }
        public static void RepeatQuery()
        {
            string choice;

            Console.WriteLine("Would you like to make a new deposit?");
            do
            {
                Console.Write("Enter 'Y' or 'N': ");
                choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {
                    ExecuteDeposit();
                }

                else if (choice == "N")
                {
                    //MainMenu();
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                    Console.Clear();
                }
            } while (choice != "Y" && choice != "N");
        }
    }
}
