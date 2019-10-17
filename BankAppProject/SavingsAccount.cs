using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class SavingsAccount : BankAccount
    {
        public override void ShowAccount()
        {
            //Metoden ShowAccount implementeras olika i de två barnklasserna. De visar olika Listor av clients och konton.
            //Metoden ska visa client.id följt av client.name
            //Metoden ska visa vad det är för slags konto och hur mycket pengar som finns nuvarande i kontot
            //Ska visa dateAndTime
            /*
ID: 1001
Name: Sohail
Saving Balance: 5000krona
MemberSince: 2018-12-12 00:00:00 */
            base.ShowAccount();
        }

        public override void CheckForBonus()
        {
            //Kraven är samma som i CheckingsAccount, alltså att man har mer pengar i kontot än de första 30 dagarna.
            //Uppfyller man kraven sätts en bool??? till true som i sin tur godkänner de olika bonusarna i de olika kontona.
            base.CheckForBonus();
        }
    }
}
