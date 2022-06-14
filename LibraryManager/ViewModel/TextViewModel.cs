using GalaSoft.MvvmLight;
using Models;
using System;
using static BookLib.Book;
using static BookLib.Journal;

namespace LibraryManager.ViewModel
{
    public class TextViewModel : ViewModelBase
    {
        #region Properties
        private string itemName;
        private double price;
        private int iSBN;
        private int amount;
        private string genre;
        private double discount;
        private DateTime printDate;
        private string edition;
        private string subject;
        private string author;
        private int copyNumber;
        private long specialID;
        private Categories category;
        private JournalCategories categoryJournal;
        private DateTime rentedDate;
        private string fullName;
        private Customer customerRef;

        private double onlyPrice;
        private int onlyAmount;
        private string onlyName;

        #endregion

        #region PublicProperties
        public string ItemName { get => itemName; set { Set(ref itemName, value); } }
        public double Price { get => price; set { Set(ref price, value); } }
        public int ISBN { get => iSBN; set { Set(ref iSBN, value); } }
        public int Amount { get => amount; set { Set(ref amount, value); } }
        public string Genre { get => genre; set { Set(ref genre, value); } }
        public double Discount { get => discount; set { Set(ref discount, value); } }
        public DateTime PrintDate { get => printDate; set { Set(ref printDate, DateTime.Now); } }
        public string Edition { get => edition; set { Set(ref edition, value); } }
        public string Subject { get => subject; set { Set(ref subject, value); } }
        public string Author { get => author; set { Set(ref author, value); } }
        public int CopyNumber { get => copyNumber; set { Set(ref copyNumber, value); } }
        public Categories Category { get => category; set => category = value; }
        public JournalCategories JournalCategory { get => categoryJournal; set => categoryJournal = value; }
        public long SpecialID { get => specialID; set { Set(ref specialID, value); } }
        public DateTime RentedDate { get => rentedDate; set { Set(ref rentedDate, DateTime.Now); } }
        public Customer CustomerRef { get => customerRef; set => customerRef = value; }
        public double OnlyPrice { get => onlyPrice; set { Set(ref onlyPrice, value); } }
        public int OnlyAmount { get => onlyAmount; set { Set(ref onlyAmount, value); } }
        public string OnlyName { get => onlyName; set { Set(ref onlyName, value); } }
        public string FullName { get => fullName; set => Set(ref fullName, value); }

        #endregion
    }
}
