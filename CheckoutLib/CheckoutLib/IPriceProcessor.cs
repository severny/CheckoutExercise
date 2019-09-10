using System.Collections.Generic;

namespace CheckoutLib
{
    public interface IPriceProcessor<out T> where T : ISpecialOffer
    {
        decimal GetPrice(IList<IItem> scanedItems);
    }
}