using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutLib
{
    public class Checkout : ICheckout
    {

        private IList<IItem> _scanedItems = new List<IItem>();

        public decimal Total()
        {
            return _scanedItems.Sum(i => i.Price);
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
