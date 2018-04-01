using System.Security.Claims;

namespace Domain.Usuarios.Service
{
    public interface IUserContext
    {
        long? ObterIdFornecedorLogado(ClaimsPrincipal fornecedorUser);
    }
}