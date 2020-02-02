using System;

namespace checkout_kata.Data
{
    public class Item
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; } // Assuming the price is stored in pence, therefore integer.

        /// <summary>
        /// The quantity that qualifies an item for a special offer price.
        /// </summary>
        public int QuantityNeededForSpecialOffer { get; set; }

        /// <summary>
        /// The special offer price available upon purchasing a certain quantity of an item.
        /// </summary>
        public int SpecialOfferPrice { get; set; }

        public Item(string sku, int unitPrice, int specialOfferQuantity, int specialOfferPrice)
        {
            this.Sku = sku;
            this.UnitPrice = unitPrice;
            this.QuantityNeededForSpecialOffer = specialOfferQuantity;
            this.SpecialOfferPrice = specialOfferPrice;
        }
    }
}
