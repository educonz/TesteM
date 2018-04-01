using Domain.ServicosPrestados.DTO;
using System.Linq;
using TesteMeta.Domain;

namespace Domain.FiltroBuilders
{
    public class FiltroBuilderFactory : IFiltroBuilderFactory
    {
        public IServicoPrestadoFiltroBuilder CriarServicoPrestadoFiltroBuilder(IQueryable<ServicoPrestado> query, FiltroServicoPrestadoDto parametroFiltroRelatorio) =>
            new ServicoPrestadoFiltroBuilder(query, parametroFiltroRelatorio);
    }
}