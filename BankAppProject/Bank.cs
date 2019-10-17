using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Bank
    {
        public int idNumberMaker;

        public static void CreateClient()
        {
            Console.WriteLine("Create Client method");
            //Create an input for client name 
            //Client enters a name
            //Creates client object from client class construtor (Method to create an ID)
            //Create a date of account creation, can be hardcoded
            //Create account automatic from the method CreateAccount
            //Writes client name and the ID that was created by the Client class


        }

        public void ShowClient()
        {
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
