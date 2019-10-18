using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class SavingsAccount : BankAccount
    {
        //int savingsBalance = 5000;
        public override void ShowAccounts()
        {
            //Metoden ShowAccount implementeras olika i de två barnklasserna. De visar olika Listor av clients och konton.
            //Metoden ska visa aClient.id följt av aClient.name
            //Metoden ska visa vad det är för slags konto och hur mycket pengar som finns nuvarande i kontot
            //Ska visa dateAndTime

            

            foreach (Client client in Client.ClientList)
            {
                Console.WriteLine($"ID: {client.id}");
                Console.WriteLine($"Name: {client.name}");
                Console.WriteLine($"Savings Account Balance: {client.savingsAccount}");
                Console.WriteLine($"Member since: {client.creationDate}");
                if (IsBonus == true)
                {
                    Console.WriteLine("Bonus mother fucker!!");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

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
