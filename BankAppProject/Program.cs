using System;
using System.Collections.Generic;
using System.Linq;
using Snakeclass;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hello class! 
            Console.SetWindowSize(100, 40);
            Console.Title = "Bank Application -- Created by: Huy, Alexander, Mikael & Andreas";
            //Bank.AddExistingClients();
            Movies.AddMovies();
            Menu.CheckPassword();
            Menu.MainMenu();
        }
    }
}
