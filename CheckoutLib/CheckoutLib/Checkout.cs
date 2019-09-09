using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutLib
{
    public class Checkout : ICheckout
    {

        private IList<IItem> _scanedItems = new List<IItem>();

        public decimal Total()
        {
            return decimal.Zero;
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
