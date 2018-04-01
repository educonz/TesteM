using System.Collections.Generic;

namespace Domain.Estatisticas.DTO
{
    public class MediaFornecedorDto
    {
        public long IdFornecedor { get; set; }
        public string Fornecedor { get; set; }
        public IEnumerable<ValorServicoDto> MediaServico { get; set; }
    }
}
