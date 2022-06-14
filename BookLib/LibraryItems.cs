using Models;
using System;

namespace BookLib
{
    public abstract class LibraryItems
    {
        #region Properties
        private DateTime printDate;
        private DateTime rentedDate;
        public int ISBN { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int ItemStock { get; set; }
        public DateTime PrintDate { get => printDate; set => printDate = DateTime.Now; }
        public DateTime RentedDate { get => rentedDate; set => rentedDate = DateTime.Now; }
        public Customer CustomerRef { get; set; }

        #endregion
        public LibraryItems(int isbn, string name, double price, double discount, int itemStock, DateTime printDate, int copyNumber, DateTime rentedDate, Customer customerRef)
        {
            this.ISBN = isbn;
            this.Name = name;
            this.Price = price;
            this.Discount = discount;
            this.ItemStock = itemStock;
            this.PrintDate = printDate;
            this.RentedDate = rentedDate.AddDays(3);
            this.CustomerRef = customerRef;
        }
    }
}
