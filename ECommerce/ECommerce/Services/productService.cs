using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class productService : iController.iProductController
    {
        public AppDbContext _Context;
        public productService(AppDbContext context)
        {
            _Context = context;
        }
        public ProductModel addProduct(ProductModel product)
        {
            _Context.ProductMaster.Add(product);
            _Context.SaveChanges();
            return product;
        }

        public void DeleteProduct(ProductModel product)
        {

            _Context.ProductMaster.Remove(product);
            _Context.SaveChanges();
        }

        public ProductModel GetProduct(int id)
        {
            return _Context.ProductMaster.SingleOrDefault(x => x.Product_Id == id);
        }

        public void UpdateProduct(ProductModel product)
        {
            var updateProduct = _Context.ProductMaster.Find(product.Product_Id);
            if (updateProduct != null)
            {
                updateProduct.Product_Name = product.Product_Name;
                updateProduct.Product_Price = product.Product_Price;
                updateProduct.Product_ImageUrl = product.Product_ImageUrl;
                updateProduct.Product_Description = product.Product_Description;
                _Context.ProductMaster.Update(updateProduct);
                _Context.SaveChanges();
            }
        }
    }
}
