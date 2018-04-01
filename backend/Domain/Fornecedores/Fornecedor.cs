using Core.Domain;
using Domain.Usuarios;

namespace TesteMeta.Domain
{
    public class Fornecedor : BaseEntity
    { 
        public string Nome { get; set; }
        public long? IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
