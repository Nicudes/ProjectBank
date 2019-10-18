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
            
        }

        public static void ShowAllAccounts()
        {
            
            foreach (Client client in Client.ClientList)
            {
                //Första vi vill göra är att kolla ifall klientens saldo är större än det klienten hade de första 30 dagarna
                //CheckForBonus(client);
                Console.WriteLine($"ID: {client.id}");
                Console.WriteLine($"Name: {client.name}");
                Console.WriteLine($"Checking Account Balance: {client.checkingsAccount}");
                Console.WriteLine($"Savings Account Balance: {client.savingsAccount}");
                Console.WriteLine($"Member since: {client.creationDate}");

                Console.WriteLine();
                
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        //public virtual bool CheckForBonus(Client aClient)
        //{
        //    //Metoden CheckForBonus ska kolla ifall man uppfyller kraven för att få bonus.
        //    //Metoden implementeras olika i barnklasserna utefter kraven som ställs i de individuella klasserna.
        //}
    }
}
