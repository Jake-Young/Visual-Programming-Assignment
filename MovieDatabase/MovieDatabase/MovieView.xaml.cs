using Microsoft.Win32;
using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieDatabase
{
    public enum WindowMode { View, Create, Edit };

    /// <summary>
    /// Interaction logic for MovieView.xaml
    /// </summary>
    public partial class MovieView : Window
    {

        private Movie NM;
        private Database NDB;
        private WindowMode Mode;

        public MovieView()
        {
            InitializeComponent();
            NM = new Movie();
            NDB = new Database();
            SetUIMode(WindowMode.View);
        }

        // Create what ever methods you deem necessary to provide a functioning UI

        private Movie UpdateMovieFromUI(Movie M)
        {
            M.Title = TitleTxt.Text;
            M.Year = Convert.ToInt32(YearTxt.Text.ToString());
            M.Director = DirectorTxt.Text;
            M.Duration = Convert.ToInt32(DurationTxt.Text.ToString());
            M.Budget = Convert.ToDouble(BudgetTxt.Text.ToString());
            M.Rating = Rating.Value;
            M.URL = MovieURLTxt.Text;
            M.Genres = Genre.Selected;
            M.Actors = CastList.Items.Cast<string>().ToList(); 

            return M;
        }
        private void UpdateUIFromModel(Movie M)
        {
            TitleTxt.Text = M.Title;
            YearTxt.Text = M.Year.ToString();
            DirectorTxt.Text = M.Director;
            DurationTxt.Text = M.Duration.ToString();
            BudgetTxt.Text = M.Budget.ToString();
            Rating.Value = M.Rating;
            MovieURLTxt.Text = M.URL;
            Genre.Selected = M.Genres;
            CastList.Items.Clear();
            foreach (var s in NDB.Get().Actors)
            {
                CastList.Items.Add(s);
            }

            if (MovieURLTxt.Text != "")
            {
                try
                {
                    var path = M.URL;
                    var uri = new Uri(path, UriKind.Absolute);  // create a uri
                    Image.Source = new BitmapImage(uri);
                    PosterLbl.Visibility = Visibility.Visible;
                    Image.Visibility = Visibility.Visible;

                }
                catch (UriFormatException e)
                {
                    Image.Source = null;
                    MessageBox.Show("Invalid URL", "Error");     // invalid path
                }
            }

            UpdateNavigation();
        }

        private void FileNewMenu_Click(object sender, RoutedEventArgs e)
        {
            NM = new Movie();
            NDB = new Database();
            
            NDB.Add(NM);

            UpdateUIFromModel(NM);
            SetUIMode(WindowMode.View);

            if (NDB.Index() == -1) {
                BFirst.IsEnabled = false;
                BPrevious.IsEnabled = false;
                BLast.IsEnabled = false;
                BNext.IsEnabled = false;
            }
        }

        private void FileOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            clear();
            NDB.Load("MovieDatabase");

            NDB.First();
            UpdateUIFromModel(NDB.Get());
            SetUIMode(WindowMode.View);
        }

        private void FileSaveMenu_Click(object sender, RoutedEventArgs e)
        {
            NDB.Save("MovieDatabase");
        }

        private void FileExitMenu_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Do you want to Exit the application?", "Exit", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void EditCreateMenu_Click(object sender, RoutedEventArgs e)
        { 
            clear();
            SetUIMode(WindowMode.Create);
        }

        private void EditEditMenu_Click(object sender, RoutedEventArgs e)
        {
            SetUIMode(WindowMode.Edit);
        }

        private void EditDeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            NDB.Delete();
            UpdateUIFromModel(NDB.Get());
        }

        private void ViewByTitleMenu_Click(object sender, RoutedEventArgs e)
        {
            NDB.OrderByTitle();
            NDB.First();
            UpdateUIFromModel(NDB.Get());
        }

        private void ViewByYearMenu_Click(object sender, RoutedEventArgs e)
        {
            NDB.OrderByYear();
            NDB.First();
            UpdateUIFromModel(NDB.Get());
        }

        private void ViewByDuration_Click(object sender, RoutedEventArgs e)
        {
            NDB.OrderByDuration();
            NDB.First();
            UpdateUIFromModel(NDB.Get());
        }

        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Movie Database \n B00710958 - Jake Young \n B00574377 - Kyle Barnes  \n B00650196 - Eimear Jones", "About", MessageBoxButton.OK);
        }

        private void BFirst_Click(object sender, RoutedEventArgs e)
        {
            if (NDB.First())
            {
                UpdateUIFromModel(NDB.Get());
            }
        }

        private void BPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (NDB.Prev())
            {
                UpdateUIFromModel(NDB.Get());
            }
        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {
            if (NDB.Next())
            {
                UpdateUIFromModel(NDB.Get());
            }
        }

        private void BLast_Click(object sender, RoutedEventArgs e)
        {
            if (NDB.Last())
            {
                UpdateUIFromModel(NDB.Get());
            }
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CastTxt.Text != "")
            {
                CastList.Items.Add(CastTxt.Text);
            }

            CastTxt.Text = "";
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CastList.SelectedItem != null)
            {
                NM.Actors.Remove(CastList.SelectedItem.ToString());
                CastList.Items.Remove(CastList.SelectedItem);
            }
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {     
            if (this.Mode == WindowMode.Create)
            {
                Movie m = new Movie();
                m = UpdateMovieFromUI(m);
                NDB.Add(m);
            }
            else if (this.Mode == WindowMode.Edit)
            {
                Movie m = NDB.Get();
                m = UpdateMovieFromUI(m);
                NDB.Update(m);               
            }

            SetUIMode(WindowMode.View);
            UpdateUIFromModel(NDB.Get());

        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            SetUIMode(WindowMode.View);
            UpdateUIFromModel(NDB.Get());
        }

        private void SetUIMode(WindowMode mode)
        {
            this.Mode = mode;

            if (mode == WindowMode.Create || mode == WindowMode.Edit)
            {
                TitleTxt.IsEnabled = true;
                DurationTxt.IsEnabled = true;
                YearTxt.IsEnabled = true;
                BudgetTxt.IsEnabled = true;
                Rating.IsEnabled = true;
                DirectorTxt.IsEnabled = true;
                Genre.IsEnabled = true;
                BAdd.IsEnabled = true;
                BDelete.IsEnabled = true;
                BLast.IsEnabled = false;
                BPrevious.IsEnabled = false;
                BNext.IsEnabled = false;
                BFirst.IsEnabled = false;
                BPrevious.Visibility = Visibility.Hidden;
                BFirst.Visibility = Visibility.Hidden;
                BSave.Visibility = Visibility.Visible;
                BCancel.Visibility = Visibility.Visible;
                CastGrid.Visibility = Visibility.Visible;
                MovieURLTxt.Visibility = Visibility.Visible;
                Movielbl.Visibility = Visibility.Visible;
                PosterLbl.Visibility = Visibility.Collapsed;
                Image.Visibility = Visibility.Collapsed;
            }
            else if (mode == WindowMode.View)
            {
                TitleTxt.IsEnabled = false;
                DurationTxt.IsEnabled = false;
                YearTxt.IsEnabled = false;
                BudgetTxt.IsEnabled = false;
                Rating.IsEnabled = false;
                DirectorTxt.IsEnabled = false;
                Genre.IsEnabled = false;
                BAdd.IsEnabled = false;
                BDelete.IsEnabled = false;
                BLast.IsEnabled = true;
                BPrevious.IsEnabled = true;
                BNext.IsEnabled = true;
                BFirst.IsEnabled = true;
                BPrevious.Visibility = Visibility.Visible;
                BFirst.Visibility = Visibility.Visible;
                BSave.Visibility = Visibility.Hidden;
                BCancel.Visibility = Visibility.Hidden;
                CastGrid.Visibility = Visibility.Collapsed;
                Movielbl.Visibility = Visibility.Collapsed;
                MovieURLTxt.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateNavigation()
        {
            if (NDB.Index() == -1)
            {
                BFirst.IsEnabled = false;
                BPrevious.IsEnabled = false;
                BLast.IsEnabled = true;
                BNext.IsEnabled = true;
            }
            else if (NDB.Index() == NDB.Count() - 2)
            {
                BLast.IsEnabled = false;
                BNext.IsEnabled = false;
                BFirst.IsEnabled = true;
                BPrevious.IsEnabled = true;
            }
            else
            {
                BFirst.IsEnabled = true;
                BPrevious.IsEnabled = true;
                BLast.IsEnabled = true;
                BNext.IsEnabled = true;
            }
        }

        private void clear()
        {
            TitleTxt.Text = "";
            DurationTxt.Text = "";
            YearTxt.Text = "";
            BudgetTxt.Text = "";
            Rating.Clear();
            DirectorTxt.Text = "";
            Genre.Clear();
            CastTxt.Text = "";
            CastList.Items.Clear();
            MovieURLTxt.Text = "";
        }


    }
}