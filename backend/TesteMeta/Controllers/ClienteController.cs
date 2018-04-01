using Domain.Clientes.Service;
using Microsoft.AspNetCore.Mvc;

namespace TesteMeta.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Get() =>
             Ok(_clienteService.ObterClientesCadastrados());
    }
}