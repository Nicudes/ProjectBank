using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Bank
    {
      public static int idNumberMaker=1000;
       
        public static void CreateClient()
        {
            DateTime creationDate = DateTime.Now;

            int id = ++idNumberMaker;
            int checkingsAccount = 0;
            int savingsAccount = 5000;


            Console.WriteLine("Creating client");
            Console.WriteLine("----------------");
            Console.WriteLine("Enter client name:");
            string name = Console.ReadLine();
            Client client = new Client(name, id, creationDate, checkingsAccount, savingsAccount);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------");
            Console.WriteLine("Client created");
            Console.WriteLine("----------------");
            Console.WriteLine($"Name: {name}\nID: {id}\nAccount created at: {creationDate}\nCheckings Account: {checkingsAccount}\nSavings Account:{savingsAccount}");
            Console.WriteLine("----------------");
            Console.ResetColor();

            Client.ClientList.Add(client);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ResetColor();
            Console.ReadKey();
            Menu.MainMenu();
        }

        public static void AddExistingClients()
        {
            Client Pelle = new Client("Pelle", ++idNumberMaker, DateTime.Now, 0, 5000);
            {
                DateTime value = new DateTime(2017, 1, 11);
                Pelle.creationDate = value;
            }
            Client Johan = new Client("Johan", ++idNumberMaker, DateTime.Now, 0, 5000);
            {
                DateTime value = new DateTime(2017, 1, 11);
                Johan.creationDate = value;
            }
            Client Okhuy = new Client("Okhuy", ++idNumberMaker, DateTime.Now, 0, 5000);
            {
                DateTime value = new DateTime(2017, 1, 11);
                Okhuy.creationDate = value;
            }
            Client Smandy = new Client("Smandy", ++idNumberMaker, DateTime.Now, 0, 5000);
            {
                DateTime value = new DateTime(2017, 1, 11);
                Smandy.creationDate = value;
            }
            Client Licke = new Client("Licke", ++idNumberMaker, DateTime.Now, 0, 5000);
            {
                DateTime value = new DateTime(2017, 1, 11);
                Licke.creationDate = value;
            }
            Client Kroken = new Client("Kroken", ++idNumberMaker, DateTime.Now, 0, 5000);
            {
                DateTime value = new DateTime(2017, 1, 11);
                Kroken.creationDate = value;
            }
            Client.ClientList.Add(Pelle);
            Client.ClientList.Add(Johan);
            Client.ClientList.Add(Okhuy);
            Client.ClientList.Add(Smandy);
            Client.ClientList.Add(Licke);
            Client.ClientList.Add(Kroken);

        }
    }
}
