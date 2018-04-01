using Domain.ServicosPrestados.DTO;
using Domain.ServicosPrestados.Service;
using Domain.Usuarios.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TesteMeta.Controllers
{
    [Produces("application/json")]
    [Route("api/ServicoPrestado")]
    public class ServicoPrestadoController : Controller
    {
        private readonly IServicoPrestadoService _servicoPrestadoService;
        private readonly IUserContext _userContext;

        public ServicoPrestadoController(IServicoPrestadoService servicoPrestadoService,
           IUserContext userContext)
        {
            _servicoPrestadoService = servicoPrestadoService;
            _userContext = userContext;
        }

        [HttpGet("tiposServicos")]
        public IActionResult TiposServico() =>
             Ok(_servicoPrestadoService.ObterTiposServico());

        [HttpPost]
        public IActionResult Post([FromBody] ServicoPrestadoDto servicoPrestadoDto)
        {
            var idFornecedor = _userContext.ObterIdFornecedorLogado(HttpContext.User);
            if (!idFornecedor.HasValue || idFornecedor == default(long))
                return StatusCode(StatusCodes.Status405MethodNotAllowed, "Usuário não encontrado ou não é fornecedor!");

            servicoPrestadoDto.Fornecedor = idFornecedor.Value;

            var validacoes = _servicoPrestadoService.ValidarESalvarServicoPrestado(servicoPrestadoDto);
            if (validacoes.Any())
            {
                return BadRequest(validacoes);
            }

            return Ok();
        }

        [HttpGet("relatorio")]
        public IActionResult Relatorio([FromQuery] FiltroServicoPrestadoDto filtroServicoPrestadoDto)
        {
            var idFornecedor = _userContext.ObterIdFornecedorLogado(HttpContext.User);
            if (!idFornecedor.HasValue || idFornecedor == default(long))
                return StatusCode(StatusCodes.Status405MethodNotAllowed, "Usuário não encontrado ou não é fornecedor!");

            filtroServicoPrestadoDto.Fornecedor = idFornecedor.Value;
            return Ok(_servicoPrestadoService.ObterRelatorio(filtroServicoPrestadoDto));
        }
    }
}