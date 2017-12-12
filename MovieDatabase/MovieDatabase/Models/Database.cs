using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieDatabase.Models
{
    public class Database 
    {
        private List<Movie> db; // list of movies in the database
        private int _index; // position of current movie in the database 
        
        // initialise the database properties
        public Database()
        {
            db = new List<Movie>();
            _index = -1;
        }

        // A property to Return number of movies in the database
        public int Count()
        {
            int size = db.Count();
            return size;
        }

        // A property to return  current _index position which should be either
        // -1 if database is empty
        // 0 - db.Count-1 if database is not empty
        public int Index()
        {
            if (db.Count() > 0)
            {
                return _index - 1;
            }
            else 
            {
                return -1;
            }

        }

        // Add a movie to current position in database
        public void Add(Movie m)
        {
            db.Add(m);
            _index = db.Count() - 1;
        }

        // Return current movie or null if database empty
        public Movie Get()
        {
            if (db.Count() > 0)
            {
                return db.ElementAt(_index);
            }
            else
            {
                return null;
            }
            
        }

        // Delete current movie at index if there is a movie and update index 
        public void Delete()
        {
            if (_index == 0)
            {
                db.RemoveAt(_index);
            }
            else if (db.Count() > 0 && _index != 0)
            {
                db.RemoveAt(_index);
                _index--;
            }
        }

        // Update the current movie at index if there is a movie and update index
        public void Update(Movie m)
        {
            db.Insert(_index, m);
        }

        // Delete all movies from the database and reset index
        public void clear()
        {
            db.Clear();
            _index = 0;
        }

        // Move index position to first movie (0)
        // return true if index update was possible, false otherwise
        public bool First()
        {
            if (db.Count() > 0)
            {
                _index = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Move index position to last movie
        // true if index update was possible, false otherwise</returns>
        public bool Last()
        {
            if (db.Count() > 0)
            {
                _index = db.Count() - 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Move index position to next movie
        // true if index update was possible, false otherwise<
        public bool Next()
        {
            if (db.Count() > 0 && _index != (db.Count() - 1))
            {
                _index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Move index position to previous movie
        // true if index update was possible, false otherwise
        public bool Prev()
        {
            if (db.Count() > 0 && _index != 0)
            {
                _index--;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Load movies from a json file and set index to first record
        public void Load(string file)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "json files|*.json",
                Title = "Enter name of movie database file to load"
            };

            //if the user enters a filename and clicks save
            if (dialog.ShowDialog() == true)
            {
                file = dialog.FileName;
                string json = File.ReadAllText(file);
                db = JsonConvert.DeserializeObject<List<Movie>>(json);
            }

            _index = db.Count() - 1;
        }

        // Save movies to a Json file
        public void Save(string file)
        {
            var dialog = new SaveFileDialog()
            {
                Filter = "json files|*.json",
                Title = "Enter name of movie database file to save"
            };

            //if the user enters a filename and clicks save
            if (dialog.ShowDialog() == true)
            {
                file = dialog.FileName;
                string json = JsonConvert.SerializeObject(db);
                File.WriteAllText(file, json);
            }
        }

        // Following methods update the List of movies (db) to the specified order

        // order the database by year of movie
        public void OrderByYear()
        {
            db = (from y in db
                  orderby y.Year
                  select y).ToList();
        }

        // order the database by title of movie (ascending)
        public void OrderByTitle()
        {
            db = (from t in db
                  orderby t.Title
                  select t).ToList();
        }

        // order the database by duration of movie (ascending)
        public void OrderByDuration()
        {
            db = (from d in db
                  orderby d.Duration
                  select d).ToList();
        }

    }
}
