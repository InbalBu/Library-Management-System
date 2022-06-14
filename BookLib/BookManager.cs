using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace BookLib
{
    public class BookManager
    {
        public ItemCollections itemCollection = new ItemCollections();
        public List<LibraryItems> RentedItems = new List<LibraryItems>();
        INotify notify;
        Timer timer;

        TimeSpan ThreeDays = new TimeSpan(0, 3, 0, 0);
        TimeSpan Daily = new TimeSpan(0, 1, 0, 0);
        public BookManager(INotify notifier)
        {
            notify = notifier;
            timer = new Timer(PassedRentDate, null, ThreeDays, Daily);
        }
        private void PassedRentDate(object state)
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < itemCollection.LibraryItems.Count; i++)
            {
                if (itemCollection.LibraryItems[i].RentedDate <= now) // late
                {
                    itemCollection.LibraryItems[i].ItemStock++; // return item to stock
                    itemCollection.LibraryItems[i].CustomerRef.Wallet -= 150; // fine
                    notify.LateToReturn($"{itemCollection.LibraryItems[i].CustomerRef.CustomerFullName}, You didnt return in time {itemCollection.LibraryItems[i].Name} \n " +
                        $"You were fined by 150$, please pay attention next time.");
                }
            }
        }
        public void RentItem(Customer CurrentCustomer)
        {
            int flag = 1;
            StringBuilder sb = new StringBuilder();
            foreach (var item in RentedItems.ToList())
            {
                if (item != default)
                {
                    if (item.CustomerRef == null && CurrentCustomer == null) // no customer is logged in
                    {
                        notify.FailedRent("Pay attention, only when a customer is logged in, you may do a rent!");
                        flag = 0;
                        RentedItems.Clear();
                        break;
                        throw new Exception("Customer needs to login");
                    }
                    else if (CurrentCustomer.Wallet >= item.Price && item.ItemStock > 0 && flag == 1)
                    {
                        CurrentCustomer.BorrowedItems.Add(item);
                        CurrentCustomer.Wallet -= item.Price;
                        item.ItemStock--;
                        flag = 1;
                    }
                    else
                    {
                        notify.FailedRent($"You have: {CurrentCustomer.Wallet}. Rent Failed");
                        RentedItems.Clear();
                        flag = 0;
                    }
                    sb.AppendLine($"{item.Name}");
                }
                else
                {
                    notify.NotFoundItem($"{item.Name} was not found in the library");
                    throw new Exception("Item is missing from library");
                }

            }
            if (flag == 1)
            {
                notify.SucceededRent($"Thank you {CurrentCustomer.CustomerFullName},\n Here are your items: {sb} Remember to return them by time! \n Credits left: {CurrentCustomer.Wallet}");
                RentedItems.Clear();
            }
        }
        public void ReturnItems(Customer CurrentCustomer)
        {
            foreach (var item in RentedItems)
            {
                if (item.Name != RentedItems[0].Name) notify.NotFoundItem("Please check item name and try again.");
                CurrentCustomer.BorrowedItems.Clear();
                item.ItemStock++;
                item.Name = string.Empty;
                item.ItemStock = 0;
            }
        }
    }
}
