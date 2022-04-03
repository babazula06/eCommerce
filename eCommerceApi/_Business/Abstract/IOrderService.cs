using System;
using System.Collections.Generic;
using System.Text;
using _Core.Utilities.Result;
using _Models.Concrete;


namespace _Business.Abstract
{
    public interface IOrderService
    {
     
        IResult create_order( string ProductCode, int Quantity);
      
        


    }

}
