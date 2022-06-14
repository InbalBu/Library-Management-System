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

namespace LibraryManager.CustomerRegister
{
    /// <summary>
    /// Interaction logic for CustomerTextUserControl.xaml
    /// </summary>
    public partial class CustomerTextUserControl : UserControl
    {
        public CustomerTextUserControl()
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

        private void insertID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertID.Text, "^[0-9]*$"))
            {
                insertID.Text = string.Empty;
            }
        }
    }
}
