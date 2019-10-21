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
        decimal amount;
        string transactionType;
        string toAccountType;
        Client firstClient;
        Client secondClient;
        static string choiceDeposit = "Deposit";
        static string choiceTransaction = "Transaction";
        static string choiceId = "id";

        public bool IsTrue = false;

        public Transactions(string aDateAndTime, decimal aAmount, string aTransactionType, string aToAccountType, Client aFirstClient, Client aSecondClient)
        {
            dateAndTime = aDateAndTime;
            amount = aAmount;
            transactionType = aTransactionType;
            toAccountType = aToAccountType;
            firstClient = aFirstClient;
            secondClient = aSecondClient;
        }

        public Transactions(string aDateAndTime, decimal aAmount, string aTransactionType, string aToAccountType, Client aFirstClient)
        {
            dateAndTime = aDateAndTime;
            amount = aAmount;
            transactionType = aTransactionType;
            toAccountType = aToAccountType;
            firstClient = aFirstClient;
        }

        public Transactions()
        {

        }

        public static void ShowTransactions()
        {
            bool IsEmpty = !ListOfTransactions.Any();

            if (IsEmpty)
            {
                Console.WriteLine("There are no transactions at the moment");
                Console.Write("Press any key to continue ");
                Console.ReadKey();
                Menu.MainMenu();
            }
            else
            {
                foreach (Transactions trans in ListOfTransactions)
                {
                    Console.WriteLine($"Transaction type: {trans.transactionType}");
                    Console.WriteLine($"Date and time: {trans.dateAndTime}");
                    Console.WriteLine($"Amount: {trans.amount} kronor");
                    Console.Write($"From client id: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(trans.firstClient.id);
                    Console.ResetColor();
                    
                    if (trans.transactionType == choiceTransaction)
                    {
                        Console.WriteLine($"To client id: {trans.secondClient.id}");
                    }
                    else
                    {
                        Console.WriteLine($"To client id: {trans.firstClient.id}");
                    }
                    //Vill vi ha den här koden och isf också ha en FROM acc type.
                    //Console.WriteLine($"To Account type: {trans.toAccountType}");
                    Console.WriteLine();
                }
                Console.Write("Press any key to continue ");
                Console.ReadKey();
                Menu.MainMenu();
            }
/*
Transcation TYPE: Transfer,
DATE: 2019 - 09 - 22 13:31:52,
AMOUNT: 7000krona,
From ACCOUNT Number: 1001,
TO ACCOUNT Number: 1001
*/
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

        

        public static void ExecuteTransactions()
        {
            decimal inputAmount;
            ///////////////////////////////////////////////
            //Kolla med Sohail om det är ok att göra såhär:
            /////////////////////////////////////////////
            Client firstClient = null;
            Client secondClient = null;

            do
            {
                Console.Write("Please enter your account ID: ");
                //int firstId = int.Parse(Console.ReadLine());
                decimal firstId = CheckIfNumber(choiceId);

                foreach (Client client in Client.ClientList)
                {
                    if (firstId == client.id)
                    {
                        firstClient = client;
                    }
                }

                if (firstClient == null)
                {
                    Console.WriteLine("No such client was found");
                } 
            } while (firstClient == null);

            do
            {
                Console.Write("Please enter the id of the person you would like to transfer funds to: ");
                decimal secondId = CheckIfNumber(choiceId);

                foreach (Client client in Client.ClientList)
                {
                    if (secondId == client.id)
                    {
                        secondClient = client;
                    }
                }

                if (secondClient == null)
                {
                    Console.WriteLine("No such client was found");
                } 
            } while (secondClient == null);

            /*Kod behövs i Execute Transactions för att hantera om man har 0 på kontot men försöker göra en överföring.
            I nuläget hamnar användare i en loop där de ombeds att ange hur mycket de vill överföra
            */

            Console.Write("Enter the amount of funds you would like to transfer: ");
            inputAmount = CheckIfNumber(choiceTransaction);
            inputAmount = CheckAmountValidity(choiceTransaction, firstClient, inputAmount);

            string toAccountType;

            if (firstClient == secondClient)
            {
                firstClient.checkingsAccount -= inputAmount;
                firstClient.savingsAccount += inputAmount;
                toAccountType = "Saving Account";
                Console.WriteLine($"{firstClient.name} has {firstClient.checkingsAccount} in the checking account, " +
                    $"{firstClient.name} has {firstClient.savingsAccount} in the savings account");

            }
            else
            {
                firstClient.checkingsAccount -= inputAmount;
                secondClient.checkingsAccount += inputAmount;
                toAccountType = "Checking Account";
                Console.WriteLine($"{firstClient.name} has {firstClient.checkingsAccount}, " +
                    $"{secondClient.name} has {secondClient.checkingsAccount}");
            }

            string dateAndTime = Convert.ToString(DateTime.Now);

            Transactions trans = new Transactions(dateAndTime, inputAmount, choiceTransaction, toAccountType, firstClient, secondClient);
            ListOfTransactions.Add(trans);

            Console.WriteLine();

            RepeatQuery(choiceTransaction);
            Console.ReadKey();
            //Om ConfirmTransaction IsTrue är True så genomför transaktionen
            //Get set för den nya Balance i respektive konto 
            //Konto där överföringen genomförs get set - transaction amount
            //Mottagarkonto get set + transaction amount
            //Spara transaction information för client
            //Skriv dataTime och informationen för transaktionen
            //Om man för över pengar så ska de pengar som gått ut vara markerat med rött och de pengar som gått in ska markeras med grönt.
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
            //Pengar som går in på kontot ska markeras med grönt
            //En counter som går til 3 och sen frågar om man vill tillbaka till main menu???

            Console.Clear();

            Client firstClient = null;
            int counter = 0;
            decimal inputAmount;

            Console.Clear();
            Console.WriteLine("--- Deposit Money ---");
            Console.WriteLine();

            do
            {
                Console.Write("Enter the ID of the customer: ");

                //int id = int.Parse(Console.ReadLine());
                decimal id = CheckIfNumber(choiceId);

                Console.WriteLine();

                // Systemet kontrollerar att ID finns i kundlista
                foreach (Client client in Client.ClientList)
                {
                    if (id == client.id)
                    {
                        firstClient = client;
                    }
                }

                if (firstClient == null)
                {
                    Console.WriteLine("No such client was found");
                    counter++;
                }
                if (counter == 3)
                {
                    Console.WriteLine("Going back to main menu");
                    Console.ReadKey();
                    Menu.MainMenu();
                }
            } while (firstClient == null);

            Console.WriteLine($"Name: {firstClient.name}");
            Console.WriteLine();

            //Här har jag tagit bort kod och satt in i nästa metod
            Console.Write("Enter the amount to deposit: ");
            inputAmount = CheckIfNumber(choiceDeposit);
            inputAmount = CheckAmountValidity(choiceDeposit, firstClient, inputAmount);

            Console.WriteLine();
            Console.WriteLine($"Sucessfully deposited {inputAmount} to your account!");
            firstClient.checkingsAccount += inputAmount;

            string dateAndTime = Convert.ToString(DateTime.Now);

            Console.WriteLine($"{firstClient.name}, you now have {firstClient.checkingsAccount} in your checking account");
            Console.WriteLine();

            // Kod som lägger till transaktion till lista

            string toAccountType = "Checking Account";

            Transactions trans = new Transactions(dateAndTime, inputAmount, choiceDeposit, toAccountType, firstClient);
            ListOfTransactions.Add(trans);

            RepeatQuery(choiceDeposit);
        }

        public static decimal CheckIfNumber(string aTransactionType)
        {
            decimal input = 0;
            for (int i = 0; i < 1; i++)
            {
                try
                {
                    input = decimal.Parse(Console.ReadLine());
                }
                catch
                {
                    if (aTransactionType == choiceDeposit || aTransactionType == choiceTransaction)
                    {
                        Console.WriteLine("Not a number");
                        Console.Write("Please reenter the amount: ");
                        i -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Not a number");
                        Console.Write("Please reenter the ID: ");
                        i -= 1;
                    }
                }
            }
            return input;
        }

        public static decimal CheckAmountValidity(string aTransactionType, Client client, decimal aInputAmount)
        {
            switch (aTransactionType.ToLower())
            {
                case "deposit":
                    while (aInputAmount < 50 || aInputAmount % 50 != 0)
                    {
                        if (aInputAmount < 50)
                        {
                            Console.WriteLine("You have to deposit a larger amount!");
                            Console.Write("Enter the amount to deposit: ");
                            aInputAmount = CheckIfNumber(choiceDeposit);
                        }
                        else if (aInputAmount % 50 != 0)
                        {
                            Console.WriteLine("You can only add amount in even 50 kronor bills");
                            Console.Write("Enter the amount to deposit: ");
                            aInputAmount = CheckIfNumber(choiceDeposit);
                        }
                    }
                    break;

                case "transaction":
                    while (aInputAmount <= 0 || aInputAmount > client.checkingsAccount)
                    {
                        if (aInputAmount <= 0)
                        {
                            Console.WriteLine("You have to deposit a larger amount!");
                            Console.Write("Enter the amount to transfer: ");
                            aInputAmount = CheckIfNumber(choiceTransaction);
                        }
                        else if (aInputAmount > client.checkingsAccount)
                        {
                            Console.WriteLine("You can't transfer more money than you have");
                            Console.WriteLine($"You have {client.checkingsAccount} kronor in your checking account");
                            Console.Write("Enter the amount to transfer: ");
                            aInputAmount = CheckIfNumber(choiceTransaction);
                        }
                    }
                    break;
            }
            return aInputAmount;
        }

        public static void RepeatQuery(string aTransactionType)
        {
            string choice;

            Console.WriteLine($"Would you like to make a new {aTransactionType.ToLower()}?");
            do
            {
                Console.Write("Enter 'Y' or 'N': ");
                choice = Console.ReadLine().ToUpper();

                if (choice == "Y" && aTransactionType == "Deposit")
                {
                    ExecuteDeposit();
                }
                else if (choice == "Y" && aTransactionType == "Transaction")
                {
                    ExecuteTransactions();
                }
                else if (choice == "N")
                {
                    Menu.MainMenu();
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                    Console.WriteLine();
                }
            } while (choice != "Y" && choice != "N");
        }
    }
}
