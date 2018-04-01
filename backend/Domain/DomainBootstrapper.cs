using Core.Injector;
using Domain.Clientes.Service;
using Domain.Estatisticas.Service;
using Domain.FiltroBuilders;
using Domain.Fornecedores.Service;
using Domain.ServicosPrestados.Service;
using Domain.Usuarios.Service;

namespace Domain
{
    public class DomainBootstrapper : IBootstrapper
    {
        public void Load(IInjector injector)
        {
            injector.AddTransient<IUsuarioService, UsuarioService>();
            injector.AddTransient<IClienteService, ClienteService>();
            injector.AddTransient<IServicoPrestadoService, ServicoPrestadoService>(); 
            injector.AddTransient<IFornecedorService, FornecedorService>();
            injector.AddTransient<IUserContext, UserContext>();
            injector.AddTransient<IEstatisticaService, EstatisticaService>();
            injector.AddTransient<IFiltroBuilderFactory, FiltroBuilderFactory>();
        }
    }
}
