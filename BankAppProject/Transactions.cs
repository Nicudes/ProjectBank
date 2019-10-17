using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Transactions
    {
        List<string> ListOfTransactions = new List<string>();
        public string dateAndTime;

        public bool ConfirmTransactions(bool IsTrue)
        {
            
            //Kolla om transaction value <= Balance
            //Kolla om överföringen är från CheckingsAccount till Savingsaccount 
            //Kolla om överföringen är mellan olika CheckingsAccount
            //Kolla om det är en insättning
            //Om inte dessa krav uppfylls så skriv ut ett felmeddelande

            //Om det här uppfylls så
            return IsTrue = true;
        }

        public void ExecuteTransactions()
        {
            //Om ConfirmTransaction IsTrue är True så genomför transaktionen
            //Get set för den nya Balance i respektive konto 
            //Konto där överföringen genomförs get set - transaction amount
            //Mottagarkonto get set + transaction amount
            //Spara transaction information för client
            //Skriv dataTime och informationen för transaktionen


        }
    }
}
