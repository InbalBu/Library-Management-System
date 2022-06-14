using BookLib;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LibraryManager.ViewModel
{
    public class ButtonViewModel
    {
        TextViewModel Text;
        List<LibraryItems> libraryItems;
        RegisterViewModel Register;
        BookManager bookManager;
        Notifier notify;
        ReportViewModel report;

        #region RelayCommand
        public ObservableCollection<LibraryItems> ObservableLibraryItems { get; set; }
        public RelayCommand AddBook { get; set; }
        public RelayCommand AddJournal { get; set; }
        public RelayCommand Display { get; set; }
        public RelayCommand FilterPrice { get; set; }
        public RelayCommand FilterAmount { get; set; }
        public RelayCommand FilterName { get; set; }
        public RelayCommand Rent { get; set; }
        public RelayCommand AddItems { get; set; }
        public RelayCommand Return { get; set; }
        public RelayCommand Update { get; set; }
        public RelayCommand Discount { get; set; }
        public RelayCommand FilterReportName { get; set; }
        #endregion

        public ButtonViewModel(TextViewModel textViewModel, RegisterViewModel register, ReportViewModel reports)
        {
            this.Text = textViewModel;
            this.Register = register;
            this.report = reports;
            notify = new Notifier();
            AddBook = new RelayCommand(AddBookToLibrary);
            AddJournal = new RelayCommand(AddJournalToLibrary);
            Display = new RelayCommand(DisplayItems);
            libraryItems = new List<LibraryItems>();
            ObservableLibraryItems = new ObservableCollection<LibraryItems>();
            FilterPrice = new RelayCommand(PriceOnly);
            FilterAmount = new RelayCommand(AmountOnly);
            FilterName = new RelayCommand(NameOnly);
            Rent = new RelayCommand(RentItems);
            AddItems = new RelayCommand(AddBorrowedItems);
            Return = new RelayCommand(ReturnItems);
            Update = new RelayCommand(UpdateStock);
            Discount = new RelayCommand(UpdateDiscount);
            FilterReportName = new RelayCommand(ReportFilterName);
            bookManager = new BookManager(notify);
        }

        #region Filter
        public void PriceOnly()
        {
            ObservableLibraryItems.Clear();
            libraryItems = bookManager.itemCollection.LibraryItems.FindAll(item => item.Price == Text.OnlyPrice);

            foreach (var item in libraryItems)
            {
                ObservableLibraryItems.Add(item);
            }
        }
        public void AmountOnly()
        {
            ObservableLibraryItems.Clear();
            libraryItems = bookManager.itemCollection.LibraryItems.FindAll(item => item.ItemStock == Text.OnlyAmount);

            foreach (var item in libraryItems)
            {
                ObservableLibraryItems.Add(item);
            }
        }
        public void NameOnly()
        {
            ObservableLibraryItems.Clear();
            libraryItems = bookManager.itemCollection.LibraryItems.FindAll(item => item.Name == Text.OnlyName);

            foreach (var item in libraryItems)
            {
                ObservableLibraryItems.Add(item);
            }
        }
        #endregion

        #region UpdatesInLibrary
        private void UpdateDiscount() // only manager can change discounts
        {
            foreach (var item in bookManager.itemCollection.LibraryItems)
            {
                if (item.Discount != Text.Discount) item.Discount = Text.Discount;
            }
            notify.UpdateDiscount($"Discount has been updated, view it in Display window");
            Text.Discount = 0;
        }
        private void UpdateStock()
        {
            int flag = 1;
            for (int i = 0; i < bookManager.itemCollection.LibraryItems.Count; i++)
            {
                if (bookManager.itemCollection.LibraryItems[i].Name == Text.ItemName)
                {
                    flag = 0;
                    bookManager.itemCollection.LibraryItems[i].ItemStock += Text.Amount;
                    notify.UpdateStock($"{bookManager.itemCollection.LibraryItems[i].Name} stock has been updated to {bookManager.itemCollection.LibraryItems[i].ItemStock}");
                }
                if (flag == 1)
                {
                    notify.UpdateStock("Something went wrong. Please check item name again.");
                }
            }
            Text.ItemName = "";
            Text.Amount = 0;
        }
        #endregion

        #region AddToLibrary
        private void CleanBookInput()
        {
            Text.ISBN = 0;
            Text.ItemName = string.Empty;
            Text.Price = 0;
            Text.Discount = 0;
            Text.Amount = 0;
            Text.PrintDate = DateTime.Now;
            Text.Category = 0;
            Text.Author = string.Empty;
            Text.CopyNumber = 0;
        }
        private void CleanJournalInput()
        {
            Text.ISBN = 0;
            Text.ItemName = string.Empty;
            Text.Price = 0;
            Text.Discount = 0;
            Text.Amount = 0;
            Text.PrintDate = DateTime.Now;
            Text.JournalCategory = 0;
            Text.CopyNumber = 0;
        }
        private void AddBookToLibrary() // Only HeadWorker can Add
        {
            Book book = new Book(Text.ISBN, Text.ItemName, Text.Price, Text.Discount, Text.Amount, Text.PrintDate, Text.Category, Text.Author, Text.CopyNumber, Text.RentedDate, Text.CustomerRef, Register.CurrentCustomer);
            book.CustomerRef = Register.CurrentCustomer;
            bookManager.itemCollection.AddBooks(book);
            notify.AddedItem($"{book.Name} was added succesfuly!");
            report.AddBookRows(book);
            CalculateDiscount();
            CleanBookInput();
        }
        private void AddJournalToLibrary() // Only HeadWorker can Add
        {
            Journal journal = new Journal(Text.ISBN, Text.ItemName, Text.Price, Text.Discount, Text.Amount, Text.PrintDate, Text.CopyNumber, Text.JournalCategory, Text.RentedDate, Text.CustomerRef, Register.CurrentCustomer);
            journal.CustomerRef = Register.CurrentCustomer;
            bookManager.itemCollection.AddJournals(journal);
            if (bookManager.itemCollection.LibraryItems.Contains(journal)) journal.ItemStock += Text.Amount;
            notify.AddedItem($"{journal.Name} added succesfuly!");
            report.AddJournalRows(journal);
            CalculateDiscount();
            CleanJournalInput();
        }
        #endregion

        #region CustomerActions
        private void ReturnItems()
        {
            int flag = 1;
            for (int i = 0; i < bookManager.itemCollection.LibraryItems.Count; i++)
            {
                if (bookManager.itemCollection.LibraryItems[i].Name == Text.ItemName)
                {
                    flag = 0;
                    bookManager.ReturnItems(Register.CurrentCustomer);
                    notify.SucceededRent($"Thank you {Register.CurrentCustomer.CustomerFullName}, \n item {bookManager.itemCollection.LibraryItems[i].Name} has returned successfuly.");
                }
                else if (flag == 1) notify.FailedRent("Something went wrong. Check the item name again.");
            }
            Text.ItemName = "";
            Text.FullName = "";
        }
        private void RentItems()
        {
            bookManager.RentItem(Register.CurrentCustomer);
            Text.ItemName = "";
        }
        private void AddBorrowedItems()
        {
            LibraryItems library = bookManager.itemCollection[Text.ItemName];
            if (library != null)
            {
                bookManager.RentedItems.Add(library);
                notify.AddedItem($"{library.Name} was added to cart");
                Text.ItemName = "";
            }
            else notify.NotFoundItem($"Item was not found in the library");
        }
        #endregion

        private void DisplayItems()
        {
            ObservableLibraryItems.Clear();
            foreach (var item in bookManager.itemCollection.LibraryItems)
            {
                ObservableLibraryItems.Add(item);
            }
        }
        public void CalculateDiscount()
        {
            double max = 0;
            int i;
            int position = 0;
            for (i = 0; i < bookManager.itemCollection.LibraryItems.Count; i++)
            {
                position = i;
                if (bookManager.itemCollection.LibraryItems[i].Discount > max) max = bookManager.itemCollection.LibraryItems[i].Discount;
            }
            bookManager.itemCollection.LibraryItems[position].Price *= (100 - max) * 0.01;
        }
        private void ReportFilterName()
        {
            report.NameReportFilter();
        }
    }
}
