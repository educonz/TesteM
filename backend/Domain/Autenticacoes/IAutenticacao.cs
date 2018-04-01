using System.Collections.Generic;
using System.Security.Claims;

namespace Domain.Autenticacoes
{
    public interface IAutenticacao
    {
        string GenerateToken(IEnumerable<Claim> claims);
        (bool IsValid, ClaimsPrincipal Usuario) ValidateToken(string token);
    }
}
