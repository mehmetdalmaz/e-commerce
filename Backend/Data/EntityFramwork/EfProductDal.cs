using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Abstract;
using Data.Context;
using Data.Repo;

namespace Data.EntityFramwork
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(DataContext context) : base(context)
        {
        }
    }
}