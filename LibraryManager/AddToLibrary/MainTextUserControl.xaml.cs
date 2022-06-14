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

namespace LibraryManager.AddToLibrary
{
    /// <summary>
    /// Interaction logic for MainTextUserControl.xaml
    /// </summary>
    public partial class MainTextUserControl : UserControl
    {
        public MainTextUserControl()
        {
            InitializeComponent();
        }

        private void insertName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertName.Text, "^[a-z]*$"))
            {
                insertName.Text = string.Empty;
            }
        }

        private void insertPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertPrice.Text, "^[0-9]*$"))
            {
                insertPrice.Text = string.Empty;
            }
        }

        private void insertAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertAmount.Text, "^[0-9]*$"))
            {
                insertAmount.Text = string.Empty;
            }
        }

        private void insertCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertCode.Text, "^[0-9]*$"))
            {
                insertCode.Text = string.Empty;
            }
        }

        private void insertCopyNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertCopyNumber.Text, "^[0-9]*$"))
            {
                insertCopyNumber.Text = string.Empty;
            }
        }
    }
}
