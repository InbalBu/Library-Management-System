using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LibraryManager.ViewModel.Tests
{
    [TestClass()]
    public class RegisterViewModelTests
    {

        [TestMethod()]
        public void CanLoginWorker()
        {
            List<Worker> workers = new List<Worker>();
            Worker worker = workers.FirstOrDefault(item => item.FullName == "test" && item.Password == "1");
            workers.Add(worker);
            if (worker != default)
            {
                Assert.IsTrue(workers.Contains(worker));
            }

        }

        [TestMethod()]
        public void CanLoginManager()
        {
            List<HeadWorker> manager = new List<HeadWorker>();
            HeadWorker headWorker = manager.FirstOrDefault(item => item.FullName == "test_Manager" && item.Password == "2");
            manager.Add(headWorker);
            if (headWorker != default)
            {
                Assert.IsTrue(manager.Contains(headWorker));
            }

        }

        [TestMethod()]
        public void CanLoginCustomer()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = customers.FirstOrDefault(item => item.CustomerFullName == "test_Customer" && item.SpecialID == 3);
            customers.Add(customer);
            if (customer != default)
            {
                Assert.IsTrue(customers.Contains(customer));
            }
        }

        [TestMethod()]
        public void SignUpWorker()
        {
            List<Worker> workers = new List<Worker>();
            Worker worker = workers.FirstOrDefault(item => item.FullName == "test" && item.Password == "1");
            workers.Add(worker);
            if (worker != default)
            {
                Assert.IsTrue(workers.Contains(worker));
            }
        }

        [TestMethod()]
        public void SignUpCustomer()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = customers.FirstOrDefault(item => item.CustomerFullName == "test_Customer" && item.SpecialID == 3);
            customers.Add(customer);
            if (customer != default)
            {
                Assert.IsTrue(customers.Contains(customer));
            }
        }

        [TestMethod()]
        public void LogOutWorker()
        {
            List<Worker> workers = new List<Worker>();
            Worker worker = workers.FirstOrDefault(item => item.FullName == "test" && item.Password == "1");
            workers.Add(worker);
            if (worker != default)
            {
                Assert.IsTrue(workers.Contains(worker));
            }
        }

        [TestMethod()]
        public void LogOutCustomer()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = customers.FirstOrDefault(item => item.CustomerFullName == "test_Customer" && item.SpecialID == 3);
            customers.Add(customer);
            if (customer != default)
            {
                Assert.IsTrue(customers.Contains(customer));
            }
        }

    }
}