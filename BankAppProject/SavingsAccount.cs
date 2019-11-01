using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    // Skapar en klass som ärver från klassen BankAccount och tar in interfacet Iinterest.
    class SavingsAccount : BankAccount, IInterest
    {
        public SavingsAccount(decimal aAmount = 5000)
        {
            amount = aAmount;
        }

        //public SavingsAccount()
        //{

        //}

        // Skapar en variabel för startsaldot på sparkontot som alltid är 5000kr.
        int initialAmount = 5000;
    
    // implementerar interfacet Iinterest som är till för att applicera ränta bonus på sparkontot.
        public void Interest(Client client)
        {
    // Skapar variabeln interest som har värdet av 0.05% som är räntan man får i form av bonus på sparkontot.
            decimal interest = 1.0005m;

    // om logiken nedan uppfylls har klienten fått tillgång till bonus.
            if ((DateTime.Now.Date - client.creationDate.Date).Days >= 30 && client.savingsAccount.amount > initialAmount && client.interestBonus == false)
            {

    // Eftersom klientens sparkonto ska öka med 0.05%  får vi ta det befintliga saldot och öka det med räntan.
                client.savingsAccount.amount *= interest;

    // när klienten har fått bonus sätts interest bool till true.
                client.interestBonus = true;                              
            }
        }

    // skapar en metod för att kunna se ditt sparkonto.
        public override void ShowAccount()
        {
            Console.Title = "Savings Account";

            bool foundClient = false;
            bool IsNumber;
            int id = 0;

            Console.Write("Enter your id: ");
    // Testar ett nytt sätt att lösa funktionen av metoden CheckIfNumber. Fungerar att implementera den metoden här.
    // Programmet gör detta sålänge isNumber är false som används för att se om inmatning av id är en siffra.
            do
            {

    // Testar om inmatning av id är en siffra och konverterar ev rätt inmatning till int.
                try
                {
                    IsNumber = true;
                    id = int.Parse(Console.ReadLine());
                }

    // är inmatningen inte en siffra körs nedanstående kod.
                catch
                {
                    Console.WriteLine("Must be a number.");
                    IsNumber = false;
                }

    // om inmatning av id är korrekt skriver programmet ut information gällande matchande id för klient vid sparkonto.

                if (IsNumber)
                {
                    foreach (Client client in Client.clientList)
                    {
                        if (id == client.id)
                        {
                            Console.Title += $" - {client.name}";
                            Interest(client);
                            Console.WriteLine($"ID: {client.id}");
                            Console.WriteLine($"Name: {client.name}");
                            Console.WriteLine($"Savings Account Balance: {client.savingsAccount.amount.ToString("F2")}");
                            Console.WriteLine($"Member since: {client.creationDate}");
                            Console.WriteLine();
                            if (client.interestBonus == true)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("You have been awarded an interest bonus!");
                                Console.ResetColor();
                                Console.WriteLine();
                            }

                            foundClient = true;
                            break;
                        }
                    }
                }
            } while (!IsNumber);
    // hittar vi ingen klient i listan så skrivs nedanstående ut.
            if (!foundClient)
            {
                Colours.Red("No such client was found.");
            }
    // ger möjligheten till användare att återgå till huvudmenyn.
            Colours.Red("Press any key to return to Main Menu");
            Console.ReadKey();
            Menu.MainMenu();
        }
    }
}
