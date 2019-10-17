using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("1. Create client");
            Console.WriteLine("2. Exit");
            Console.WriteLine();

            Console.Write("Input: ");

            string choice;

            do
            {
                choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Bank.CreateClient();
                        //MainMenu();
                        break;

                    case "2":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                } 
            } while (choice != "2");
        }
    }
}
