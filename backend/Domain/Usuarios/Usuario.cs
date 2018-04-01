using Core.Domain;

namespace Domain.Usuarios
{
    public class Usuario : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    } 
}
