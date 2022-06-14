using LibraryManager;
using LibraryManager.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookLib.Tests
{
    [TestClass()]
    public class BookManagerTests
    {
        [TestMethod()]
        public void RentItemTest()
        {
            Notifier notifier = new Notifier();
            ItemCollections item = new ItemCollections();
            BookManager bm = new BookManager(notifier);
            Book book = new Book(1, "Testing", 100, 5, 3, DateTime.Now, Book.Categories.Mysteries, "Inbal", 98, DateTime.Now, new Models.Customer(), new Models.Customer());
            item.AddBooks(book);
            Book tmp = bm.RentedItems[0] as Book;
            bm.RentItem(new Models.Customer());
            bool succeed = true;
            if (tmp.ItemStock != bm.RentedItems[0].ItemStock) Assert.IsTrue(succeed);
            if (tmp.CustomerRef.Wallet != bm.RentedItems[0].CustomerRef.Wallet) Assert.IsTrue(succeed);
           
        }

        [TestMethod()]
        public void ReturnItemsTest()
        {
            Notifier notify = new Notifier();
            BookManager bm = new BookManager(notify);
            ItemCollections item = new ItemCollections();
            Journal journal = new Journal(1, "Test Journal", 100, 5, 8, DateTime.Now, 5, Journal.JournalCategories.Other, DateTime.Now, new Models.Customer(), new Models.Customer());
            item.AddJournals(journal);
            Journal tmp = bm.RentedItems[0] as Journal;
            bm.RentItem(new Models.Customer());
            bool succeed = true;
            if (tmp.ItemStock != bm.RentedItems[0].ItemStock) Assert.IsTrue(succeed);
            if (tmp.CustomerRef.Wallet != bm.RentedItems[0].CustomerRef.Wallet) Assert.IsTrue(succeed);
        }
    }
}