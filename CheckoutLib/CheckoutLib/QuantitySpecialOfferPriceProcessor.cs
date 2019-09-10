using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutLib
{
    public class QuantitySpecialOfferPriceProcessor : IPriceProcessor<QuantitySpecialOffer>
    {

        private IList<QuantitySpecialOffer> _specialOffers = new List<QuantitySpecialOffer>();

        public decimal GetPrice(IList<IItem> scanedItems)
        {
            var specialOffersWithItems = new List<SpecialOfferWithItems>();

            foreach(var item in scanedItems )
            {
                var offerWithItems = specialOffersWithItems.FirstOrDefault( i => i.SKU.Equals(item.SKU) && i.IsOfferMeet == false);
                if (offerWithItems == null)
                {
                    offerWithItems = new SpecialOfferWithItems(_specialOffers.FirstOrDefault(s => s.SKU.Equals(item.SKU)));
                    specialOffersWithItems.Add(offerWithItems);
                }

                offerWithItems.AddItemToOffer(item);
            }
            return specialOffersWithItems.Sum(i => i.Price);
        }

        public void AddSpecialOffer( params QuantitySpecialOffer[] specialOffers )
        {
            if (specialOffers == null)
            {
                throw new Exception("Please add at least one special offer");
            }

            ((List<QuantitySpecialOffer>)_specialOffers).AddRange(specialOffers);
        }


        private class SpecialOfferWithItems
        {

            private IList<IItem> _items = new List<IItem>();

            private QuantitySpecialOffer _specialOffer;

            public bool IsOfferMeet => _specialOffer != null && _items.Count == _specialOffer.Quantity;

            public decimal Price => IsOfferMeet ? _specialOffer.OfferPrice : _items.Sum( i => i.Price);

            public string SKU => _specialOffer != null ? _specialOffer.SKU : string.Empty;

            public SpecialOfferWithItems(QuantitySpecialOffer specialOffer)
            {
                _specialOffer = specialOffer;
            }

            public void AddItemToOffer(IItem item)
            {
                if (item == null)
                {
                    throw new Exception("Item can't be null when adding to special offer");
                }

                if (_specialOffer == null || _specialOffer.SKU.Equals(item.SKU))
                {
                    _items.Add(item);
                    
                }

            }

        }
    }
}
