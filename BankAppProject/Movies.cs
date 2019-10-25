using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Movies
    {
        public int indexPlace;
        public string title;
        public int ticketsAvailable;

        public static List<Movies> movieList = new List<Movies>();

        public Movies(int aIndexPlace, string aTitle, int aTicketsAvailable)
        {
            indexPlace = aIndexPlace;
            title = aTitle;
            ticketsAvailable = aTicketsAvailable;
        }

        public static void AddMovies()
        {
            Movies movie1 = new Movies(1, "Bamse och dunderklockan", 1);
            Movies movie2 = new Movies(2, "Joker", 1);
            Movies movie3 = new Movies(3, "Lejonkungen", 1);
            Movies movie4 = new Movies(4, "Hustlers", 1);
            Movies movie5 = new Movies(5, "Husdjurens hemliga liv 2", 1);
            Movies movie6 = new Movies(6, "Hasse och Tage - en kärlekshistoria", 1);
            Movies movie7 = new Movies(7, "Gemini Man", 3);
            Movies movie8 = new Movies(8, "Good Boys", 1);
            Movies movie9 = new Movies(9, "Dora and the lost City", 4);
            Movies movie10 = new Movies(10, "Ad Astra", 2);

            movieList.Add(movie1);
            movieList.Add(movie2);
            movieList.Add(movie3);
            movieList.Add(movie4);
            movieList.Add(movie5);
            movieList.Add(movie6);
            movieList.Add(movie7);
            movieList.Add(movie8);
            movieList.Add(movie9);
            movieList.Add(movie10);
        }
    }
}
