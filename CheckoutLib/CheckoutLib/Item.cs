using System;

namespace CheckoutLib
{
    public class Item : IItem
    {
        public string SKU { get; private set; }
        public decimal Price { get; private set; }

        public Item(string sku, decimal unitPrice)
        {
            SKU = sku;
            Price = unitPrice;
        }
    }
}
