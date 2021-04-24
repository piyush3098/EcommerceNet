using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Models;
using System.Threading.Tasks;

namespace ECommerce.iControllers
{
   public interface iCart
    {
         CartModel addtoCart(CartModel cart);
        public CartModel GetCart(int id, int uid);
        public void updateCart(CartModel cart);
        public void deleteCart(CartModel cart);
        public CartModel GetCartId(int id);
        public CartModel GetUserId(int uid);
    }
}
