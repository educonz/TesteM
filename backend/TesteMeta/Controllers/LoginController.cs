using Domain.Autenticacoes;
using Domain.Usuarios.DTO;
using Domain.Usuarios.Service;
using Microsoft.AspNetCore.Mvc;

namespace TesteMeta.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult GenerateToken([FromBody] LoginDto loginDto) =>
            Ok(_usuarioService.GetToken(loginDto.Username, loginDto.Password));
    } 
}