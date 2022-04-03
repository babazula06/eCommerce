using System;
using System.Collections.Generic;
using System.Text;
using _Core.Utilities.Result;
using _Models.Concrete;


namespace _Business.Abstract
{
    public interface ICampaignService
    {
     
        IResult create_campaign( string Name, string ProductCode, int Duration,Decimal PriceManipulationLimit, int TargetSalesCount);
        IResult get_campaign_info(string Name);
        


    }

}
