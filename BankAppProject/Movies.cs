using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Movies
    {
        public string title;
        public int ticketsAvailable;
        public int indexPlace;

        public static List<Movies> movieList = new List<Movies>();

        public Movies(string aTitle, int aTicketsAvailable, int aIndexPlace)
        {
            title = aTitle;
            ticketsAvailable = aTicketsAvailable;
            indexPlace = aIndexPlace;
        }
        public static void AddMovies()
        {
            Movies movie1 = new Movies("Bamse och dunderklockan", 1, 1);
            Movies movie2 = new Movies("Joker", 1, 2);
            Movies movie3 = new Movies("Lejonkungen", 1, 3);
            Movies movie4 = new Movies("Hustlers", 1, 4);
            Movies movie5 = new Movies("Husdjurens hemliga liv 2", 1, 5);
            Movies movie6 = new Movies("Hasse och Tage - en kärlekshistoria", 1, 6);
            Movies movie7 = new Movies("Gemini Man", 3, 7);
            Movies movie8 = new Movies("Good Boys", 1, 8);
            Movies movie9 = new Movies("Dora and the lost City", 4, 9);
            Movies movie10 = new Movies("Ad Astra", 2, 10);

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
