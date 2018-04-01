using System.Collections.Generic;

namespace Domain.Estatisticas.DTO
{
    public class ClientesMaisGastaramMesDto
    {
        public string Mes { get; set; }
        public IEnumerable<ClientesGastoDto> Clientes { get; set; }
    }
}
