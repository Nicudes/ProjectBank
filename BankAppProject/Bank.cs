using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Media;

namespace BankAppProject
{

    class Bank
    {
        static SoundPlayer Player = new SoundPlayer();

        //variabeln är till för att konton som skapas ska från nr 1001.
        private static int idNumberMaker = 1000;
       
      //CreateClient är till för att skapa ett klient objekt.
        public static void CreateClient()
        {
            int id = ++idNumberMaker;
            int checkingsAccount = 0;
            int savingsAccount = 5000;
            string fullName = null;
            string firstOrLast = "first";
            bool ValidateName;
            bool ContainsNumber;
            bool IsUpper;

            Console.WriteLine("Creating client");
            Console.WriteLine("----------------");

            do
            {
                ValidateName = false;
                IsUpper = true;

                Console.WriteLine();
                Console.Write($"Enter {firstOrLast} name: ");
                string input = Console.ReadLine();

                ContainsNumber = !input.All(char.IsLetter);

                if (ContainsNumber)
                {
                    Colours.Red("Name can not contain a number.\n");
                }
                else
                {
                    try
                    {
                        IsUpper = char.IsUpper(input.First());
                        if (!IsUpper)
                        {
                            Colours.Red("Name has to start with upper case.\n");
                        }
                        else
                        {
                            ValidateName = true;
                        }
                    }
                    catch
                    {
                        Colours.Red("Name contains no letters\n");
                    }
                }

                if (ValidateName && firstOrLast == "first")
                {
                    fullName = input;
                    firstOrLast = "last";
                    ValidateName = false;
                }
                else if (ValidateName && firstOrLast == "last")
                {
                    fullName += " " + input;
                    break;
                }
            } while (!ValidateName);

            //Vi skapar objektet creationDate av typen DateTime för att logga när kund är skapad.
            DateTime creationDate = DateTime.Now;

            //Vi skapar ett objekt utifrån en konstruktor i client som vi använder för att se kundens alla uppgifter. 
            Client client = new Client(fullName, id, creationDate, checkingsAccount, savingsAccount);
            Console.WriteLine();
            Player.SoundLocation = "confirm.wav";
            Player.Play();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------");
            Console.WriteLine("Client created");
            Console.WriteLine("----------------");
            Console.WriteLine($"Name: {fullName}\nID: {id}\nAccount created at: {creationDate}\nCheckings Account: {checkingsAccount}\nSavings Account:{savingsAccount}");
            Console.WriteLine("----------------");
            Console.ResetColor();

            //Den skapade klienten läggs till i vår klientlista.
            Client.clientList.Add(client);

            Console.WriteLine();
            Colours.Red("Press any key to return to Main Menu");
            Console.ReadKey();
            Menu.MainMenu();
        }

        //I denna metod skapar vi hårdkodade klienter som läggs till i början av programmet.
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

            Client.clientList.Add(Pelle);
            Client.clientList.Add(Johan);
            Client.clientList.Add(Okhuy);
            Client.clientList.Add(Smandy);
            Client.clientList.Add(Licke);
            Client.clientList.Add(Kroken);
        }
    }
}
