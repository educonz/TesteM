using System;

namespace Domain.ServicosPrestados.DTO
{
    public class FiltroServicoPrestadoDto
    {
        public long Fornecedor { get; set; }
        public DateTime? DataDe { get; set; }
        public DateTime? DataAte { get; set; }
        public string Cliente { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
    }
}