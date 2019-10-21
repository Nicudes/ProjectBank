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
        static string deposit = "deposit";
        static string transaction = "transaction";

        public bool IsTrue = false;

        public Transactions(string aDateAndTime, decimal aAmount, string aTransactionType)
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

        public static void ExecuteTransactions()
        {
            int inputAmount;

            Console.Write("Please enter your account ID: ");
            int firstId = int.Parse(Console.ReadLine());
            Client firstClient = new Client();
            Client secondClient = new Client();

            foreach (Client client in Client.ClientList)
            {
                if (firstId == client.id)
                {
                    firstClient = client;
                }
            }
            //Lös ett felmeddelande om man inte hittar

            Console.Write("Please enter the id of the person you would like to transfer funds to: ");
            int secondId = int.Parse(Console.ReadLine());

            foreach (Client client in Client.ClientList)
            {
                if (secondId == client.id)
                {
                    secondClient = client;
                }
            }

            Console.Write("Enter the amount of funds you would like to transfer: ");
            inputAmount = int.Parse(Console.ReadLine());

            if (firstClient == secondClient)
            {
                firstClient.checkingsAccount -= inputAmount;
                firstClient.savingsAccount += inputAmount;
            }
            else
            {
                firstClient.checkingsAccount -= inputAmount;
                secondClient.checkingsAccount += inputAmount;
            }

            Console.WriteLine();
            Console.WriteLine($"Åsa has {firstClient.checkingsAccount}, Urban has {secondClient.checkingsAccount}");
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

            Client depositClient = null;
            int counter = 0;
            decimal inputAmount;

            Console.Clear();
            Console.WriteLine("--- Deposit Money ---");
            Console.WriteLine();

            do
            {
                Console.Write("Enter the ID of the customer: ");

                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();

                // Systemet kontrollerar att ID finns i kundlista
                foreach (Client client in Client.ClientList)
                {
                    if (id == client.id)
                    {
                        depositClient = client;
                    }
                }

                if (depositClient == null)
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
            } while (depositClient == null);

            Console.WriteLine($"Name: {depositClient.name}");
            Console.WriteLine();

            //Här har jag tagit bort kod och satt in i nästa metod
            Console.Write("Enter the amount to deposit: ");
            inputAmount = CheckIfNumber();
            inputAmount = CheckAmountValidity(deposit, depositClient, inputAmount);

            Console.WriteLine();
            Console.WriteLine($"Sucessfully deposited {inputAmount} to your account!");
            depositClient.checkingsAccount += inputAmount;

            string dateAndTime = Convert.ToString(DateTime.Now);

            Console.WriteLine($"{depositClient.name}, you now have {depositClient.checkingsAccount} in your checking account");
            Console.WriteLine();

            // Kod som lägger till transaktion till lista
            Transactions trans = new Transactions(dateAndTime, inputAmount, "Deposit");
            ListOfTransactions.Add(trans);

            RepeatQuery(deposit);
        }

        public static decimal CheckIfNumber()
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
                    Console.WriteLine("Not a number");
                    //Console.Write("Enter the amount to deposit: ");
                    i -= 1;
                }
            }
            return input;
        }

        public static decimal CheckAmountValidity(string aTransactionType, Client client, decimal aInputAmount)
        {
            switch (aTransactionType)
            {
                case "deposit":
                    while (aInputAmount < 50 || aInputAmount % 50 != 0)
                    {
                        if (aInputAmount < 50)
                        {
                            Console.WriteLine("You have to deposit a larger amount!");
                            Console.Write("Enter the amount to deposit: ");
                            aInputAmount = CheckIfNumber();
                        }
                        else if (aInputAmount % 50 != 0)
                        {
                            Console.WriteLine("You can only add amount in even 50 kronor bills");
                            Console.Write("Enter the amount to deposit: ");
                            aInputAmount = CheckIfNumber();
                        }
                    }
                    break;

                case "transaction":
                    while (aInputAmount <= 0 || aInputAmount > client.checkingsAccount)
                    {
                        if (aInputAmount <= 0)
                        {
                            Console.WriteLine("You have to deposit a larger amount!");
                            Console.Write("Enter the amount to deposit: ");
                            CheckIfNumber();
                        }
                        else if (aInputAmount > client.checkingsAccount)
                        {
                            Console.WriteLine("You can't transfer more money than you have");
                            Console.WriteLine($"You have {client.checkingsAccount} kronor in your checking account");
                        }
                    }
                    break;
            }
            return aInputAmount;
        }

        public static void RepeatQuery(string aTransactionType)
        {
            string choice;

            Console.WriteLine($"Would you like to make a new {aTransactionType}?");
            do
            {
                Console.Write("Enter 'Y' or 'N': ");
                choice = Console.ReadLine().ToUpper();

                if (choice == "Y" && aTransactionType == "deposit")
                {
                    ExecuteDeposit();
                }
                else if (choice == "Y" && aTransactionType == "transaction")
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
