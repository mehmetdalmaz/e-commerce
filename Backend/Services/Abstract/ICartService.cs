using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Abstract;

namespace Services.Abstract
{
    public interface ICartService: IGenericService<Cart>
    {
     void AddItem(Cart cart, Product product, int quantity);
     void DeleteItem(Cart cart, int productId, int quantity);
    }
}