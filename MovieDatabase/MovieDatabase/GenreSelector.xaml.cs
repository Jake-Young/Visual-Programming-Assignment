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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MovieDatabase.Models;

namespace MovieDatabase
{
    /// <summary>
    /// Interaction logic for GenreSelector.xaml
    /// </summary>
    public partial class GenreSelector : UserControl
    {
        public GenreSelector()
        {
            InitializeComponent();
        }

        public List<Genre> Selected
        {
            get
            {
                var Genres = new List<Genre>();

                if (CbComedy.IsChecked.Value) Genres.Add(Models.Genre.comedy);
                if (CbRomance.IsChecked.Value) Genres.Add(Models.Genre.romance);
                if (CbAction.IsChecked.Value) Genres.Add(Models.Genre.action);
                if (CbThriller.IsChecked.Value) Genres.Add(Models.Genre.thriller);
                if (CbFamily.IsChecked.Value) Genres.Add(Models.Genre.family);
                if (CbHorror.IsChecked.Value) Genres.Add(Models.Genre.horror);
                if (CbWestern.IsChecked.Value) Genres.Add(Models.Genre.western);
                if (CbSciFi.IsChecked.Value) Genres.Add(Models.Genre.scifi);
                if (CbWar.IsChecked.Value) Genres.Add(Models.Genre.war);

                return Genres;
            }
            set
            {

                CbComedy.IsChecked = value.Contains(Models.Genre.comedy) ? true : false;
                CbRomance.IsChecked = value.Contains(Models.Genre.romance) ? true : false;
                CbAction.IsChecked = value.Contains(Models.Genre.action) ? true : false;
                CbThriller.IsChecked = value.Contains(Models.Genre.thriller) ? true : false;
                CbFamily.IsChecked = value.Contains(Models.Genre.family) ? true : false;
                CbHorror.IsChecked = value.Contains(Models.Genre.horror) ? true : false;
                CbWestern.IsChecked = value.Contains(Models.Genre.western) ? true : false;
                CbSciFi.IsChecked = value.Contains(Models.Genre.scifi) ? true : false;
                CbWar.IsChecked = value.Contains(Models.Genre.war) ? true : false;

            }
        }

        public void Clear()
        {
            CbComedy.IsChecked = false;
            CbRomance.IsChecked = false;
            CbAction.IsChecked = false;
            CbThriller.IsChecked = false;
            CbFamily.IsChecked = false;
            CbHorror.IsChecked = false;
            CbWestern.IsChecked = false;
            CbSciFi.IsChecked = false;
            CbWar.IsChecked = false;
        }
    }
}
