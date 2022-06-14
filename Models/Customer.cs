using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Models
{
    public class Customer
    {
        public List<Customer> JsonItems = new List<Customer>();
        public List<Object> BorrowedItems;
        private long specialID;
        private string customerFullName;
        private double wallet;
        public long SpecialID
        {
            get { return specialID; }
            set { specialID = value; }
        }
        public string CustomerFullName
        {
            get { return customerFullName; }
            set { customerFullName = value; }
        }
        public double Wallet
        {
            get { return wallet; }
            set { wallet = value; }
        }
        public Customer()
        {
            BorrowedItems = new List<Object>();
        }

        #region Json
        public void SaveJsonCustomer(string customer)
        {
            var myClass = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText($"C:/Users/inbal/source/repos/LibraryManager/{customer}.json", myClass);
        }
        public void UploadJsonCustomer()
        {
            JsonItems.Clear();
            string json;
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\inbal\source\repos\LibraryManager\", "*.json"))
            {
                json = File.ReadAllText(file);
                var classJson = JsonConvert.DeserializeObject<Customer>(json);

                JsonItems.Add(classJson);
            }
        }
        #endregion

    }
}
