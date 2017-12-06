using System;
using System.Collections.Generic;

namespace MovieDatabase.Models
{

    //Declare enumerations for genre
    public enum Genre { comedy, romance, action, thriller, family, horror, western, scifi, war };
    
    public class Movie
    {
        // declare the movie properties and a constructor to initialise a blank movie
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public double Budget { get; set; }
        public int Rating { get; set; }
        public string URL { get; set; }
        public List<string> Actors { get; set; }
        public List<Genre> Genres { get; set; }

        //Blank Movie contructor
        public Movie()
        {
            Title = "";
            Year = 0;
            Director = "";
            Duration = 0;
            Budget = 0.0;
            Rating = 0;
            URL = "";
            Actors = new List<string>();
            Genres = new List<Genre>();
        }

        public void Reset()
        {
            Title = "";
            Year = 0;
            Director = "";
            Duration = 0;
            Budget = 0.0;
            Rating = 0;
            URL = "";
            Actors = new List<string>();
            Genres = new List<Genre>();
        }


    }

}
