using Domain.ServicosPrestados.DTO;
using System.Linq;
using TesteMeta.Domain;

namespace Domain.FiltroBuilders
{
    public interface IFiltroBuilderFactory
    {
        IServicoPrestadoFiltroBuilder CriarServicoPrestadoFiltroBuilder(IQueryable<ServicoPrestado> query, FiltroServicoPrestadoDto parametroFiltroRelatorio);
    }
}