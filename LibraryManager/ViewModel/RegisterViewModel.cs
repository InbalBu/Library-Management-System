using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LibraryManager.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        #region RelayCommands Lists
        List<Worker> ListOfWorker { get; set; }
        List<Customer> ListOfCustomer { get; set; }
        public RelayCommand RegisterWorker { get; set; }
        public RelayCommand RegisterCustomer { get; set; }
        public RelayCommand LoginWorker { get; set; }
        public RelayCommand LoginManager { get; set; }
        public RelayCommand LoginCustomer { get; set; }
        public RelayCommand LogOutWorker { get; set; }
        public RelayCommand LogOutCustomer { get; set; }
        #endregion

        public Customer CurrentCustomer;
        HeadWorker headWorker;
        Worker worker;
        Customer customerSign;
        private Visibility customerVisibility;
        private Visibility managerVisibility;
        private Visibility workerAndManagerVisibility;

        #region Access
        public Visibility CustomerVisibility
        {
            get { return customerVisibility; }
            set => Set(ref customerVisibility, value);
        }
        public Visibility WorkerAndManagerVisibility
        {
            get { return workerAndManagerVisibility; }
            set => Set(ref workerAndManagerVisibility, value);
        }
        public Visibility ManagerVisibility
        {
            get { return managerVisibility; }
            set => Set(ref managerVisibility, value);
        }

        #endregion

        #region Properties

        private HeadWorker manager;
        private Worker employee;
        private Customer customer;

        private string workerName;
        private string managerName;
        private string customerName;

        private string workerPassword;
        private string managerPassword;

        private long specialID;
        private double wallet = 500;
        private DateTime birthDate;
        private DateTime startDate;

        #endregion

        #region CustomerSignUp
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                Set(ref customerName, value);
                customerSign = new Customer()
                {
                    CustomerFullName = customerName,
                    SpecialID = specialID,
                    Wallet = wallet
                };
            }
        }

        public long SpecialID
        {
            get { return specialID; }
            set
            {
                Set(ref specialID, value);
                customerSign = new Customer()
                {
                    CustomerFullName = customerName,
                    SpecialID = specialID,
                    Wallet = wallet
                };
            }
        }
        public double Wallet
        {
            get { return wallet; }
            set
            {
                Set(ref wallet, value);
                customerSign = new Customer()
                {
                    CustomerFullName = customerName,
                    SpecialID = specialID,
                    Wallet = wallet
                };
            }
        }
        #endregion

        #region ManagerSignUp
        public string ManagerPassword
        {
            get { return managerPassword; }
            set
            {
                Set(ref managerPassword, value);
                headWorker = new HeadWorker()
                {
                    FullName = managerName,
                    Password = managerPassword
                };
            }
        }

        public string ManagerName
        {
            get { return managerName; }
            set
            {
                Set(ref managerName, value);
                headWorker = new HeadWorker()
                {
                    FullName = managerName,
                    Password = managerPassword
                };
            }
        }

        #endregion 

        #region WorkerSignUp

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                Set(ref birthDate, value);
                worker = new Worker()
                {
                    FullName = workerName,
                    Password = workerPassword,
                    BirthDate = birthDate,
                    StartDate = startDate
                };
            }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                Set(ref startDate, value);
                worker = new Worker()
                {
                    FullName = workerName,
                    Password = workerPassword,
                    BirthDate = birthDate,
                    StartDate = startDate
                };
            }
        }
        public string WorkerPassword
        {
            get { return workerPassword; }
            set
            {
                Set(ref workerPassword, value);
                worker = new Worker()
                {
                    FullName = workerName,
                    Password = workerPassword,
                    BirthDate = birthDate,
                    StartDate = startDate
                };
            }
        }
        public string WorkerName
        {
            get { return workerName; }
            set
            {
                Set(ref workerName, value);
                worker = new Worker()
                {
                    FullName = workerName,
                    Password = workerPassword,
                    BirthDate = birthDate,
                    StartDate = startDate
                };
            }
        }
        #endregion
        public RegisterViewModel()
        {
            ListOfWorker = new List<Worker>();
            ListOfCustomer = new List<Customer>();
            RegisterWorker = new RelayCommand(SignUpWorker);
            RegisterCustomer = new RelayCommand(SignUpCustomer);
            LoginWorker = new RelayCommand(CanLoginWorker);
            LoginManager = new RelayCommand(CanLoginManager);
            LoginCustomer = new RelayCommand(CanLoginCustomer);
            LogOutWorker = new RelayCommand(WorkerLogOut);
            LogOutCustomer = new RelayCommand(CustomerLogOut);
        }
        public HeadWorker Worker { get => manager; set { Set(ref manager, value); } }
        public Worker Employee { get => employee; set { Set(ref employee, value); } }
        public Customer Customer { get => customer; set { Set(ref customer, value); } }

        #region Login
        private void CanLoginWorker()
        {
            WorkerAndManagerVisibility = Visibility.Visible;
            ManagerVisibility = Visibility.Collapsed;
            CustomerVisibility = Visibility.Collapsed;
            Worker worker = ListOfWorker.FirstOrDefault(item => item.FullName == workerName && item.Password == workerPassword);
            if (worker != default)
            {
                WorkerName = "";
                WorkerPassword = "";
                MessageBox.Show("Logged In!");
            }
            else MessageBox.Show("Wrong Info!");
        }
        private void CanLoginManager() // Set from head - only 1 manager
        {
            WorkerAndManagerVisibility = Visibility.Visible;
            ManagerVisibility = Visibility.Visible;
            customerVisibility = Visibility.Collapsed;
            HeadWorker headWorker = new HeadWorker { FullName = ManagerName = "inbal", Password = managerPassword = "123" };
            if (headWorker != default)
            {
                ManagerName = "";
                ManagerPassword = "";
                MessageBox.Show("Logged In!");
            }
            else MessageBox.Show("Wrong Info!");
        }
        private void CanLoginCustomer()
        {
            WorkerAndManagerVisibility = Visibility.Collapsed;
            ManagerVisibility = Visibility.Collapsed;
            customerVisibility = Visibility.Visible;
            Customer customer = ListOfCustomer.FirstOrDefault(item => item.CustomerFullName == customerName && item.SpecialID == specialID);
            if (customer != default)
            {
                CurrentCustomer = customer;
                CustomerName = "";
                SpecialID = 0;
                MessageBox.Show("Logged In!");

            }
            else MessageBox.Show("Wrong Info!");
        }
        #endregion

        #region SignUp
        private void SignUpWorker()
        {
            Worker employeeWorker = new Worker { FullName = workerName, Password = workerPassword, StartDate = startDate, BirthDate = birthDate };
            if (!ListOfWorker.Contains(employeeWorker))
            {
                ListOfWorker.Add(employeeWorker);
                worker.SaveJsonWorker(employeeWorker.ToString());
                worker.UploadJsonWorker();
            }
            MessageBox.Show("Signed Up Successfuly!");
            WorkerName = "";
            WorkerPassword = "";
            startDate = DateTime.Now;
            birthDate = DateTime.Now;
        }
        private void SignUpCustomer()
        {
            Customer customer = new Customer { CustomerFullName = customerName, SpecialID = specialID, Wallet = 500 };
            if (!ListOfCustomer.Contains(customer))
            {
                ListOfCustomer.Add(customer);
                customer.SaveJsonCustomer(customer.ToString());
                customer.UploadJsonCustomer();
            }
            MessageBox.Show("Signed Up Successfuly");
            CustomerName = "";
            SpecialID = 0;
        }
        #endregion

        #region LogOut
        private void WorkerLogOut()
        {
            WorkerAndManagerVisibility = Visibility.Visible;
            ManagerVisibility = Visibility.Visible;
            CustomerVisibility = Visibility.Visible;
            Worker worker = ListOfWorker.FirstOrDefault(item => item.FullName == workerName && item.Password == workerPassword);
            if (worker != default)
            {
                MessageBox.Show("Logged out Successfuly!");
                WorkerName = string.Empty;
                WorkerPassword = string.Empty;
            }
            else MessageBox.Show("Error, please check if details are correct");

        }
        private void CustomerLogOut()
        {
            WorkerAndManagerVisibility = Visibility.Visible;
            ManagerVisibility = Visibility.Visible;
            CustomerVisibility = Visibility.Visible;
            Customer customer = ListOfCustomer.FirstOrDefault(item => item.CustomerFullName == customerName && item.SpecialID == specialID);
            if (customer != default)
            {
                MessageBox.Show("Logged out Successfuly!");
                CustomerName = string.Empty;
                SpecialID = 0;
            }
            else
            {
                MessageBox.Show("Error, please check if details are correct");
                WorkerAndManagerVisibility = Visibility.Collapsed;
                ManagerVisibility = Visibility.Collapsed;
                CustomerVisibility = Visibility.Visible;
            }
        }
        #endregion
    }
}
