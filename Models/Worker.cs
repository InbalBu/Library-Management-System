using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Models
{
    public class Worker : IEmployee
    {
        List<Worker> WorkerJsonItems = new List<Worker>();
        private string fullName;
        private string password;
        private DateTime startDate;
        private DateTime birthDate;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        #region Json
        public void SaveJsonWorker(string worker)
        {
            var myClass = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText($"C:/Users/inbal/source/repos/LibraryManager/{worker}.json", myClass);
        }
        public void UploadJsonWorker()
        {
            WorkerJsonItems.Clear();
            string json;
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\inbal\source\repos\LibraryManager\", "*.json"))
            {
                json = File.ReadAllText(file);
                var classJson = JsonConvert.DeserializeObject<Worker>(json);

                WorkerJsonItems.Add(classJson);
            }
        }
        #endregion

    }
}
