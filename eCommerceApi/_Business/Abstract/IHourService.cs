using System;
using System.Collections.Generic;
using System.Text;
using _Core.Utilities.Result;
using _Models.Concrete;

namespace _Business.Abstract
{
    public interface IHourService
    {
        IResult increase_time(int AddHour);
        IResult get_time();

    }

}
