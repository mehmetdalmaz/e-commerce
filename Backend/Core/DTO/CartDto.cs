using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class CartDto
    {
        public int CartId { get; set; }
        public string? CustomerId { get; set; }
        public List<CartItemDTO> CartItems { get; set; } = new();
    }

    public class CartItemDTO
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }

    }

}