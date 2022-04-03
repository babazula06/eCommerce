using _Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using _Core.CrossCuttingConcerns.Caching;

using _Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace _Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
