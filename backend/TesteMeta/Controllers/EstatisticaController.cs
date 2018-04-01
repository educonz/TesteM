using Domain.Estatisticas.Service;
using Microsoft.AspNetCore.Mvc;

namespace TesteMeta.Controllers
{
    [Produces("application/json")]
    [Route("api/Estatistica")]
    public class EstatisticaController : Controller
    {
        private readonly IEstatisticaService _estatisticaService;

        public EstatisticaController(IEstatisticaService estatisticaService)
        {
            _estatisticaService = estatisticaService;
        }

        [HttpGet("clientesQueMaisGastaram")]
        public IActionResult ClientesQueMaisGastaram() =>
            Ok(_estatisticaService.ObterTresClientesQueMaisGastaram());

        [HttpGet("mediaFornecedor")]
        public IActionResult MediaFornecedor() =>
            Ok(_estatisticaService.ObterMediaFornecedor());

        [HttpGet("fornecedoresSemServico")]
        public IActionResult FornecedoresSemServico() =>
            Ok(_estatisticaService.ObterFornecedoresSemServico());
    }
}