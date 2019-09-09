namespace CheckoutLib
{
    public interface IItem
    {
        string SKU { get; }
        decimal Price { get; }
    }
}