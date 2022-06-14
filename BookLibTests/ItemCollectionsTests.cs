using LibraryManager.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookLib.Tests
{
    [TestClass()]
    public class ItemCollectionsTests
    {
        ItemCollections itemCollections = new ItemCollections();
        Book book = new Book(1, "Harry Poter", 100, 5, 3, DateTime.Now, Book.Categories.Mysteries, "Inbal", 98, DateTime.Now, new Models.Customer(), new Models.Customer());
        Journal journal = new Journal(1, "Cheese Touch", 100, 5, 8, DateTime.Now, 5, Journal.JournalCategories.Other, DateTime.Now, new Models.Customer(), new Models.Customer());

        [TestMethod()]
        public void AddBooksTest()
        {
            itemCollections.LibraryItems.Clear();
            itemCollections.AddBooks(book);
            Assert.IsTrue(itemCollections.LibraryItems.Contains(book));

        }

        [TestMethod()]
        public void AddJournalsTest()
        {
            itemCollections.LibraryItems.Clear();
            itemCollections.AddJournals(journal);
            Assert.IsTrue(itemCollections.LibraryItems.Contains(journal));
        }
    }
}