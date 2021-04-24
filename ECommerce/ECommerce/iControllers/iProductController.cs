using System;
using System.Collections.Generic;
using ECommerce.Models;
namespace ECommerce.iController
{
    public interface iProductController
    {
        ProductModel addProduct(ProductModel product);
        public ProductModel GetProduct(int id);
        void UpdateProduct(ProductModel product);
        void DeleteProduct(ProductModel product);
    }
}

