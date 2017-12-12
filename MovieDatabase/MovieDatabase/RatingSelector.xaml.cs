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

        public int Value
        {
            get
            {
                var value = 0;
                if (Rb1.IsChecked.Value) value = 1;
                else if (Rb2.IsChecked.Value) value = 2;
                else if (Rb3.IsChecked.Value) value = 3;
                else if (Rb4.IsChecked.Value) value = 4;
                else if (Rb5.IsChecked.Value) value = 5;

                return value;
            }

            set
            {
                Rb1.IsChecked = value == 1 ? true : false;
                Rb2.IsChecked = value == 2 ? true : false;
                Rb3.IsChecked = value == 3 ? true : false;
                Rb4.IsChecked = value == 4 ? true : false;
                Rb5.IsChecked = value == 5 ? true : false;

            }
        }

        public void Clear()
        {
            Rb1.IsChecked = false;
            Rb2.IsChecked = false;
            Rb3.IsChecked = false;
            Rb4.IsChecked = false;
            Rb5.IsChecked = false; 
        }
    }

    
}
