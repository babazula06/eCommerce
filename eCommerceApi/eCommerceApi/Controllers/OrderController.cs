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
    public class OrderController : Controller
    {
        private IOrderService _OrderService;       

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
           
        }



        [HttpPost("create_order")]

        public IActionResult create_order(string ProductCode, int Quantity)
        {
            var result = _OrderService.create_order(ProductCode, Quantity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



    }
}
