using Core.Data.Repository;
using Domain.Autenticacoes;
using Domain.Resultados;
using System.Linq;
using System.Security.Claims;

namespace Domain.Usuarios.Service
{
    public class UsuarioService : IUsuarioService
    {
        public const string USUARIO = "USUARIO";
        private readonly IAutenticacao _autenticacao;
        private readonly IRepositoryGeneric _repositoryGeneric;

        public UsuarioService(IAutenticacao autenticacao,
            IRepositoryGeneric repositoryGeneric)
        {
            _autenticacao = autenticacao;
            _repositoryGeneric = repositoryGeneric;
        }

        public ResultadoValidacao GetToken(string user, string password)
        {
            var usuario = _repositoryGeneric
                .ReadOnlyQuery<Usuario>()
                .FirstOrDefault(x => x.UserName.Equals(user) && x.Password.Equals(password));

            if (usuario == default(Usuario))
            {
                return ResultadoValidacao.CriarErro("Usuário ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(USUARIO, usuario.UserName)
            };

            return ResultadoValidacao.CriarSucesso(_autenticacao.GenerateToken(claims));
        }
    }
}
