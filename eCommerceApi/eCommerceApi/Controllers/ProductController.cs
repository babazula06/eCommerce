using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Business.Abstract;
using Microsoft.AspNetCore.Cors;
using _Models.Concrete;

namespace DeposWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _ProductService;       

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
           
        }



        [HttpPost("create_product")]

        public IActionResult create_product(string ProductCode, Decimal Price, int Stock)
        {
            var result = _ProductService.create_product( ProductCode, Price, Stock);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get_product_info")]

        public IActionResult get_product_info(string ProductCode)
        {
            var result = _ProductService.get_product_info(ProductCode);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
