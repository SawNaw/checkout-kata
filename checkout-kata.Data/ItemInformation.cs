using System;
using System.Collections.Generic;
using System.Text;

namespace checkout_kata.Data
{
    public class ItemInformation : IProductData
    {
        /// <summary>
        /// Gets a list of all items available from the data source.
        /// </summary>
        /// <remarks>
        /// In production-ready code, the data source would be a database. 
        /// For now we'll just simulate it in memory.
        /// </remarks>
        public List<Item> GetAllProductData()
        {

            List<Discount> appleDiscounts = new List<Discount>();
            appleDiscounts.Add(new Discount("3For130", 3, 130));
            appleDiscounts.Add(new Discount("6For200", 6, 200));

            List<Discount> biscuitDiscounts = new List<Discount>();
            biscuitDiscounts.Add(new Discount("2For45", 2, 45));
            biscuitDiscounts.Add(new Discount("4For60", 4, 60));

            List<Item> allItems = new List<Item>()
            {
                new Item("A99", 50, appleDiscounts),
                new Item("B15", 30, biscuitDiscounts),
                new Item("C40", 60),
                new Item("T34", 99),
            };

            return allItems;

        }
    }
}
