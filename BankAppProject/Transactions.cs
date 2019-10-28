using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace BankAppProject
{
    class Transactions
    {
        //För konstruktorerna
        private DateTime dateAndTime;
        private decimal amount;
        private string transactionType;
        private static string toAccountType;
        Client firstClient;
        Client secondClient;
        static SoundPlayer player = new SoundPlayer();

        private static string choiceDeposit = "Deposit";
        private static string choiceTransaction = "Transaction";
        private static string choiceId = "id";

        private static List<Transactions> transactionList = new List<Transactions>();

        public Transactions(DateTime aDateAndTime, decimal aAmount, string aTransactionType, string aToAccountType, Client aFirstClient, Client aSecondClient)
        {
            dateAndTime = aDateAndTime;
            amount = aAmount;
            transactionType = aTransactionType;
            toAccountType = aToAccountType;
            firstClient = aFirstClient;
            secondClient = aSecondClient;
        }

        public Transactions(DateTime aDateAndTime, decimal aAmount, string aTransactionType, string aToAccountType, Client aFirstClient)
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
            bool IsEmpty = !transactionList.Any();

            if (IsEmpty)
            {
                Console.WriteLine("There are no transactions at the moment");
                Colours.Red("Press any key to continue ");
                Console.ReadKey();
                Menu.MainMenu();
            }
            else
            {
                foreach (Transactions trans in transactionList)
                {
                    Console.WriteLine($"Transaction type: {trans.transactionType}");
                    Console.WriteLine($"Date and time: {trans.dateAndTime}");
                    Console.Write($"Amount: "); Colours.Green(Convert.ToString(trans.amount)); Console.WriteLine("kr");
                    
                    if (trans.transactionType == choiceTransaction)
                    {
                        Console.WriteLine($"From client id: {trans.firstClient.id}");
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

        public static void ErrorMessage()
        {            
            Colours.Red("No such client was found");
            Console.WriteLine(); 
            Console.WriteLine("Do you want to return to main menu? Press 0.");
            Console.WriteLine("Otherwise press any key to continue.");
            string goBackToMainMenu = Console.ReadLine();

            if (goBackToMainMenu == "0")
            {
                Menu.MainMenu();
            }
            
        }
        public static void ExecuteTransactions()
        {

            Console.Clear();

            decimal inputAmount;
            bool foundClient = false;

            Client firstClient = new Client();
            Client secondClient = new Client();

            do
            {
                Console.Write("Please enter your account ID: ");
                decimal firstId = CheckIfNumber(choiceId);

                Console.WriteLine();
                
                foreach (Client client in Client.clientList)
                {
                    if (firstId == client.id)
                    {
                        firstClient = client;
                        foundClient = true;
                    }
                }

                if (!foundClient)
                {
                 ErrorMessage();
                } 

            } while (!foundClient);
            Console.Clear();

            if (firstClient.checkingAccount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{firstClient.name} unfortunately has no money in his/her checking account.");
                Console.ResetColor();
                RepeatQuery(choiceTransaction);
            }

            foundClient = false;

            do
            {
                Console.Write("Please enter the id of the person you would like to transfer funds to: ");
                decimal secondId = CheckIfNumber(choiceId);
                Console.WriteLine();

                foreach (Client client in Client.clientList)
                {
                    if (secondId == client.id)
                    {
                        secondClient = client;
                        foundClient = true;
                    }
                }

                if (!foundClient)
                {
                    ErrorMessage();
                } 

            } while (!foundClient);

            Console.Clear();

            /*Kod behövs i Execute Transactions för att hantera om man har 0 på kontot men försöker göra en överföring.
            I nuläget hamnar användare i en loop där de ombeds att ange hur mycket de vill överföra
            */

            Console.Write("Enter the amount of funds you would like to transfer: ");
            inputAmount = CheckIfNumber(choiceTransaction);
            inputAmount = ValidateAmount(choiceTransaction, firstClient, inputAmount);

            if (firstClient == secondClient)
            {
                firstClient.checkingAccount -= inputAmount;
                firstClient.savingsAccount += inputAmount;
                toAccountType = "Saving Account";
                Console.WriteLine($"{firstClient.name} transferred {inputAmount} from his/her checking account " +
                    $"to his/her {toAccountType.ToLower()}.");
            }
            else
            {
                firstClient.checkingAccount -= inputAmount;
                secondClient.checkingAccount += inputAmount;
                toAccountType = "Checking Account";
                Console.WriteLine($"{firstClient.name} transferred {inputAmount} to {secondClient.name}'s {toAccountType.ToLower()}.");
            }

            DateTime dateAndTime = DateTime.Now;

            Transactions trans = new Transactions(dateAndTime, inputAmount, choiceTransaction, toAccountType, firstClient, secondClient);
            transactionList.Add(trans);
            //
            player.SoundLocation = "ca-ching.wav";
            player.Play();
            //
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
            //Man kan bara lägga till två decimaler som mest

            Console.Clear();

            Client firstClient = new Client();
            decimal inputAmount;
            bool foundClient = false;

            Console.Clear();
            Console.WriteLine("--- Deposit Money ---");
            Console.WriteLine();

            do
            {
                Console.Write("Enter the ID of the customer: ");

                decimal id = CheckIfNumber(choiceId);
                Console.WriteLine();

                // Systemet kontrollerar att ID finns i kundlista
                foreach (Client client in Client.clientList)
                {
                    if (id == client.id)
                    {
                        firstClient = client;
                        foundClient = true;
                        break;
                    }
                }

                if (!foundClient)
                {
                    ErrorMessage();
                }
            } while (!foundClient);

            Console.WriteLine($"Name: {firstClient.name}");
            Console.WriteLine();

            Console.Write("Enter the amount to deposit: ");
            inputAmount = CheckIfNumber(choiceDeposit);
            inputAmount = ValidateAmount(choiceDeposit, firstClient, inputAmount);
            //

            player.SoundLocation = "ca-ching.wav";
            player.Play();

            //
            Console.WriteLine();
            Console.Write($"Sucessfully deposited ");
            Colours.Green($"{inputAmount}");
            Console.WriteLine(" kr to your account!");
            firstClient.checkingAccount += inputAmount;

            DateTime dateAndTime = DateTime.Now;

      

            Console.WriteLine($"{firstClient.name}, you now have {firstClient.checkingAccount} kr in your checking account");
            Console.WriteLine();

            // Kod som lägger till transaktion till lista

            string toAccountType = "Checking Account";

            Transactions trans = new Transactions(dateAndTime, inputAmount, choiceDeposit, toAccountType, firstClient);
            transactionList.Add(trans);

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
                        Colours.Red("Not a number\n");
                        Console.Write("Please reenter the amount: ");
                        i -= 1;
                    }
                    else
                    {
                        Colours.Red("Not a number\n");
                        Console.Write("Please reenter the ID: ");
                        i -= 1;
                    }
                }
            }
            return input;
        }

        public static decimal ValidateAmount(string aTransactionType, Client client, decimal aInputAmount)
        {
            switch (aTransactionType)
            {
                case "Deposit":
                    while (aInputAmount < 100 || aInputAmount % 100 != 0)
                    {
                        if (aInputAmount < 100)
                        {
                            Colours.Red("You have to deposit a larger amount!\n");
                            Colours.Red("The smallest amount to deposit is 100 kr\n");
                            Console.WriteLine();
                            Console.Write("Enter the amount to deposit: ");
                            aInputAmount = CheckIfNumber(choiceDeposit);
                        }
                        else if (aInputAmount % 100 != 0)
                        {
                            Colours.Red("You can only add amount in even 100 kr bills\n");
                            Console.WriteLine();
                            Console.Write("Enter the amount to deposit: ");
                            aInputAmount = CheckIfNumber(choiceDeposit);
                        }
                    }
                    break;

                case "Transaction":
                    while (aInputAmount <= 0 || aInputAmount > client.checkingAccount)
                    {
                        if (aInputAmount <= 0)
                        {
                            Colours.Red("You have to deposit a larger amount!\n");
                            Colours.Red("You can only transfer a positive amount.\n");
                            Console.WriteLine();
                            Console.Write("Enter the amount to transfer: ");
                            aInputAmount = CheckIfNumber(choiceTransaction);
                        }
                        else if (aInputAmount > client.checkingAccount)
                        {
                            Colours.Red("You can't transfer more money than you have\n");
                            Console.WriteLine($"You have {client.checkingAccount} kronor in your checking account");
                            Console.WriteLine();
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
            Console.WriteLine();
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
                    Colours.Red("Wrong input!\n");
                    Console.WriteLine();
                }
            } while (choice != "Y" && choice != "N");
        }
    }
}