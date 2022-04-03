using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using _Business.Abstract;
using _Business.Concrete;
using Castle.DynamicProxy;
using _Core.Utilities.Interceptors;
using _Core.Utilities.Security.Jwt;
using _DataAccess.Abstract;
using _DataAccess.Concrete.EntityFramework;

namespace _Business.Dependencyresolvers.Autofac
{
    public class AutofacBusinnessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<HourManager>().As<IHourService>().SingleInstance();
            builder.RegisterType<EfHourDal>().As<IHourDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<CampaignManager>().As<ICampaignService>().SingleInstance();
            builder.RegisterType<EfCampaignDal>().As<ICampaignDal>().SingleInstance();

            //builder.RegisterType<BookMoveDetailManager>().As<IBookMoveDetailService>().SingleInstance();
            //builder.RegisterType<EfBookMoveDetailDal>().As<IBookMoveDetailDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
