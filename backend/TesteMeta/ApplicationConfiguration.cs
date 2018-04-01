using Core.Configuration;
using Microsoft.Extensions.Configuration;

namespace TesteMeta
{
    public class ApplicationConfiguration : IAppConfiguration
    {
        public IConfigurationRoot Configuration => AppConfiguration.Configuration;
        public IConfigurationRoot Configure() => AppConfiguration.Configure();
    }
}
