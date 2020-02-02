using System;

namespace checkout_kata.Data
{
    public class Item
    {
        public string Sku { get; set; }
        public double UnitPrice { get; set; } 

        /// <summary>
        /// The quantity that qualifies an item for a special offer price.
        /// </summary>
        public int QuantityNeededForSpecialOffer { get; set; }

        /// <summary>
        /// The special offer price available upon purchasing a certain quantity of an item.
        /// </summary>
        public int SpecialOfferPrice { get; set; }

        public Item(string sku, double unitPrice, int specialOfferQuantity, int specialOfferPrice)
        {
            this.Sku = sku;
            this.UnitPrice = unitPrice;
            this.QuantityNeededForSpecialOffer = specialOfferQuantity;
            this.SpecialOfferPrice = specialOfferPrice;
        }
    }
}
