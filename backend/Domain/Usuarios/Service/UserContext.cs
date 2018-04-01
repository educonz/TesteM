using Domain.Fornecedores.Service;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Domain.Usuarios.Service
{
    public class UserContext : IUserContext
    {
        private readonly IFornecedorService _fornecedorService;

        public UserContext(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        public long? ObterIdFornecedorLogado(ClaimsPrincipal fornecedorUser)
        {
            if (fornecedorUser == null)
                return default(long?);

            var usuario = (fornecedorUser.Identity as ClaimsIdentity).FindFirst(UsuarioService.USUARIO);
            return usuario?.Value != null ? _fornecedorService.BuscarFornecedorPeloUsuario(usuario.Value)?.Id : default(long?);
        }
    }
}
