using System.Collections.Generic;
using static BookLib.Book;
using static BookLib.Journal;

namespace BookLib
{
    public class ItemCollections
    {
        public List<LibraryItems> LibraryItems = new List<LibraryItems>();
        public LibraryItems this[string Name]
        {
            get
            {
                return LibraryItems.Find(item => item.Name == Name);
            }
        }
        public LibraryItems this[int ISBN]
        {
            get
            {
                return LibraryItems.Find(item => item.ISBN == ISBN);
            }
        }
        public LibraryItems this[double Price]
        {
            get
            {
                return LibraryItems.Find(item => item.Price == Price);
            }
        }
        public void AddBooks(Book book)
        {
            book = new Book(book.ISBN, book.Name, book.Price, book.Discount, book.ItemStock, book.PrintDate, book.Category, book.Author, book.CopyNumber, book.RentedDate, book.CustomerRef, book.CustomerRef);
            if (!LibraryItems.Contains(book)) LibraryItems.Add(book);
            for (int i = 0; i < LibraryItems.Count; i++)
            {
                if (Categories.History == book.Category) book.Discount = 50;
                if (Categories.Mysteries == book.Category) book.Discount = 45;
                if (Categories.Comics == book.Category) book.Discount = 25;
                if (Categories.Sports == book.Category) book.Discount = 15;
            }
        }
        public void AddJournals(Journal journal)
        {
            journal = new Journal(journal.ISBN, journal.JournalName, journal.Price, journal.Discount, journal.ItemStock, journal.PrintDate, journal.CopyNumber, journal.JournalCategory, journal.RentedDate, journal.CustomerRef, journal.CustomerRef);
            if (!LibraryItems.Contains(journal)) LibraryItems.Add(journal);
            for (int i = 0; i < LibraryItems.Count; i++)
            {
                if (JournalCategories.Food == journal.JournalCategory) journal.Discount = 40;
                if (JournalCategories.Fashion == journal.JournalCategory) journal.Discount = 10;
                if (JournalCategories.Travel == journal.JournalCategory) journal.Discount = 15;
            }
        }
    }
}
