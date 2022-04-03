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
    public class HourController : Controller
    {
        private IHourService _HourService;       

        public HourController(IHourService HourService)
        {
            _HourService = HourService;
           
        }



        [HttpPost("increase_time")]

        public IActionResult increase_time(int AddHour)
        {
            var result = _HourService.increase_time(AddHour);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get_time")]

        public IActionResult get_time()
        {
            var result = _HourService.get_time();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
