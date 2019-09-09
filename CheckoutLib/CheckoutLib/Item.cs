﻿using System;

namespace CheckoutLib
{
    public class Item
    {
        public string SKU { get; private set; }
        public decimal UnitPrice { get; private set; }

        public Item(string sku, decimal unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
        }
    }
}
