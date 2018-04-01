using System.Collections.Generic;

namespace Domain.Estatisticas.DTO
{
    public class FornecedorSemServicoPrestadoDto
    {
        public string Mes { get; set; }
        public IEnumerable<FornecedorDto> Fornecedores { get; set; }
    }
}
