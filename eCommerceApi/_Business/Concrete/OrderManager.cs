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
    public class OrderManager : IOrderService
    {
        private IOrderDal _OrderDal;
        private IProductDal _ProductDal;
        private ICampaignDal _CampaignDal;
        public OrderManager(IOrderDal OrderDal , ICampaignDal CampaignDal, IProductDal ProductDal)
        {
            _OrderDal = OrderDal;
            _CampaignDal = CampaignDal;
            _ProductDal = ProductDal;


        }




       


        public IResult create_order(string ProductCode, int Quantity)
        {
            Order Order = new Order();
            Order.ProductCode = ProductCode;

            Campaign Campaign = _CampaignDal.Get(p => p.ProductCode == ProductCode && p.RecordStatus < 9);
            Product Product = _ProductDal.Get(p => p.ProductCode == ProductCode);

            if (Product == null)
            {
                return new ErrorResult("Product not Found!");
            }


            if (Campaign != null)
            {
                Order.CampaignId = Campaign.CampaignId;
                     
              
            }
            else
            {
                Order.CampaignId = 0;
             
            }
            if(Product.Stock < Quantity)
            {
                return new ErrorResult("Not enough items in stock!");
            }

            Product.Stock = Product.Stock - Quantity;
            _ProductDal.Update(Product);

            Order.OrderPrice = Product.PriceActual;
            Order.OrderQuantity = Quantity;        
            Order.CreateTime = DateTime.Now;          
            Order.RecordStatus = 1;
            _OrderDal.Add(Order);

            int totalSalesCount = 0;
            //Toplam satış hedefine ulaşıp ulaşmadığı kontrolü
            if (Campaign != null)
            {
                var orderList = (_OrderDal.GetList(p => p.ProductCode == ProductCode && p.CampaignId == Campaign.CampaignId).ToList());

                if (orderList != null)
                {
                    for (int i = 0; i < orderList.Count; i++)
                    {
                      
                        totalSalesCount += orderList[i].OrderQuantity;
                    }

                    if (Campaign.TargetSalesCount <= totalSalesCount)
                    {
                        Campaign.RecordStatus = 9; // eğer hedeflenen satış miktarına erişmişse toplam satış kampanya statüsü 9 çekilerek pasif edildi.
                        _CampaignDal.Update(Campaign);

                        Product.PriceActual = Product.PriceOrginial; // kampanya bittiğinde ürünün fiyatını indirimsiz fiyatı ile güncellenmesi
                        _ProductDal.Update(Product);
                    }
                }
            }


            return new SuccessResult("Order created; product "+ ProductCode + ", quantity " + Quantity.ToString());
        }

       


    }
}
