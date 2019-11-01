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
        //Variabler för att användas i konstruktorerna.
        private DateTime dateAndTime;
        private decimal amount;
        private string transactionType;
        private static string toAccountType;
        Client firstClient;
        Client secondClient;

        private static decimal interest = 0.0005m;
        // Skapar ett objekt av savingsAccount


        // Skapar ett objekt av api soundplayer som är en del av System.Media.
        static SoundPlayer player = new SoundPlayer();

    // Använder dessa variabler för att hantera felaktig inmatning och retunera rätt information.
        private static string choiceDeposit = "Deposit";
        private static string choiceTransaction = "Transaction";
        private static string choiceId = "id";

    // Skapar en lista för att kunna spara genomförda transaktioner och dess information.
        private static List<Transactions> transactionList = new List<Transactions>();

    // Konstruktorn är till för att spara en transaktion mellan två klienter
        public Transactions(DateTime aDateAndTime, decimal aAmount, string aTransactionType, string aToAccountType, Client aFirstClient, Client aSecondClient)
        {
            dateAndTime = aDateAndTime;
            amount = aAmount;
            transactionType = aTransactionType;
            toAccountType = aToAccountType;
            firstClient = aFirstClient;
            secondClient = aSecondClient;
        }

        // Konstruktorn är till för att spara en transaktion mellan checkingAcc och SavingsAcc på samma klient
        public Transactions(DateTime aDateAndTime, decimal aAmount, string aTransactionType, string aToAccountType, Client aFirstClient)
        {
            dateAndTime = aDateAndTime;
            amount = aAmount;
            transactionType = aTransactionType;
            toAccountType = aToAccountType;
            firstClient = aFirstClient;
        }
        // Skapar en tom konstruktor för att kunna skapa ett objekt som ej är beroende av att ha argument.
        public Transactions()
        {

        }
        // Vi skapar en metod för att kunna se genomförda transaktioner
        public static void ShowTransactions()
        {
        // Skapar en bool för att se om listan innehåller något i huvud taget.
            bool IsEmpty = !transactionList.Any();

        // Finns det inget i listan så skriv ut följande och gå tillbaka till main menu.
            if (IsEmpty)
            {
                Console.WriteLine("There are no transactions at the moment");
                Colours.Red("Press any key to continue ");
                Console.ReadKey();
                Menu.MainMenu();
            }
        // Om det finns något i listan så skriver den ut innehållet.
            else
            {
        // Skriver ut varje transkation och om det är en insättning skriver den ut else.
        // Är det en transaktion skriver den ut If.
                foreach (Transactions trans in transactionList)
                {
                    Console.WriteLine($"Transaction type: {trans.transactionType}");
                    Console.WriteLine($"Date and time: {trans.dateAndTime}");
                    Console.Write($"Amount: "); Colours.Green(Convert.ToString(trans.amount)); Console.WriteLine(" kr");
                    
                    if (trans.transactionType == choiceTransaction)
                    {
                        Console.WriteLine($"From client id: {trans.firstClient.id}");
                        Console.WriteLine($"To client id: {trans.secondClient.id}");     
                    }
                    else
                    {
                        Console.WriteLine($"To client id: {trans.firstClient.id}");
                    }
                    Console.WriteLine();
                }
                Console.Write("Press any key to continue ");
                Console.ReadKey();
                Menu.MainMenu();
            }
        }
        // Skapar en metod för ett felmedd. När man skriver in ett felaktigt id utförs denna metoden.
        // Vi ger möjligheten att kunna gå tillbaka till main menu genom att skriva in 0.
        public static void ErrorMessage()
        {
            Colours.Red("No such client was found");
            Console.WriteLine();
            Console.WriteLine("Do you want to return to main menu? Press 'esc'.");
            Console.WriteLine("Otherwise press 'enter' to continue.");

            ConsoleKeyInfo info;

            do
            {
                Console.WriteLine(new string(' ', Console.BufferWidth - (Console.CursorTop - 1)));
                Console.SetCursorPosition(0, Console.CursorTop - 1);

                info = Console.ReadKey();
                if (info.Key == ConsoleKey.Escape)
                {
                    Menu.MainMenu();
                }

            } while (info.Key != ConsoleKey.Escape && info.Key != ConsoleKey.Enter);
        }
        // Skapar en metod för att genomföra en överföring. 
        public static void ExecuteTransactions()
        {

            Console.Clear();
        // Skapar en variabel där inmatning av belopp sparas.
            decimal inputAmount;
        // skapar en bool som säger om vi har hittat en klient eller inte.
            bool foundClient = false;
        // skapar ett objekt av klient som vi kallar för första klienten.

            Client firstClient = new Client();
        // skapar ett objekt av klient som vi kallar för andra klienten.
            Client secondClient = new Client();
        // gör en do While för att vi vill att användare ska mata in klient id tills programmet hittar en matchande klient.
            do
            {
                Console.Write("Please enter your account ID: ");
        // Här kollar vi om inmatningen är ett nummer genom metoden CheckIfNumber. 
        // Är det inte det, så skriver programmet ut att det inte är ett nummer samt att man ska mata in ett id igen.
                decimal firstId = CheckIfNumber(choiceId);

                Console.WriteLine();
        // letar igenom klient listan. Vi för över infomrationen från klienten vi är på till first client.
        // Om det inmatade id:t hittas i listan av klienter, sätter vi även bool foundclient till true.
                foreach (Client client in Client.clientList)
                {
                    if (firstId == client.id)
                    {
                        firstClient = client;
                        foundClient = true;
                    }
                }
        // Hittar vi ingen klient med det inmatade id:t visar vi felmedd.
                if (!foundClient)
                {
                 ErrorMessage();
                } 

            } while (!foundClient);
            Console.Clear();
        // Om klientens checkingAcc är 0 eller mindre skriver vi ut den informationen och ger alternativet
        // att göra en ny transaktion via RepeatQuery metoden och choiseTransaction som argument.
            if (firstClient.checkingAccount.amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{firstClient.name} unfortunately has no money in his/her checking account.");
                Console.ResetColor();
                RepeatQuery(choiceTransaction);
            }
        // Sätter bool till false för att vi vill använda samma bool till nästa klient.
            foundClient = false;
        // gör en do While för att vi vill att användare ska mata in klient id tills programmet hittar en matchande klient.
            do
            {
                Console.Write("Please enter the id of the person you would like to transfer funds to: ");
        // Här kollar vi om inmatningen är ett nummer genom metoden CheckIfNumber. 
        // Är det inte det, så skriver programmet ut att det inte är ett nummer samt att man ska mata in ett id igen.
                decimal secondId = CheckIfNumber(choiceId);
                Console.WriteLine();
        // letar igenom klient listan. Vi för över infomrationen från klienten vi är på till second client.
        // Om det inmatade id:t hittas i listan av klienter, sätter vi även bool foundclient till true.
                foreach (Client client in Client.clientList)
                {
                    if (secondId == client.id)
                    {
                        secondClient = client;
                        foundClient = true;
                    }
                }
        // Hittar vi ingen klient med det inmatade id:t visar vi felmedd.
                if (!foundClient)
                {
                    ErrorMessage();
                } 

            } while (!foundClient);

            Console.Clear();
 
            Console.Write("Enter the amount of funds you would like to transfer: ");
        // kollar att det inmatade värdet är ett nummer och även om det är ett belopp genom argumentet ChoiceTrans.
        // Det returnerade värdet från CheckIfNumber stoppas sedan in i variabeln inputAmount.
            inputAmount = CheckIfNumber(choiceTransaction);
        // Kollar så att summan man försöker föra över är godkänd enligt logiken i ValidateAmount.
        // Det returnerade värdet från ValidateAmount stoppas sedan in i variabeln inputAmount.
            inputAmount = ValidateAmount(choiceTransaction, firstClient, inputAmount);
        // Om första klientens id inmatning matchar andra klientens id inmatning skickas pengarna från sitt egna
        // checkingAcc till sitt egna SavingsAcc.
            if (firstClient == secondClient)
            {
                SavingsAccount savingsAcc = new SavingsAccount();

                decimal interestBonus = firstClient.savingsAccount.amount * interest;

                firstClient.checkingAccount.amount -= inputAmount;
                firstClient.savingsAccount.amount += inputAmount;
                toAccountType = "Saving Account";
                Console.WriteLine($"{firstClient.name} transferred {inputAmount} from his/her checking account " +
                    $"to his/her {toAccountType.ToLower()}.");
                if (firstClient.interestBonus == false)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{firstClient.name} earned a interest bonus!");
                    Console.WriteLine($"The bonus was {interestBonus.ToString("F2")} kr");

                    savingsAcc.Interest(firstClient);
                }
            }
        // Är första inmatningen av klientens id inte samma som den andra, skickas pengarna från first clients checkingAcc
        // till second clients checkingAcc.
            else
            {
                firstClient.checkingAccount.amount -= inputAmount;
                secondClient.checkingAccount.amount += inputAmount;
                toAccountType = "Checking Account";
                Console.WriteLine($"{firstClient.name} transferred {inputAmount} to {secondClient.name}'s {toAccountType.ToLower()}.");
            }

            DateTime dateAndTime = DateTime.Now;
        // Vi skapar ett objekt av Transactions via konstruktorn i den klassen. 
            Transactions trans = new Transactions(dateAndTime, inputAmount, choiceTransaction, toAccountType, firstClient, secondClient);
        // Lägger till den genomförda transaktionen i vår lista av transaktioner.
            transactionList.Add(trans);
        // använder ljudfilen ca-ching som ligger i projektet.
            player.SoundLocation = "ca-ching.wav";
            player.Play();

            Console.WriteLine();
        // frågar användaren om den vill göra en ny transaktion.
            RepeatQuery(choiceTransaction);
            Console.ReadKey();

        }
        // skapar en metod som är till för att göra insättningar.
        public static void ExecuteDeposit()
        {

            Console.Clear();
        // skapar endast en first client för att vi inte kommer skapa en second client när vi gör en insättning.
            Client firstClient = new Client();
            decimal inputAmount;
            bool foundClient = false;

            Console.Clear();
            Console.WriteLine("--- Deposit Money ---");
            Console.WriteLine();
       
        // gör en do While för att vi vill att användare ska mata in klient id tills programmet hittar en matchande klient.
            do
            {
                Console.Write("Enter the ID of the customer: ");
        // Här kollar vi om inmatningen är ett nummer genom metoden CheckIfNumber. 
        // Är det inte det, så skriver programmet ut att det inte är ett nummer samt att man ska mata in ett id igen.
                decimal id = CheckIfNumber(choiceId);
                Console.WriteLine();

        // Systemet kontrollerar att det inmatade id:t en klients id i klientlistan.
                foreach (Client client in Client.clientList)
                {
                    if (id == client.id)
                    {
                        firstClient = client;
                        foundClient = true;
                        break;
                    }
                }
        // Hittar vi ingen klient med det inmatade id:t visar vi felmedd.
                if (!foundClient)
                {
                    ErrorMessage();
                }
            } while (!foundClient);

            Console.WriteLine($"Name: {firstClient.name}");
            Console.WriteLine();

            Console.Write("Enter the amount to deposit: ");
        
        //kollar att det inmatade värdet är ett nummer och även om det är ett belopp genom argumentet ChoiceDeposit.
        // Det returnerade värdet från CheckIfNumber stoppas sedan in i variabeln inputAmount.
            inputAmount = CheckIfNumber(choiceDeposit);

        // Kollar så att summan man försöker föra över är godkänd enligt logiken i ValidateAmount.
        // Det returnerade värdet från ValidateAmount stoppas sedan in i variabeln inputAmount.
            inputAmount = ValidateAmount(choiceDeposit, firstClient, inputAmount);

            player.SoundLocation = "ca-ching.wav";
            player.Play();

            Console.WriteLine();
            Console.Write($"Sucessfully deposited ");
            Colours.Green($"{inputAmount}");
            Console.WriteLine(" kr to your account!");

        // När transaktionen är godkänd säger vi att klientens checkingAcc är uppdaterat med summan av överföringen.
            firstClient.checkingAccount.amount += inputAmount;

            DateTime dateAndTime = DateTime.Now;

      

            Console.WriteLine($"{firstClient.name}, you now have {firstClient.checkingAccount} kr in your checking account");
            Console.WriteLine();

            string toAccountType = "Checking Account";

        // Skapar ett objekt av transaktions klassen från en konstruktor.
            Transactions trans = new Transactions(dateAndTime, inputAmount, choiceDeposit, toAccountType, firstClient);
            
        // Lägger till den genomförda transaktionen till listan av transaktioner.
            transactionList.Add(trans);
        
        // Kallar på RepeatQuery för att ge användaren valet att göra en ny insättning med hjälp av angivet argument. 
            RepeatQuery(choiceDeposit);
        }

        // skapar funktionen för att kolla om inmatning är ett nummer eller en siffra och returnerar inmatning.
        public static decimal CheckIfNumber(string aTransactionType)
        {
            decimal input = 0;
        // skapar en for loop som testar input.
            for (int i = 0; i < 1; i++)
            {
        // Vid inmatning av id ovan referrerar programmet till nedanstående ReadLine.
                try
                {
                    input = decimal.Parse(Console.ReadLine());
                }

        // istället för att programmet kraschar går programmet över till catch.
                catch
                {
        // Felhanterar inmatning av insättning och överföring.
                    if (aTransactionType == choiceDeposit || aTransactionType == choiceTransaction)
                    {
                        Colours.Red("Not a number\n");
                        Console.Write("Please reenter the amount: ");
                        i -= 1;
                    }

        // Felhanterar inmatning av id.
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

        // skapar funktionen för att se om inmatning av insättning är korrekt enligt nedanstående logik.
        public static decimal ValidateAmount(string aTransactionType, Client client, decimal aInputAmount)
        {

        // Skapar en switch case för två olika scenarion. Insättning och Transaktion.
            switch (aTransactionType)
            {
        // När vi kallar på funktionen tas TransactionType in som argument för att välja vilket case programmet ska utföra.
                case "Deposit":
        // Går inte ur denna loop förrens användare har matat in mer än 100kr eller ett värde som är jämt delbart med 100.
                    while (aInputAmount < 100 || aInputAmount % 100 != 0)
                    {
                        if (aInputAmount < 100)
                        {
                            Colours.Red("You have to deposit a larger amount!\n");
                            Colours.Red("The smallest amount to deposit is 100 kr\n");
                            Console.WriteLine();
                            Console.Write("Enter the amount to deposit: ");
        // kallar på checkIfNumber igen för att mata in ett nytt värde.
                            aInputAmount = CheckIfNumber(choiceDeposit);
                        }
                        else if (aInputAmount % 100 != 0)
                        {
                            Colours.Red("You can only add amount in even 100 kr bills\n");
                            Console.WriteLine();
                            Console.Write("Enter the amount to deposit: ");
        // kallar på checkIfNumber igen för att mata in ett nytt värde.
                            aInputAmount = CheckIfNumber(choiceDeposit);
                        }
                    }
        // break till för detta case i switchen
                    break;

                case "Transaction":

        // Går inte ur denna loop förrens användare har matat in mer än 0kr eller ett värde som är mindre eller = klientens Checkacc.
                    while (aInputAmount <= 0 || aInputAmount > client.checkingAccount.amount)
                    {
                        if (aInputAmount <= 0)
                        {
                            Colours.Red("You have to deposit a larger amount!\n");
                            Colours.Red("You can only transfer a positive amount.\n");
                            Console.WriteLine();
                            Console.Write("Enter the amount to transfer: ");

        // kallar på checkIfNumber igen för att mata in ett nytt värde
                            aInputAmount = CheckIfNumber(choiceTransaction);
                        }
                        else if (aInputAmount > client.checkingAccount.amount)
                        {
                            Colours.Red("You can't transfer more money than you have\n");
                            Console.WriteLine($"You have {client.checkingAccount} kronor in your checking account");
                            Console.WriteLine();
                            Console.Write("Enter the amount to transfer: ");

        // kallar på checkIfNumber igen för att mata in ett nytt värde
                            aInputAmount = CheckIfNumber(choiceTransaction);
                        }
                    }

        // break till för detta case i switchen
                    break;
            }
            return aInputAmount;
        }

        // Skapar en metod för att ge användaren en möjlighet att göra ytterligare en insättning/överföring efter genomförd sådan.
        // Ger även användaren möjligheten att återgå till main menu om det önskas.
        // Tar in transaktionstypen för att utforma olika val utifrån värdet.
        public static void RepeatQuery(string aTransactionType)
        {
        // Skapar en variabel där inmatning av val sparas.
            string choice;
            Console.WriteLine();
            Console.WriteLine($"Would you like to make a new {aTransactionType.ToLower()}?");

        // Skapar en doWhile för att vi vill att programmet ska köra denna del tills avändaren har gjort ett val.
            do
            {
                Console.Write("Enter 'Y' or 'N': ");
        // konverterar valet till stor bokstav för att hantera ev fel av inmat av liten bokstav.
                choice = Console.ReadLine().ToUpper();

        // uppfylls nedanstående krav får användaren göra en ny insättning.
                if (choice == "Y" && aTransactionType == "Deposit")
                {
                    ExecuteDeposit();
                }

        // upfylls nedanstående krav får användaren göra en ny överföring.
                else if (choice == "Y" && aTransactionType == "Transaction")
                {
                    ExecuteTransactions();
                }
        // uppfylls nedanstående krav går programmet till huvudmenyn.
                else if (choice == "N")
                {
                    Menu.MainMenu();
                }
        // skriver användaren något annat än y och n skriv fel inmatning ut.
                else
                {
                    Colours.Red("Wrong input!\n");
                    Console.WriteLine();
                }
            } while (choice != "Y" && choice != "N");
        }
    }
}