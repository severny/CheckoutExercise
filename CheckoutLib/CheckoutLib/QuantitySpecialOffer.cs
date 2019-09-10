using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutLib
{
    public class QuantitySpecialOffer : ISpecialOffer
    {
        public string SKU { get; private set; }
        public int Quantity { get; private set; }
        public decimal OfferPrice { get; private set; }

        public QuantitySpecialOffer(string sku, int quantiy, decimal offerPrice)
        {
            SKU = sku;
            Quantity = quantiy;
            OfferPrice = offerPrice;
        }
    }
}
