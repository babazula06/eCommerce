using System;
using System.Collections.Generic;
using System.Text;
using _Core.DataAccess;
using _Models.Concrete;
using _DataAccess.Abstract;
using _DataAccess.Concrete.EntityFramework.Contexts;
using System.Linq;


namespace _DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
      
    }
   
}
