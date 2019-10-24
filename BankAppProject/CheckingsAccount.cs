using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class CheckingsAccount : BankAccount, ICinemaTicket
    {
        public string id = "id";
        static int ticketAmount = 10;

        public override void ShowAccounts()
        {

            {
                bool foundClient = false;

                Console.WriteLine("Enter your ID:");

                decimal inputId = Transactions.CheckIfNumber(id);

                foreach (Client client in Client.ClientList)
                {
                    if (inputId == client.id)
                    {

                        Console.WriteLine("----------------");
                        Console.WriteLine($"ID: {client.id}");
                        Console.WriteLine($"Name: {client.name}");
                        Console.WriteLine($"Checking Account Balance: {client.checkingsAccount}");
                        Console.WriteLine($"Member since: {client.creationDate}");
                        Console.WriteLine("----------------");

                        if (ticketAmount > 0)
                        {
                            CinemaTicket(client);
                        }
                        Console.WriteLine();

                        Console.WriteLine();
                        foundClient = true;
                        break;
                    }
                }

                if (!foundClient)
                {
                    Console.WriteLine("Couldn't find the id.");

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ResetColor();
                Console.ReadKey();
                Menu.MainMenu();
            }
        }


        public void CinemaTicket(Client client)
        {
            //Kravspecändring kontot måste ha mer än 100kr för att få biobiljett
            if ((DateTime.Now.Date - client.creationDate.Date).Days > 30 && client.checkingsAccount > 100 && client.cinemaBonus == false)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("You have received a free cinema ticket!");
                Console.ResetColor();
                Console.WriteLine();

                int counter = 1;

                foreach (Movies movie in Movies.movieList)
                {
                    Console.WriteLine(counter + ". " + movie.title);
                    counter++;
                }

                string choice;
                bool choiceMade;
                bool foundMovie = false;

                do
                {
                    Console.WriteLine();
                    Console.Write("Choose which movie: ");
                    Console.WriteLine();

                    choice = Console.ReadLine();

                    choiceMade = false;

                    foreach (Movies movie in Movies.movieList)
                    {
                        string indexPlace = Convert.ToString(movie.indexPlace);

                        if (choice == indexPlace)
                        {
                            UpdateMovies(movie, client);
                            foundMovie = true;
                            break;
                        }
                    }
                    if (!foundMovie)
                    {
                        Console.WriteLine("Invalid input");
                        choiceMade = true;
                    }
                } while (choiceMade);

                client.cinemaBonus = true;
            }
            else if (client.cinemaBonus == true)
            {
                Console.WriteLine();
                Console.Write($"You have claimed a cinema ticket for ");
                Colours.Cyan(client.movieChoice);
                Console.WriteLine();
            }
        }

        public static void UpdateMovies(Movies movie, Client client)
        {
            Console.WriteLine("Du valde: " + movie.title);
            client.movieChoice = movie.title;
            movie.ticketsAvailable--;

            if (movie.ticketsAvailable == 0)
            {
                foreach (Movies movieCompare in Movies.movieList)
                {
                    if (movie.indexPlace < movieCompare.indexPlace)
                    {
                        movieCompare.indexPlace--;
                    }
                }
                Movies.movieList.Remove(movie);
            }
        }
    }
}
