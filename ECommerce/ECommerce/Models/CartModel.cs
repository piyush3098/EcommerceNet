using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CartModel
    {
        [Key]
        public int cart_item_id { get; set; }

        [ForeignKey("ProductModel")]
        public int product_id { get; set; }

        [ForeignKey("UserModel")]
        public int user_id { get; set; }
        public int cart_item_quantity { get; set; }

        public ProductModel Product { get; set; }

        public UserModel UserModel { get; set; }
    }
}
