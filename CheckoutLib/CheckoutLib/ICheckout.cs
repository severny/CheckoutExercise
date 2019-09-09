namespace CheckoutLib
{
    public interface ICheckout
    {
        bool Scan(IItem item);
        decimal Total();
    }
}