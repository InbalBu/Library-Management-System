namespace Services
{
    public interface INotify
    {
        void AddedItem(string add);
        void SucceededRent(string rent);
        void FailedRent(string rentFailed);
        void NotFoundItem(string missingItem);
        void LateToReturn(string late);
        void UpdateStock(string update);
        void UpdateDiscount(string discout);
    }
}
