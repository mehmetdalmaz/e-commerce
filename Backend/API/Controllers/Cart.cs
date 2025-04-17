using AutoMapper;
using Core.DTO;
using Core.Entities;
using Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService; // Product işlemleri için ayrı servis varsayalım
        private readonly IMapper _mapper; // IMapper enjekte edilecek

        public CartController(ICartService cartService, IProductService productService, IMapper mapper)
        {
            _cartService = cartService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CartDto> GetCart()
        {
            var customerId = GetOrCreateCustomerId();
            var cart = _cartService.GetCartByCustomerId(customerId);

            if (cart == null)
            {
                // Sepet yoksa yeni bir boş sepet oluştur
                cart = new Cart { CustomerId = customerId };
                _cartService.TInsert(cart); // DB'ye ekle
            }

            var cartDto = _mapper.Map<CartDto>(cart);
            return Ok(cartDto);
        }

        [HttpPost]
        public IActionResult AddItemToCart(int productId, int quantity)
        {
            var customerId = GetOrCreateCustomerId();
            var cart = _cartService.GetCartByCustomerId(customerId) ?? new Cart { CustomerId = customerId };

            var product = _productService.TGetByID(productId);
            if (product == null) return NotFound("Product not found");

            _cartService.AddItem(cart, product, quantity);

            if (cart.CartId == 0)
                _cartService.TInsert(cart);
            else
                _cartService.TUpdate(cart);

            var cartDto = _mapper.Map<CartDto>(cart);
            return Ok(cartDto);
        }

        [HttpDelete]
        public IActionResult DeleteItemFromCart(int productId, int quantity)
        {
            var customerId = GetOrCreateCustomerId();
            var cart = _cartService.GetCartByCustomerId(customerId);

            if (cart == null) return NotFound("Cart not found");

            _cartService.DeleteItem(cart, productId, quantity);
            _cartService.TUpdate(cart);

            return Ok();
        }

        private string GetOrCreateCustomerId()
        {
            if (Request.Cookies.TryGetValue("customerId", out var customerId))
            {
                return customerId;
            }

            customerId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(1),
                IsEssential = true
            };

            Response.Cookies.Append("customerId", customerId, cookieOptions);

            return customerId;
        }
    }
}
