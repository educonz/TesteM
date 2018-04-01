using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ServicosPrestados.DTO
{
    public class ServicoPrestadoDto
    {
        public string Descricao { get; set; }

        public string DataAtendimento { get; set; }

        public decimal ValorServico { get; set; }

        public int TipoServico { get; set; }

        public long Fornecedor { get; set; }

        public long Cliente { get; set; }
    }
}
