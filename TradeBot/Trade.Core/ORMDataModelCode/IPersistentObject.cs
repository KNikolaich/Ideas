namespace Trader.ORMDataModelCode
{
    public interface IPersistentObject
    {
        long ID { get; set; }

        bool Saving();
    }
}