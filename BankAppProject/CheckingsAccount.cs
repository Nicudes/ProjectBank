using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class CheckingsAccount : BankAccount, ICinemaTicket
    {
        public override void ShowAccounts()
        {
            //Metoden ShowAccount implementeras olika i de två barnklasserna. De visar olika Listor av clients och konton.
            //Metoden ska visa aClient.id följt av aClient.name
            //Metoden ska visa vad det är för slags konto och hur mycket pengar som finns nuvarande i kontot
            //Ska visa creationDate

            //Vi skapade en foreach loop för att skriva ut varje klient som vi har i vår klientlista

            
            foreach (Client client in Client.ClientList)
            {
                //Första vi vill göra är att kolla ifall klientens saldo är större än det klienten hade de första 30 dagarna
                //CheckForBonus(client);
                Console.WriteLine($"ID: {client.id}");
                Console.WriteLine($"Name: {client.name}");
                Console.WriteLine($"Checking Account Balance: {client.checkingsAccount}");
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
CheckingAccount Balance: 2000krona
MemberSince: 2018-12-12 00:00:00 */
        }

        public void CinemaTicket()
        {
            //Kolla igenom klientlistan och se om saldot nu är mer än på creationdate
            //Sätta true på variablen som berättar om kunden har fått bonus
            //skriva ut vid visa checkingaccount bonusen på biobiljett

            foreach (Client client in Client.ClientList)
            {
                if(client.checkingsAccount > 0 && client.creationDate.AddDays(30) <= DateTime.Now)
                {
                    Console.WriteLine("You have revieved a free cinema ticket!");
                }
            }
        }

        

        //public override bool CheckForBonus(Client aClient)
        //{
        //        //Kraven är samma som i SavingsAccount, alltså att man har mer pengar i kontot än de första 30 dagarna.
        //        //Uppfyller man kraven sätts en bool??? till true som i sin tur godkänner de olika bonusarna i de olika kontona.

        //        if (aClient.balance > 0 && )
        //        {
        //            return IsBonus = true;
        //        }
        //        else
        //        {
        //            return IsBonus = false;
        //        }

        //        //Ska CheckForBonusmetoden finnas i metoden ShowAccounts så att den alltid kollar?

        //}
    }
}
