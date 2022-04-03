using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using _Core.EntityFramework;
using _DataAccess.Abstract;
using _DataAccess.Concrete.EntityFramework.Contexts;
using _Models.Concrete;

namespace _DataAccess.Concrete.EntityFramework
{
    public class EfCampaignDal : EfEntityRepositoryBase<Campaign, DeposContext>, ICampaignDal
    {
    }
}
