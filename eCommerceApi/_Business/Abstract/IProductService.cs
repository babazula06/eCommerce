using System;
using System.Collections.Generic;
using System.Text;
using _Core.Utilities.Result;
using _Models.Concrete;


namespace _Business.Abstract
{
    public interface IProductService
    {
     
        IResult create_product( string ProductCode, Decimal Price , int Stock );
        IResult get_product_info(string ProductCode);
        


    }

}
