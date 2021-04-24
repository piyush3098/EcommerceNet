using ECommerce.iControllers;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class CartService : iCart
    {
        public AppDbContext _Context;
        public CartService(AppDbContext context)
        {
            _Context = context;
        }
        public CartModel addtoCart(CartModel cart)
        {
            _Context.CartMaster.Add(cart);
            _Context.SaveChanges();
            return cart;
        }

        public void deleteCart(CartModel cart)
        {
            _Context.CartMaster.Remove(cart);
            _Context.SaveChanges();
        }

        public CartModel GetCart(int id, int uid)
        {
            return _Context.CartMaster.SingleOrDefault(x => x.cart_item_id == id && x.user_id == uid);
        }

        public CartModel GetCartId(int id)
        {
            return _Context.CartMaster.SingleOrDefault(x => x.cart_item_id == id);
        }

        public CartModel GetUserId(int uid)
        {
            return _Context.CartMaster.SingleOrDefault(x => x.user_id == uid);
        }

        public void updateCart(CartModel cart)
        {
            var cartid = _Context.CartMaster.SingleOrDefault(x => x.cart_item_id == cart.cart_item_id && x.user_id == cart.user_id);
            if (cartid != null)
            {
                cartid.cart_item_quantity = cart.cart_item_quantity;
                _Context.CartMaster.Update(cartid);
                _Context.SaveChanges();
            }
        }
    }
}
