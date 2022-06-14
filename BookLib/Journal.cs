using Models;
using System;
using System.Collections.Generic;

namespace BookLib
{
    public class Journal : LibraryItems
    {
        List<Journal> JsonJournals = new List<Journal>();
        public string JournalName { get; set; }
        public int CopyNumber { get; set; }
        [Flags]
        public enum JournalCategories
        {
            Other = -1,
            Academic = 1,
            Fashion = 2,
            Classic = 4,
            Travel = 8,
            Food = 16
        }
        JournalCategories journalCategoryList;
        public JournalCategories JournalCategory { get { return journalCategoryList; } set { journalCategoryList = value; } }
        public Journal(int isbn, string name, double price, double discount, int itemStock, DateTime printDate, int copyNumber, JournalCategories category, DateTime rentedDate, Customer customerRef, Customer currentCustomer) : base(isbn, name, price, discount, itemStock, printDate, copyNumber, rentedDate, customerRef)
        {
            JournalName = name;
            PrintDate = printDate;
            CopyNumber = copyNumber;
            JournalCategory = category;
        }
        public override string ToString()
        {
            return ($"Name: {JournalName}, Price: {Price}, Amount: {ItemStock} \n" +
                $"Discount: {Discount},Category: {JournalCategory}");
        }
    }
}
