using Models;
using System;
using System.Collections.Generic;

namespace BookLib
{
    public class Book : LibraryItems
    {
        List<Book> JsonBooks = new List<Book>();
        public string BookName { get; set; }
        public string Edition { get; set; }
        public string Author { get; set; }
        public int CopyNumber { get; set; }
        [Flags]
        public enum Categories
        {
            Other = -1,
            Comics = 1,
            Cooking = 2,
            History = 4,
            Kids = 8,
            Medical = 16,
            Mysteries = 32,
            Parenting = 64,
            Sports = 128,
            Teen = 256
        }

        Categories categoryList;
        public Categories Category { get { return categoryList; } set { categoryList = value; } }
        public Book(int isbn, string name, double price, double discount, int itemStock, DateTime printDate, Categories category, string author, int copyNumber, DateTime rentedDate, Customer customerRef, Customer currentCustomer) : base(isbn, name, price, discount, itemStock, printDate, copyNumber, rentedDate, customerRef)
        {
            BookName = name;
            PrintDate = printDate;
            Author = author;
            CopyNumber = copyNumber;
            Category = category;
            CustomerRef = customerRef;
        }
        public override string ToString()
        {
            return ($"Name: {BookName}, Price: {Price}, Amount: {ItemStock} \n" +
                $"Discount: {Discount}, Category: {Category}");
        }
    }
}
