using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDAl;
        public CartManager(ICartDal cartDal)
        {
            _cartDAl = cartDal;
        }


        public void AddItem(Cart cart, Product product, int quantity)
        {
            var item = cart.CartItems.Where(c => c.ProductId == product.Id).FirstOrDefault();

            if (item == null)
            {
                cart.CartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void DeleteItem(Cart cart, int productId, int quantity)
        {
            var item = cart.CartItems.Where(c => c.ProductId == productId).FirstOrDefault();

            if (item == null)
            {
                return;
            }
            item.Quantity -= quantity;
            if (item.Quantity <= 0)
            {
                cart.CartItems.Remove(item);
            }



        }

        public Cart? GetCartByCustomerId(string customerId)
        {
            return _cartDAl.GetCartWithItems(customerId);
        }


        public void TDelete(Cart t)
        {
            _cartDAl.Delete(t);
        }

        public Cart TGetByID(int id)
        {
            return _cartDAl.GetByID(id);
        }

        public List<Cart> TGetList()
        {
            return _cartDAl.GetList();
        }

        public void TInsert(Cart t)
        {
            _cartDAl.Insert(t);
        }

        public void TUpdate(Cart t)
        {
            _cartDAl.Update(t);
        }
    }
}