using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Abstract;
using Data.Context;
using Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramwork
{
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        private readonly DataContext _context;
        public EfCartDal(DataContext context) : base(context)
        {
            _context=context;
        }

        public Cart? GetCartWithItems(string customerId)
        {
            return _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}