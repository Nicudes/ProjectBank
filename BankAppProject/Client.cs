﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Client
    {
        public int id;
        public string name;
        public DateTime creationDate;
        public decimal checkingsAccount;
        public decimal savingsAccount;
        public bool cinemaBonus;
        public bool interestBonus;

        //Skapa en konstruktor för Client som ska innehålla Name och ID 
        public Client(string aName, int aId, DateTime aCreationDate, decimal aCheckingsAccount, decimal aSavingsAccount)
        {
            name = aName;
            id = aId;
            creationDate = aCreationDate;
            checkingsAccount = aCheckingsAccount;
            savingsAccount = aSavingsAccount;
        }

        public Client(int aId, bool aCinemaBonus, bool aInterestBonus)
        {
            id = aId;
            cinemaBonus = aCinemaBonus;
            interestBonus = aInterestBonus;
        }

        public Client()
        {

        }

        public static List<Client> ClientList = new List<Client>();
        

        

    }
}
