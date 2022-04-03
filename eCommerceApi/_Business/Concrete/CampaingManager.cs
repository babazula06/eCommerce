using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _Business.Abstract;
using _Core.Utilities.Result;
using _Models.Concrete;
using _Business.Constants;
using _DataAccess.Abstract;


namespace _Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private ICampaignDal _CampaignDal;
        private IOrderDal _OrderDal;

        public CampaignManager(ICampaignDal CampaignDal, IOrderDal OrderDal)
        {
            _CampaignDal = CampaignDal;
            _OrderDal = OrderDal;
        }




       


        public IResult create_campaign(string Name, string ProductCode, int Duration, Decimal PriceManipulationLimit, int TargetSalesCount)
        {
            Campaign Campaign = new Campaign();
            Campaign.Name = Name;
            Campaign.ProductCode = ProductCode;
            Campaign.Duration = Duration;
            Campaign.PriceManipulationLimit = PriceManipulationLimit;
            Campaign.TargetSalesCount = TargetSalesCount;
       

            Campaign.CreateTime = DateTime.Now;
            Campaign.UpdateTime = DateTime.Now;
            Campaign.RecordStatus = 1;
            _CampaignDal.Add(Campaign);

         
            return new SuccessResult("Campaign created; name "+ Name + ", product "+ ProductCode + ", duration "+ Duration + ", limit "+PriceManipulationLimit+", target sales count "+ TargetSalesCount);
        }

        public IResult get_campaign_info(string Name)
        {
            Campaign Campaign = _CampaignDal.Get(p => p.Name == Name);

            int totalSalesCount = 0;
            Decimal Turnover = 0;
            Decimal AverageItemPrice = 0;
            if (Campaign != null)
            {
                var orderList = (_OrderDal.GetList(p => p.CampaignId == Campaign.CampaignId).ToList());

                if (orderList != null)
                {
                   
                    for(int i =0; i< orderList.Count;i++)
                    {
                        Turnover += orderList[i].OrderQuantity * orderList[i].OrderPrice;
                        totalSalesCount += orderList[i].OrderQuantity;
                    }

                    AverageItemPrice = orderList.Count >0 ? Turnover / Convert.ToDecimal(totalSalesCount) : 0;
                }

                return new SuccessResult("Campaign " + Campaign.Name + " info; Status " + (Campaign.RecordStatus < 9 ? "Active" : "Passive") + ", Target Sales " + Campaign.TargetSalesCount + ",Total Sales "+ totalSalesCount + ", Turnover "+ Turnover + ", Average Item Price "+ AverageItemPrice);
            }
            else
                return new ErrorResult("Campaign not found! ");
        }


    }
}
