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

namespace LibraryManager.AddBookToLibrary
{
    /// <summary>
    /// Interaction logic for BookTextUserControl.xaml
    /// </summary>
    public partial class BookTextUserControl : UserControl
    {
        public BookTextUserControl()
        {
            InitializeComponent();
        }

        private void insertEdition_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertEdition.Text, "^[a-z]*$"))
            {
                insertEdition.Text = string.Empty;
            }
        }

        private void insertSubject_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertSubject.Text, "^[a-z]*$"))
            {
                insertSubject.Text = string.Empty;
            }
        }

        private void insertAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(insertAuthor.Text, "^[a-z]*$"))
            {
                insertAuthor.Text = string.Empty;
            }
        }
      
    }
}
