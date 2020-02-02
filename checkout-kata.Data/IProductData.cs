using System;
using System.Collections.Generic;
using System.Text;

namespace checkout_kata.Data
{
    public interface IProductData
    {
        List<Item> GetAllProductData();
    }
}
