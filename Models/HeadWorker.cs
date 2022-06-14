namespace Models
{
    public class HeadWorker : IEmployee
    {
        private string fullName;
        private string password;
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
    }
}
