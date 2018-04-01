using Core;
using Core.Configuration;
using Core.Injector;
using Data;
using Domain;
using Domain.Autenticacoes;
using TesteMeta.Providers;

namespace TesteMeta
{
    public class TesteMetaBootstrapper : IBootstrapper
    {
        public void Load(IInjector injector)
        {
            new CoreBootstrapper().Load(injector);
            new DataBootstrapper().Load(injector);
            new DomainBootstrapper().Load(injector);

            injector.AddSingleton<IAppConfiguration, ApplicationConfiguration>();
            injector.AddTransient<IAutenticacao, AutenticacaoJwt>();
        }
    }
}
