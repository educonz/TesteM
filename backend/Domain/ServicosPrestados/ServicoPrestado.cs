using Core.Domain;
using System;

namespace TesteMeta.Domain
{
    public class ServicoPrestado : BaseEntity
    {
        public string DescricaoServico { get; set; }
        public DateTime DataAtendimento { get; set; }
        public decimal ValorServico { get; set; }
        public TipoServico TipoServico { get; set; }
        public long IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public long IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
