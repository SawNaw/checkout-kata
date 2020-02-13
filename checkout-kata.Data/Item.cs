using System;
using System.Collections.Generic;

namespace checkout_kata.Data
{
    public class Item
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; } // Assuming the price is stored in pence, therefore integer.

        public List<Discount> Discounts { get; set; }

        /// <summary>
        /// Initialises a new Item object without any applicable discounts.
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <param name="unitPrice">The unit price of the item when discounts are not applicable.</param>
        public Item(string sku, int unitPrice)
        {
            this.Sku = sku;
            this.UnitPrice = unitPrice;
            Discounts = new List<Discount>();
        }

        /// <summary>
        /// Initialises a new Item object that has applicable discounts.
        /// </summary>
        /// <param name="sku">The SKU of the item.</param>
        /// <param name="unitPrice">The unit price of the item when discounts are not applicable.</param>
        /// <param name="discounts">The discounts that are applicable to the item.</param>
        public Item(string sku, int unitPrice, List<Discount> discounts)
        {
            this.Sku = sku;
            this.UnitPrice = unitPrice;
            Discounts = discounts;
        }
    }
}
