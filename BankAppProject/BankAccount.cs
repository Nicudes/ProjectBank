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

        public virtual void ShowAccount()
        {
            
        }

        public static void ShowAllAccounts()
        {            
            foreach (Client client in Client.clientList)
            {
                Console.WriteLine($"ID: {client.id}");
                Console.WriteLine($"Name: {client.name}");
                Console.WriteLine($"Checking Account Balance: {client.checkingAccount}");
                Console.WriteLine($"Savings Account Balance: {client.savingsAccount}");
                Console.WriteLine($"Member since: {client.creationDate}");

                Console.WriteLine();                
            }
            Colours.Red("Press any key to continue");
            Console.ReadKey();
        }
    }
}
