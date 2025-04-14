using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Data.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Task TGetListAsync();
    }
}