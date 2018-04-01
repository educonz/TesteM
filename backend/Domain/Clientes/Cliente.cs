using Core.Domain;

namespace TesteMeta.Domain
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
