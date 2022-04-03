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
    public class CampaignController : Controller
    {
        private ICampaignService _CampaignService;       

        public CampaignController(ICampaignService CampaignService)
        {
            _CampaignService = CampaignService;
           
        }



        [HttpPost("create_campaign")]

        public IActionResult create_campaign(string Name, string ProductCode, int Duration, Decimal PriceManipulationLimit, int TargetSalesCount)
        {
            var result = _CampaignService.create_campaign( Name,  ProductCode,  Duration,  PriceManipulationLimit,  TargetSalesCount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get_campaign_info")]

        public IActionResult get_campaign_info(string Name)
        {
            var result = _CampaignService.get_campaign_info(Name);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
