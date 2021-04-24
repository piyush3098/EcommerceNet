using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ECommerce.Models
{
    public class ProductModel
    {
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public float Product_Price { get; set; }
        public string Product_ImageUrl { get; set; }
        public string Product_Description { get; set; }
    }
}
