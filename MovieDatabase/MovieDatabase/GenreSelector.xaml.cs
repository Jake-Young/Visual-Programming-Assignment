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
