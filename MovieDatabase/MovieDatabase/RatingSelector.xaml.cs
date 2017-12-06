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
    /// Interaction logic for RatingSelector.xaml
    /// </summary>
    public partial class RatingSelector : UserControl
    {
        public RatingSelector()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            RbOne.IsChecked = false;
            RbTwo.IsChecked = false;
            RbThree.IsChecked = false;
            RbFour.IsChecked = false;
            RbFive.IsChecked = false; 
        }
    }

    
}
