namespace checkout_kata.Data
{
    public class Discount
    {
        /// <summary>
        /// The name of the discount.
        /// </summary>
        public string DiscountName { get; set; }

        /// <summary>
        /// The quantity that qualifies an item for a discounted price.
        /// </summary>
        public int QuantityNeededForDiscount { get; set; }

        /// <summary>
        /// The discounted price available upon purchasing a certain quantity of an item.
        /// </summary>
        public int DiscountPrice { get; set; }

        public Discount(string discountName, int quantityNeededForDiscount, int discountPrice)
        {
            this.DiscountName = discountName;
            this.QuantityNeededForDiscount = quantityNeededForDiscount;
            this.DiscountPrice = discountPrice;
        }
    }
}