using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace LibraryManager.Display
{
    /// <summary>
    /// Interaction logic for DisplayTextUserControl.xaml
    /// </summary>
    public partial class DisplayTextUserControl : UserControl
    {
        public DisplayTextUserControl()
        {
            InitializeComponent();
        }

        private void insertAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertAmount.Text, "^[0-9]*$"))
            {
                insertAmount.Text = string.Empty;
            }
        }

        private void insertPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertPrice.Text, "^[0-9]*$"))
            {
                insertPrice.Text = string.Empty;
            }
        }

        private void insertItemName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertItemName.Text, "^[a-z]*$"))
            {
                insertItemName.Text = string.Empty;
            }
        }
    }
}
