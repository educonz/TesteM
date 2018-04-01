using Domain.FiltrosBuilders;
using TesteMeta.Domain;

namespace Domain.FiltroBuilders
{
    public interface IServicoPrestadoFiltroBuilder : IFiltroBuilder<ServicoPrestado>
    {
        IServicoPrestadoFiltroBuilder PeriodoDe();
        IServicoPrestadoFiltroBuilder PeriodoAte();
        IServicoPrestadoFiltroBuilder Cliente();
        IServicoPrestadoFiltroBuilder Bairro();
        IServicoPrestadoFiltroBuilder Cidade();
        IServicoPrestadoFiltroBuilder Estado();
        IServicoPrestadoFiltroBuilder ValorMinimo();
        IServicoPrestadoFiltroBuilder ValorMaximo();
        IServicoPrestadoFiltroBuilder AplicarTodosFiltros();
    }
}