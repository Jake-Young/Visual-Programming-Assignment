using System;
using System.Collections.Generic;

namespace MovieDatabase.Models
{

    //Declare enumerations for genre
    public enum Genre { comedy, romance, action, thriller, family, horror, western, scifi, war };
    
    public class Movie
    {
        // declare the movie properties and a constructor to initialise a blank movie
        //public string Title { get; set; }
        //public int Year { get; set; }
        //public string Director { get; set; }
        //public int Duration { get; set; }
        //public double Budget { get; set; }
        //public int Rating { get; set; }
        //public string URL { get; set; }
        //public List<string> Actors { get; set; }
        //public List<Genre> Genres { get; set; }

        public string Title;
        public string Director;
        public string URL;
        public string Cast;
        public int Year;
        public int Duration;
        public int Rating;
        public double Budget;
        public List<string> Actors { get; set; }
        public List<Genre> Genres { get; set; }


        string getTitle()
        {
            return Title;
        }

        void setTitle(string newTitle)
        {
            this.Title = newTitle;
        }


        string getDirector()
        {
            return Director;
        }

        void setDirector(string newDirector)
        {
            this.Director = newDirector;
        }

        string getPoster()
        {
            return URL;
        }

        void setPoster(string newPoster)
        {
            this.URL = newPoster;
        }


        string getCast()
        {
            return Cast;
        }

        void setCast(string newCast)
        {
            this.Cast = newCast;
        }


        int getYear()
        {
            return Year;
        }

        void setYear(int newYear)
        {
            this.Year = newYear;
        }

        int getduration()
        {
            return Duration;
        }

        void setduration(int newduration)
        {
            this.Duration = newduration;
        }

        int getRating()
        {
            return Rating;
        }

        void setRating(int newRating)
        {
            this.Rating = newRating;
        }


        double getBudget()
        {
            return Budget;
        }

        void setBudget(double newBudget)
        {
            this.Budget = newBudget;
        }

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
