using System.Collections.Generic;
using Domain.Estatisticas.DTO;

namespace Domain.Estatisticas.Service
{
    public interface IEstatisticaService
    {
        IEnumerable<FornecedorSemServicoPrestadoDto> ObterFornecedoresSemServico();
        IEnumerable<MediaFornecedorDto> ObterMediaFornecedor();
        IEnumerable<ClientesMaisGastaramMesDto> ObterTresClientesQueMaisGastaram();
    }
}