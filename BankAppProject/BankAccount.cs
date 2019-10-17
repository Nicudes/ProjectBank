using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
   abstract class BankAccount
    {
        protected int balance = 0;
        protected bool IsBonus = false;
        public virtual void ShowAccounts()
        {
            //När man anropar metoden ShowAccount så ska den implementeras på olika sätt i barnklasserna.
        }

        //public virtual bool CheckForBonus(Client aClient)
        //{
        //    //Metoden CheckForBonus ska kolla ifall man uppfyller kraven för att få bonus.
        //    //Metoden implementeras olika i barnklasserna utefter kraven som ställs i de individuella klasserna.
        //}
    }
}
