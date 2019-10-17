using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
   abstract class BankAccount
    {
        protected int balance;

        public virtual void ShowAccount()
        {
            //När man anropar metoden ShowAccount så ska den implementeras på olika sätt i barnklasserna.
        }

        public virtual void CheckForBonus()
        {
            //Metoden CheckForBonus ska kolla ifall man uppfyller kraven för att få bonus.
            //Metoden implementeras olika i barnklasserna utefter kraven som ställs i de individuella klasserna.
        }
    }
}
