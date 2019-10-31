using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    //Checking account ärver ifrån Bank account och tar in interfacet IcinemaTicket.
    class CheckingAccount : BankAccount, ICinemaTicket
    {
        public CheckingAccount(decimal aAmount = 0)
        {
            amount = aAmount;
        }

        //public CheckingAccount()
        //{

        //}
        /// <summary>
        /// Kolla upp om vi kan göra det bättre, används för att skriva ut wrong input 4 id or wrong input 4 amount
        /// </summary>
        private string choiceId = "id";
        private static int ticketAmount = 10;

     // En overridad metod som vi använder för att se ett specifikt kontos checking account + väsentliga uppgfiter.
        public override void ShowAccount()
        {
     // Använder en bool för att säga om vi har hittat ett konto eller inte vid input av id nr.
            bool foundClient = false;

            Console.WriteLine("Enter your ID:");
            decimal inputId = Transactions.CheckIfNumber(choiceId);

            foreach (Client client in Client.clientList)
            {
                if (inputId == client.id)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine($"ID: {client.id}");
                    Console.WriteLine($"Name: {client.name}");
                    Console.WriteLine($"Checking Account Balance: {client.checkingAccount.amount}");
                    Console.WriteLine($"Member since: {client.creationDate}");
                    Console.WriteLine("----------------");

     // om det finns mer än 0 biobiljetter och klient ej fått bonus ska programmet gå igenom interfacet
                    if (ticketAmount > 0 && client.cinemaBonus == false)
                    {
                        CinemaTicket(client);
                    }
                    Console.WriteLine();
     //om klient har fått bonus och valt film för sin biobiljett ska vi skriva ut filmens namn.
                    if (client.cinemaBonus == true && client.movieChoice != null)
                    {
                        //Vill vi ha ljud?
                        Console.Write("You have a free cinema ticket for "); Colours.Cyan(client.movieChoice.title);
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    foundClient = true;
                    break;
                }
   
            }
            if (!foundClient)
            {
                Console.WriteLine("Couldn't find the id.");

            }
            Colours.Red("Press any key to return to Main Menu");
            Console.ReadKey();
            Menu.MainMenu();
        }

     //Denna metoden kollar om klienten har uppfyllt kraven för att få en biobiljett och skriver isf ut det.
        public void CinemaTicket(Client client)
        {
     // Kraven för att klient ska uppnå biobiljetts bonus.
            if ((DateTime.Now.Date - client.creationDate.Date).Days > 30 && client.checkingAccount.amount > 100 && client.cinemaBonus == false)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("You have received a free cinema ticket!");
                Console.ResetColor();
                Console.WriteLine();

     // skapar en counter för att visa en siffra framför filmerna i filmmenyn.
                int counter = 1;
                // loopar igenom filmlistan och skriver ut objektens attribut för filmernas titel.
                foreach (Movies movie in Movies.movieList)
                {
                    Console.Write(counter + ") "); Colours.Cyan(movie.title);
                    Console.WriteLine();
                    Console.Write("     tickets left: ");

                    if (movie.ticketsAvailable < 2)
                    {
                        Colours.Red($"{movie.ticketsAvailable}\n");
                    }
                    else
                    {
                        Colours.Green($"{movie.ticketsAvailable}\n");
                    }
                    Console.WriteLine("-------");
                    Console.WriteLine();
                    counter++;
                }
                Console.Write("0) "); Colours.Red("No thanks, I don't want a movie ticket\n");
                // använder variablen för att jämföra user input med filmobjektets indexPlace.
                string choice;
     // använder variablen för att användaren alltid ska behöva göra ett val tills ett möjligt val är gjort.
                bool invalidInput;
     // använder variabeln för att säga om vi har hittat en film eller inte.
                bool foundMovie = false;

                do
                {
                    Console.WriteLine();
                    Console.Write("Choose which movie: ");
                    Console.WriteLine();

                    choice = Console.ReadLine();

                    invalidInput = false;

     // loopar igenom movielistan och kollar om användarens val stämmer överrens med filmobjektets indexPlace.
                    foreach (Movies movie in Movies.movieList)
                    {
     //  konverterar till string för att vi senare i IF, måste jämföra två likadana datatyper.
     //  Använder oss utav string för att det hanterar även bokstäver vid inmatning
                        string indexPlace = Convert.ToString(movie.indexPlace);

                        if (choice == indexPlace)
                        {
     // Tar in movie och klient som argument för att vi vill ha klientens val av film.
                            Movies.UpdateMovies(movie, client);
                            foundMovie = true;
                            break;
                        }
                    }
                    if (choice == "0")
                    {
                        Console.WriteLine("You chose not to go to the movies.");
                        client.movieChoice = null;
                    }
                    else if (!foundMovie)
                    {
                        Console.WriteLine("Invalid input");
                        invalidInput = true;
                    }
                } while (invalidInput);

                client.cinemaBonus = true;
            }
     // detta är else if till första if. Hade detta varit en enskild if hade programmet kört båda stegen
     // När vi har valt en biljett sedan innan.
            else if (client.cinemaBonus == true)
            {
                Console.WriteLine();
                Console.Write($"You have claimed a cinema ticket for "); Colours.Cyan(client.movieChoice.title);
                Console.WriteLine();
            }
        }
    }
}
