using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    //Abstrakt klass för att vi vill inte skapa objekt härifrån.
   abstract class BankAccount
    {
        public decimal amount;
        //en virtual metod som overridas i barnklasserna med egen logik.
        public virtual void ShowAccount()
        {
            
        }

        //Loopar igenom klientlistan och visar all information om varje klient.
        public static void ShowAllAccounts()
        {
            Console.Title = "All Clients";
            foreach (Client client in Client.clientList)
            {
                Console.WriteLine($"ID: {client.id}");
                Console.WriteLine($"Name: {client.name}");
                Console.WriteLine($"Checking Account Balance: {client.checkingAccount.amount} kr");
                Console.WriteLine($"Savings Account Balance: {client.savingsAccount.amount} kr");
                Console.WriteLine($"Member since: {client.creationDate}");

                Console.WriteLine();                
            }
            Colours.Red("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(new string(' ', Console.BufferWidth - (Console.CursorTop - 2)));
            Console.SetCursorPosition(1, Console.CursorTop - 2);
        }
    }
}
