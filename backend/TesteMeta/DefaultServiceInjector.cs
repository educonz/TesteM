using Core.Injector;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TesteMeta
{
    public class DefaultServiceInjector : IInjector
    {
        public static IInjector CurrentInjector { get; set; }

        protected readonly IServiceCollection ServiceCollection;

        public DefaultServiceInjector(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }

        public virtual void AddScoped<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            ServiceCollection.AddScoped<TService, TImplementation>();
        }

        public virtual void AddSingleton<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            ServiceCollection.AddSingleton<TService, TImplementation>();
        }

        public virtual void AddTransient<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            ServiceCollection.AddTransient<TService, TImplementation>();
        }

        public virtual TImplementation Resolve<TImplementation>() where TImplementation : class
        {
            var serviceProvider = ServiceCollection.BuildServiceProvider();
            return serviceProvider.GetService<TImplementation>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
