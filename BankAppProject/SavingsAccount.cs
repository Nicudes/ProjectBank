using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class SavingsAccount : BankAccount, IInterest
    {
        bool messageShown;
        public string choiceId = "id";

        public void Interest(Client client)
        {
            decimal interest = 1.0005m;

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // Skapa initialAmount eller liknande och sätt värden där för att inte hårdkoda in värden i metoden.//
            //////////////////////////////////////////////////////////////////////////////////////////////////////

            if ((DateTime.Now.Date - client.creationDate.Date).Days >= 30 && client.savingsAccount >= 6000 && client.interestBonus == false)
            {
                client.savingsAccount *= interest;
                client.interestBonus = true;                              
            }
        }

        public override void ShowAccount()
        {
            bool foundClient = false;

            Console.WriteLine("Enter your ID");
            decimal inputId = Transactions.CheckIfNumber(choiceId);

            foreach (Client client in Client.clientList)
            {
                if (inputId == client.id)
                {
                    Interest(client);
                    Console.WriteLine($"ID: {client.id}");
                    Console.WriteLine($"Name: {client.name}");
                    Console.WriteLine($"Savings Account Balance: {client.savingsAccount}");
                    Console.WriteLine($"Member since: {client.creationDate}");
                    Console.WriteLine();
                    if (client.interestBonus == true)
                    {
                        /* Vi vill visa grön bakgrund endast första gången man visar klient.
                         Efterföljande gånger ska ingen färg visas. Nu visas grön bakgrund vid varje tillfälle */

                        if (!messageShown)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("You have the interest bonus!");
                            Console.ResetColor();
                            Console.WriteLine();
                            messageShown = true;
                        }
                        else if (messageShown == true)
                        {
                            Console.WriteLine("You already have the bonus");
                        }
                    }

                    foundClient = true;
                    break;
                }
            }

            if (!foundClient)
            {
                Console.WriteLine("Couldn't find the id.");

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ResetColor();
            Console.ReadKey();
            Menu.MainMenu();
        }
    }
}
