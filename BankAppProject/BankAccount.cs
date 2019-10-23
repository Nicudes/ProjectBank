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
    }
}
