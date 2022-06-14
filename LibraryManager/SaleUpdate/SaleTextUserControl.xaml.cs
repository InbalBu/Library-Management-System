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

namespace LibraryManager.SaleUpdate
{
    /// <summary>
    /// Interaction logic for SaleTextUserControl.xaml
    /// </summary>
    public partial class SaleTextUserControl : UserControl
    {
        public SaleTextUserControl()
        {
            InitializeComponent();
        }

        private void categoryBookDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(categoryBookDiscount.Text, "^[0-9]*$"))
            {
                categoryBookDiscount.Text = string.Empty;
            }
        }

        private void categoryJournalDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(categoryJournalDiscount.Text, "^[0-9]*$"))
            {
                categoryJournalDiscount.Text = string.Empty;
            }
        }

    }
}
