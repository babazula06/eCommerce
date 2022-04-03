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
    public class ProductManager : IProductService
    {
        private IProductDal _ProductDal;
   

        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
       
        }




       


        public IResult create_product(string ProductCode, Decimal Price, int Stock)
        {
            Product Product = new Product();
            Product.ProductCode = ProductCode;
            Product.PriceActual = Price;
            Product.PriceOrginial = Price;
            Product.Stock = Stock;
        
            Product.CreateTime = DateTime.Now;
            Product.UpdateTime = DateTime.Now;
            Product.RecordStatus = 1;
            _ProductDal.Add(Product);

         
            return new SuccessResult("Product created; code "+ ProductCode + ", price "+ Price.ToString() + ", stock "+ Stock.ToString());
        }

        public IResult get_product_info(string ProductCode)
        {
            Product Product = _ProductDal.Get(p => p.ProductCode == ProductCode && p.RecordStatus < 9);
           

            if(Product != null)
                return new SuccessResult("Product  " + Product.ProductCode + " info; price " + Product.PriceActual.ToString() + ", stock " + Product.Stock.ToString());
            else
                return new ErrorResult("Product not found! ");
        }


    }
}
