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

namespace LibraryManager.ReturnItems
{
    /// <summary>
    /// Interaction logic for ReturnTextUserControl.xaml
    /// </summary>
    public partial class ReturnTextUserControl : UserControl
    {
        public ReturnTextUserControl()
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

        private void insertFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertFullName.Text, "^[a-z]*$"))
            {
                insertFullName.Text = string.Empty;
            }
        }
    }
}
