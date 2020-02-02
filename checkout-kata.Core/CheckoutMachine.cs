using checkout_kata.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace checkout_kata.Core
{
    public class CheckoutMachine
    {
        private List<Item> AllItems { get; set; }

        // Shopping basket containing items (Item) and related quantities (int)
        public Dictionary<Item, int> ShoppingBasket { get; set; }

        public int TotalPrice = 0; // presumably in pence, therefore int.

        public void Scan(string sku)
        {
            // Check that the scanned item is available for purchase.
            var item = AllItems.FirstOrDefault(x => x.Sku == sku);

            if (item == null)
            {
                Log("An invalid item was scanned.");
                return;
            }

            // Add the item to the basket.
            if (!ShoppingBasket.ContainsKey(item))
            {
                ShoppingBasket.Add(item, 1);
                Log($"A new item {item.Sku} was added. Total price: {TotalPrice}");
            }
            else
            {
                ShoppingBasket[item]++;
                Log($"Quantity of {item.Sku} is now {ShoppingBasket[item]}.");
            }

            TotalPrice += item.UnitPrice;
        }

        public CheckoutMachine()
        {
            ItemInformation itemInfo = new ItemInformation();

            AllItems = itemInfo.GetAllProductData();

            ShoppingBasket = new Dictionary<Item, int>();
        }

        // User presses the Done button on the screen.
        public void Done()
        {
            ProcessAllDiscounts();

            Log($"Your total price is: {TotalPrice}");
        }

        private void ProcessAllDiscounts()
        {
            foreach (var addedItem in ShoppingBasket)
            {
                if (addedItem.Key.QuantityNeededForSpecialOffer != 0) // if a discount is potentially applicable
                {
                    int unitPrice = addedItem.Key.UnitPrice;
                    int quantityNeededForSpecialOffer = addedItem.Key.QuantityNeededForSpecialOffer;
                    int specialOfferPrice = addedItem.Key.SpecialOfferPrice;
                    int addedItemCount = addedItem.Value;

                    int numberOfTimesToApplySameDiscount = addedItem.Value % quantityNeededForSpecialOffer;

                    // Remove the undiscounted price, and replace with the discounted price.
                    TotalPrice -= (quantityNeededForSpecialOffer * unitPrice) * numberOfTimesToApplySameDiscount;
                    TotalPrice += specialOfferPrice * numberOfTimesToApplySameDiscount;

                    Log($"Discount for {addedItem.Key.Sku} has been computed. Total price is now {TotalPrice}.");
                }
            }
        }

        public void ClearShoppingBasket()
        {
            ShoppingBasket = new Dictionary<Item, int>();
        }

        /// <summary>
        /// Logs a status message. In production code, this would be done via a proper logging interface.
        /// </summary>
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
