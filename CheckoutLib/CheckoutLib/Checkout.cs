using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutLib
{
    public class Checkout : ICheckout
    {

        private IList<IItem> _scanedItems = new List<IItem>();
        private IPriceProcessor<ISpecialOffer> _priceProcessor;

        public Checkout(IPriceProcessor<ISpecialOffer> priceProcessor)
        {
            _priceProcessor = priceProcessor;
        }

        public decimal Total()
        {
            return _priceProcessor.GetPrice(_scanedItems);
        }

        public bool Scan(IItem item)
        {

            if (item == null)
            {
                return false;
            }

            if (!_scanedItems.Contains(item))
            {
                _scanedItems.Add(item);
            }

            return true;
        }

        public int ScannedItemsCount()
        {
            return _scanedItems.Count;
        }
    }
}
