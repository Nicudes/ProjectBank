using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Client
    {
        public string name;
        public int id;
        public DateTime creationDate;
        public decimal checkingAccount;
        public decimal savingsAccount;
        public string movieChoice;
        public bool cinemaBonus;
        public bool interestBonus;

        public static List<Client> clientList = new List<Client>();

        public Client(string aName, int aId, DateTime aCreationDate, decimal aCheckingsAccount, decimal aSavingsAccount)
        {
            name = aName;
            id = aId;
            creationDate = aCreationDate;
            checkingAccount = aCheckingsAccount;
            savingsAccount = aSavingsAccount;
        }

        public Client(int aId, bool aCinemaBonus, bool aInterestBonus)
        {
            id = aId;
            cinemaBonus = aCinemaBonus;
            interestBonus = aInterestBonus;
        }
        public Client(string aMovieChoice)
        {
            movieChoice = aMovieChoice;
        }

        public Client()
        {

        }
    }
}
