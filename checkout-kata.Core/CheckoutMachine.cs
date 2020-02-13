using checkout_kata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;

namespace checkout_kata.Core
{
    public class CheckoutMachine
    {
        private List<Item> AllItems { get; set; }

        // Shopping basket containing items (Item) and related quantities (int)
        public Dictionary<Item, int> ShoppingBasket { get; set; }

        // presumably in pence, therefore int.
        public int TotalPrice { get; set; } 

        public Logger Logger { get; set; }

        public void Scan(string sku)
        {
            // Check that the scanned item is available for purchase.
            var item = AllItems.FirstOrDefault(x => x.Sku == sku);

            if (item == null)
            {              
                Logger.Log("An invalid item was scanned.");
                throw new InvalidBarcodeException("Invalid item");
            }

            // Add the item to the basket.
            if (!ShoppingBasket.ContainsKey(item))
            {
                ShoppingBasket.Add(item, 1);
                Logger.Log($"A new item {item.Sku} was added. Total price: {TotalPrice}");
            }
            else
            {
                ShoppingBasket[item]++;
                Logger.Log($"Quantity of {item.Sku} is now {ShoppingBasket[item]}.");
            }

            TotalPrice += item.UnitPrice;
        }

        public CheckoutMachine()
        {
            ItemInformation itemInfo = new ItemInformation();

            AllItems = itemInfo.GetAllProductData();

            ShoppingBasket = new Dictionary<Item, int>();

            TotalPrice = 0;

            Logger = new Logger();
        }

        // User presses the Done button on the screen.
        public void Done()
        {
            ProcessAllDiscounts();

            Logger.Log($"Your total price is: {TotalPrice}");
        }

        
        [Obsolete("This method is obsolete and a candidate for deletion", true)]
        private void ProcessAllDiscounts_OLD()
        {
            foreach (var addedItem in ShoppingBasket)
            {
                if (addedItem.Key.Discounts.Count > 0) 
                {
                    int unitPrice = addedItem.Key.UnitPrice;
                    int addedItemCount = addedItem.Value;

                    int quantityNeededForDiscount = addedItem.Key.Discounts.First().QuantityNeededForDiscount;
                    int discountPrice = addedItem.Key.Discounts.First().DiscountPrice;
                    
                    int numberOfTimesToApplySameDiscount = addedItem.Value / quantityNeededForDiscount;

                    // Remove the undiscounted price, and replace with the discounted price.
                    // As an example, if there are 7 items and a "2 for 50p" discount is applicable,
                    // the discount should be applied 7 / 2 = 3 times.
                    int undiscountedPriceForBulkDeal = (quantityNeededForDiscount * unitPrice) * numberOfTimesToApplySameDiscount;
                    TotalPrice -= undiscountedPriceForBulkDeal;
                    int bulkDiscountedPrice = discountPrice * numberOfTimesToApplySameDiscount;
                    TotalPrice += bulkDiscountedPrice;

                    Logger.Log($"Discount for {addedItem.Key.Sku} has been computed. Total price is now {TotalPrice}.");
                }
            }
        }

        /// <summary>
        /// Calculates all the discounts that are applicable to the items in the shopping basket.
        /// </summary>
        private void ProcessAllDiscounts()
        {
            foreach (var item in ShoppingBasket)
            {
                int unitPrice = item.Key.UnitPrice;

                int itemCount = item.Value;

                while (item.Key.Discounts.Count > 0)
                {
                    var currentDiscount = item.Key.Discounts.MaxBy(x => x.QuantityNeededForDiscount)
                                                            .Single();

                    int quantityNeededForDiscount = currentDiscount.QuantityNeededForDiscount;

                    int discountPrice = currentDiscount.DiscountPrice;

                    if (itemCount >= quantityNeededForDiscount)
                    {
                        TotalPrice -= unitPrice * quantityNeededForDiscount;
                        TotalPrice += discountPrice;

                        Logger.Log($"Discount for {item.Key.Sku} has been computed. Total price is now {TotalPrice}.");

                        itemCount -= quantityNeededForDiscount;
                    }
                    else
                    {
                        item.Key.Discounts.Remove(currentDiscount);
                    }
                }
            }
        }

        public void ClearShoppingBasket()
        {
            ShoppingBasket = new Dictionary<Item, int>();
        }
    }
}
