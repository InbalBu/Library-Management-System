using Services;
using System.Windows;

namespace LibraryManager
{
    public class Notifier : INotify
    {
        public void AddedItem(string add)
        {
            MessageBox.Show(add);
        }
        public void FailedRent(string rentFailed)
        {
            MessageBox.Show(rentFailed);
        }
        public void NotFoundItem(string missingItem)
        {
            MessageBox.Show(missingItem);
        }
        public void SucceededRent(string rent)
        {
            MessageBox.Show(rent);
        }
        public void LateToReturn(string late)
        {
            MessageBox.Show(late);
        }
        public void UpdateStock(string update)
        {
            MessageBox.Show(update);
        }
        public void UpdateDiscount(string discout)
        {
            MessageBox.Show(discout);
        }
    }
}
