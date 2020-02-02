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
            List<Item> allItems = new List<Item>()
            {
                new Item("A99", 50, 3, 130),
                new Item("B15", 30, 2, 45),
                new Item("C40", 60, 0, 0),
                new Item("T34", 99, 0, 0),
            };

            return allItems;

        }
    }
}
