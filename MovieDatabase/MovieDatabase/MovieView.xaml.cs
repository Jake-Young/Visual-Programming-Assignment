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
    /// <summary>
    /// Interaction logic for MovieView.xaml
    /// </summary>
    public partial class MovieView : Window
    {

        private Database db;
     
        public MovieView()
        {
            InitializeComponent();

            db = new Database();
        }

        // Create what ever methods you deem necessary to provide a functioning UI

        private void UpdateModelFromUI(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateUIFromModel(object sender, RoutedEventArgs e)
        {

        }

        private void FileNewMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileOpenMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileSaveMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileExitMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCreateMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditEditMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditDeleteMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewByTitleMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewByYearMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewByDuration_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HelpMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BLast_Click(object sender, RoutedEventArgs e)
        {

        }

        

    }
}