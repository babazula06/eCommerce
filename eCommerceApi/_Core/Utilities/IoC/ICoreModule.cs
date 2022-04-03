using Microsoft.Extensions.DependencyInjection;

namespace _Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
