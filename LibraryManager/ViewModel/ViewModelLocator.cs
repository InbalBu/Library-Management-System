using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace LibraryManager.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
          
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ButtonViewModel>();
            SimpleIoc.Default.Register<TextViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<RentViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public ButtonViewModel Buttons
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ButtonViewModel>();
            }
        }
        public TextViewModel Text
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TextViewModel>();
            }
        }
        public RegisterViewModel Register
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterViewModel>();
            }
        }
        public RentViewModel Rent
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RentViewModel>();
            }
        }
        public ReportViewModel Report
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReportViewModel>();
            }
        }
    }
}