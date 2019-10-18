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
            string creationDate = Convert.ToString(DateTime.Now);

            Console.WriteLine("Create client");
            //Create an input for client name 
            string name = Console.ReadLine();
            //Creating an object from client constructor in the Client class with the previous input from the user
            int id = ++idNumberMaker;
            int checkingsAccount = 0;
            int savingsAccount = 5000;

            Client client = new Client(name, id, creationDate, checkingsAccount, savingsAccount);

           Console.WriteLine($"Client created!\nName: {name}\nID: {id}\nAccount created at: {creationDate}\nCheckings Account: {checkingsAccount}\nSavings Account:{savingsAccount}");
            Client.ClientList.Add(client);

            //Create a date of account creation, can be hardcoded
            //Create account automatic from the method CreateAccount
            //Writes client name and the ID that was created by the Client class
            Console.WriteLine();
            ShowClient();
        }
    

        public static void ShowClient()
        {
           
            foreach (Client clients in Client.ClientList)
            {
                Console.WriteLine($"ID: {clients.id}");
                Console.WriteLine($"Name: {clients.name}");


            }
            //Get the information from the stored Client list
            //Print out information
        }

        public void CreateAccount()
        {
            //Use the data from Client to create an account 
           //Gives the balance value in savings account + 5000


        }

        public void ShowTransactions()
        {
            //Get the information stored in transactions
            //Print out information 

        }
    }
}
