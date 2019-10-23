using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class SavingsAccount : BankAccount, IInterest
    {
        bool shownMessage;

        public void Interest(Client client)
        {
            decimal interest = 1.0005m;

            if ((DateTime.Now.Date - client.creationDate.Date).Days >= 30 && client.savingsAccount >= 6000 && client.interestBonus == false)
            {
                client.savingsAccount *= interest;
                client.interestBonus = true;
                              
            }
            

        }

        //int savingsBalance = 5000;
        public override void ShowAccounts()
        {
            //Metoden ShowAccount implementeras olika i de två barnklasserna. De visar olika Listor av clients och konton.
            //Metoden ska visa aClient.id följt av aClient.name
            //Metoden ska visa vad det är för slags konto och hur mycket pengar som finns nuvarande i kontot
            //Ska visa dateAndTime

            bool foundClient = false;
           
            do
            {
                Console.WriteLine("Enter your ID");
                int inputId = int.Parse(Console.ReadLine());

                foreach (Client client in Client.ClientList)
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

                            if (!shownMessage)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("You have the interest bonus!");
                                Console.ResetColor();
                                Console.WriteLine();
                                shownMessage = true;
                            }
                            else if (shownMessage == true)
                            {
                                Console.WriteLine("You have the interest bonus!");
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

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

            } while (!foundClient);

            

           
            /*
ID: 1001
Name: Sohail
Saving Balance: 5000krona
MemberSince: 2018-12-12 00:00:00 */
        }



        //public override bool CheckForBonus(Client aClient)
        //{
        //    //Kraven är samma som i CheckingsAccount, alltså att man har mer pengar i kontot än de första 30 dagarna.
        //    //Uppfyller man kraven sätts en bool??? till true som i sin tur godkänner de olika bonusarna i de olika kontona.
            
        //    if (balance > initialBalance)
        //    {
        //        return IsBonus = true;
        //    }
        //    else
        //    {
        //        return IsBonus = false;
        //    }

        //}
    }
}
