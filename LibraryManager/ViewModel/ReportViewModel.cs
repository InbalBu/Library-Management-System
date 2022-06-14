using BookLib;
using System;
using System.Data;
using System.Linq;

namespace LibraryManager.ViewModel
{
    public class ReportViewModel : MainViewModel
    {
        DataTable dataTable = new DataTable();

        private string reportName;
        public string ReportName { get => reportName; set { Set(ref reportName, value); } }
        public ReportViewModel()
        {
            DataTableCollection = GetDataTable();
        }
        public DataTable DataTableCollection { get; set; }
        private DataTable GetDataTable()
        {
            dataTable.Columns.Add("Item Name", typeof(string));
            dataTable.Columns.Add("Item Price", typeof(int));
            dataTable.Columns.Add("ISBN", typeof(int));
            dataTable.Columns.Add("Category", typeof(string));
            dataTable.Columns.Add("Stock", typeof(int));
            dataTable.Columns.Add("Published Date", typeof(DateTime));
            return dataTable;
        }
        public void AddBookRows(Book book)
        {
            dataTable.Rows.Add($"{book.Name}", $"{book.Price}", $"{book.ISBN}", $"{book.Category}", $"{book.ItemStock}", $"{book.PrintDate}");
        }
        public void AddJournalRows(Journal journal)
        {
            dataTable.Rows.Add($"{journal.Name}", $"{journal.Price}", $"{journal.ISBN}", $"{journal.JournalCategory}", $"{journal.ItemStock}", $"{journal.PrintDate}");
        }
        public void NameReportFilter()
        {
            DataTable dt = dataTable.Copy();
            dataTable.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray.Contains(ReportName))
                {
                    dataTable.ImportRow(dr);
                }
            }
        }
    }
}
