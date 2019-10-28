using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class SavingsAccount : BankAccount, IInterest
    {
        public string choiceId = "id";
        int initialAmount = 5000;

        public void Interest(Client client)
        {
            decimal interest = 1.0005m;

            if ((DateTime.Now.Date - client.creationDate.Date).Days >= 30 && client.savingsAccount > initialAmount && client.interestBonus == false)
            {
                client.savingsAccount *= interest;
                client.interestBonus = true;                              
            }
        }

        public override void ShowAccount()
        {
            bool foundClient = false;
            bool IsNumber;
            int id = 0;

            Console.Write("Enter your id: ");

            do
            {
                try
                {
                    IsNumber = true;
                    id = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Must be a number.");
                    IsNumber = false;
                }

                //decimal inputId = Transactions.CheckIfNumber(choiceId);
                if (!IsNumber)
                {
                    foreach (Client client in Client.clientList)
                    {
                        if (id == client.id)
                        {
                            Interest(client);
                            Console.WriteLine($"ID: {client.id}");
                            Console.WriteLine($"Name: {client.name}");
                            Console.WriteLine($"Savings Account Balance: {client.savingsAccount.ToString("F2")}");
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

            if (!foundClient)
            {
                Colours.Red("No such client was found.");
            }

            Colours.Red("Press any key to return to Main Menu");
            Console.ReadKey();
            Menu.MainMenu();
        }
    }
}
