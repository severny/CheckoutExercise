namespace CheckoutLib
{
    public interface ISpecialOffer
    {
        decimal OfferPrice { get; }

        string SKU { get; }

    }
}