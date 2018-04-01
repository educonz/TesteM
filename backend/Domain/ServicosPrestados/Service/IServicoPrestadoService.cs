using System.Collections.Generic;
using Domain.AutoComplete;
using Domain.Resultados;
using Domain.ServicosPrestados.DTO;

namespace Domain.ServicosPrestados.Service
{
    public interface IServicoPrestadoService
    {
        IEnumerable<RelatorioServicoPrestadoDto> ObterRelatorio(FiltroServicoPrestadoDto parametroFiltroRelatorio);
        IEnumerable<AutoCompleteDto<string>> ObterTiposServico();
        IEnumerable<ResultadoValidacao> ValidarESalvarServicoPrestado(ServicoPrestadoDto servicoPrestadoDto);
    }
}