using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class CheckingsAccount : BankAccount, ICinemaTicket
    {
        public string id = "id";
        

        public override void ShowAccounts()
        {

            {
                bool foundClient = false;
             
                    Console.WriteLine("Enter your ID:");

                    decimal inputId = Transactions.CheckIfNumber(id);

                    foreach (Client client in Client.ClientList)
                    {
                        if (inputId == client.id)
                        {

                        Console.WriteLine("----------------");
                        Console.WriteLine($"ID: {client.id}");
                        Console.WriteLine($"Name: {client.name}");
                        Console.WriteLine($"Checking Account Balance: {client.checkingsAccount}");
                        Console.WriteLine($"Member since: {client.creationDate}");
                        Console.WriteLine("----------------");

                        CinemaTicket(client);
                            Console.WriteLine();
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


        public void CinemaTicket(Client client)
        {
            //Kravspecändring kontot måste ha mer än 100kr för att få biobiljett
            if ((DateTime.Now.Date - client.creationDate.Date).Days > 30 && client.checkingsAccount > 100 && client.cinemaBonus == false)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("You have received a free cinema ticket!");
                Console.ResetColor();
                client.cinemaBonus = true;
            }
            else if(client.cinemaBonus == true)
            {
                Console.WriteLine();
                Console.WriteLine("You have received a free cinema ticket!");
            }
        }
    }
}
