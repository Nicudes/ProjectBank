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
        public CheckingAccount checkingAccount;
        public SavingsAccount savingsAccount;
        public string movieChoice;
        public bool cinemaBonus;
        public bool interestBonus;

        // Vi skapar en lista där alla klientobjekt adderas.
        public static List<Client> clientList = new List<Client>();
// Vi har olika konstruktorer för olika syften.
// Denna konstruktorn används för att skapa klientobjekten.
        public Client(string aName, int aId, DateTime aCreationDate, CheckingAccount aCheckingsAccount, SavingsAccount aSavingsAccount)
        {
            name = aName;
            id = aId;
            creationDate = aCreationDate;
            checkingAccount = aCheckingsAccount;
            savingsAccount = aSavingsAccount;
        }
// Denna konstruktor använder vi för klienternas bonus.
        public Client(int aId, bool aCinemaBonus, bool aInterestBonus, string aMovieChoice)
        {
            id = aId;
            cinemaBonus = aCinemaBonus;
            interestBonus = aInterestBonus;
            movieChoice = aMovieChoice;
        }

        public Client()
        {

        }
    }
}
