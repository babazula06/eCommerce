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
    public class HourManager : IHourService
    {
        private IHourDal _HourDal;
        private IProductDal _ProductDal;
        private ICampaignDal _CampaignDal;
        public HourManager(IHourDal HourDal, IProductDal ProductDal, ICampaignDal CampaignDal)
        {
            _HourDal = HourDal;
            _ProductDal = ProductDal;
            _CampaignDal = CampaignDal;
        }

        public IResult increase_time(int AddHour)
        {
            Random rand = new Random();

            Hour Hour = _HourDal.Get(p => p.Id == 1);
            Hour.CurrentHour= Hour.CurrentHour + AddHour;
            Hour.CurrentHour = Hour.CurrentHour > 23 ? Hour.CurrentHour - 24 : Hour.CurrentHour;
            Hour.UpdateTime = DateTime.Now;
            _HourDal.Update(Hour);
           
            //aktif kampanyalar varsa fiyatların düşürülmesi için tetiklenmesi
            var campaignList = (_CampaignDal.GetList(p => p.RecordStatus<9).ToList());
            if (campaignList != null)
            {
                for (int i = 0; i < campaignList.Count; i++)
                {
                    if (campaignList[i].Duration >= Hour.CurrentHour)
                    {
                        Product Product = _ProductDal.Get(p => p.ProductCode == campaignList[i].ProductCode);
                        if (Product != null)
                        {
                            // aktif kampanyalar için rastgele olarak ürün fiyatlarını artırma ve azaltma yapılıyor.
                            Product.PriceActual = rand.Next(0, 2) == 0 ? (Product.PriceActual * ((100 - campaignList[i].PriceManipulationLimit) / 100)) : (Product.PriceActual * ((100 + campaignList[i].PriceManipulationLimit) / 100));
                            _ProductDal.Update(Product);
                        }
                    }
                    else
                    {
                        Campaign Campaign = _CampaignDal.Get(p => p.CampaignId == campaignList[i].CampaignId);
                        Campaign.RecordStatus = 9;
                        _CampaignDal.Update(Campaign);

                        Product Product = _ProductDal.Get(p => p.ProductCode == campaignList[i].ProductCode);
                        if (Product != null)
                        {
                            // aktif kampanyaların süresi dolduğu için indirimli fiyat kaldırıldı.
                            Product.PriceActual = Product.PriceOrginial;
                            _ProductDal.Update(Product);
                        }

                    }

                }

            }
            else
            {
                //aktifte kampanya yoksa ve ürünlerin indirimli fiyatları değişmeyen kaldıysa o kayıtların düzetilmesi.
                var productList = (_ProductDal.GetList(p => p.PriceActual != p.PriceOrginial).ToList());

                if (productList != null)
                {
                    for (int i = 0; i < productList.Count; i++)
                    {
                        Product Product = _ProductDal.Get(p => p.ProductCode == productList[i].ProductCode);
                        Product.PriceActual = Product.PriceOrginial;
                        _ProductDal.Update(Product);
                    }
                 }
            }

            return new SuccessResult("Time is "+ Hour.CurrentHour.ToString().PadLeft(2, '0')  + ":00");
        }

        public IResult get_time()
        {
            Random rand = new Random();

            Hour Hour = _HourDal.Get(p => p.Id == 1);           

            return new SuccessResult("Time is " + Hour.CurrentHour.ToString().PadLeft(2, '0') + ":00");
        }




    }
}
