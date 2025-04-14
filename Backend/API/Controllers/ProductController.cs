using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

       public ProductController(IProductService productService)
       {
        _productService=productService;
       }

      [HttpGet]
    public IActionResult GetProducts()
    {
         var products = _productService.TGetList(); 
         return Ok(products);
    }
    

     [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        
        var products = _productService.TGetByID(id);

        if (products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }
    [HttpPost]
    public IActionResult ProductInsert(Product product)
    {
        _productService.TInsert(product);
        return Ok();
    }

       

      
       
      
    }
    }
