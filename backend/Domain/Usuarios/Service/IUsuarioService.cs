using Domain.Resultados;

namespace Domain.Usuarios.Service
{
    public interface IUsuarioService
    {
        ResultadoValidacao GetToken(string user, string password);
    }
}
