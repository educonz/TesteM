using Domain.ServicosPrestados.DTO;
using System.Linq;
using TesteMeta.Domain;

namespace Domain.FiltroBuilders
{
    public class ServicoPrestadoFiltroBuilder : IServicoPrestadoFiltroBuilder
    {
        private readonly FiltroServicoPrestadoDto _parametroFiltroRelatorio;
        private IQueryable<ServicoPrestado> _query;

        public ServicoPrestadoFiltroBuilder(IQueryable<ServicoPrestado> query, FiltroServicoPrestadoDto parametroFiltroRelatorio)
        {
            _parametroFiltroRelatorio = parametroFiltroRelatorio;
            _query = query;
        }

        public IServicoPrestadoFiltroBuilder PeriodoDe()
        {
            if (_parametroFiltroRelatorio.DataDe.HasValue)
            {
                _query = _query.Where(servico => servico.DataAtendimento >= _parametroFiltroRelatorio.DataDe.Value);
            }

            return this;
        }

        public IServicoPrestadoFiltroBuilder PeriodoAte()
        {
            if (_parametroFiltroRelatorio.DataAte.HasValue)
            {
                _query = _query.Where(servico => servico.DataAtendimento <= _parametroFiltroRelatorio.DataAte.Value);
            }

            return this;
        }

        public IQueryable<ServicoPrestado> GetQueryable() => _query;

        public IServicoPrestadoFiltroBuilder AplicarTodosFiltros()
        {
            PeriodoDe();
            PeriodoAte();
            Cliente();
            Bairro();
            Cidade();
            Estado();
            ValorMaximo();
            ValorMinimo();
            return this;
        }

        public IServicoPrestadoFiltroBuilder Cliente()
        {
            if (!string.IsNullOrWhiteSpace(_parametroFiltroRelatorio.Cliente))
            {
                _query = _query.Where(servico => servico.Cliente.Nome.Contains(_parametroFiltroRelatorio.Cliente));
            }

            return this;
        }

        public IServicoPrestadoFiltroBuilder Bairro()
        {
            if (!string.IsNullOrWhiteSpace(_parametroFiltroRelatorio.Bairro))
            {
                _query = _query.Where(servico => servico.Cliente.Bairro.Contains(_parametroFiltroRelatorio.Bairro));
            }

            return this;
        }

        public IServicoPrestadoFiltroBuilder Cidade()
        {
            if (!string.IsNullOrWhiteSpace(_parametroFiltroRelatorio.Cidade))
            {
                _query = _query.Where(servico => servico.Cliente.Cidade.Contains(_parametroFiltroRelatorio.Cidade));
            }

            return this;
        }

        public IServicoPrestadoFiltroBuilder Estado()
        {
            if (!string.IsNullOrWhiteSpace(_parametroFiltroRelatorio.Estado))
            {
                _query = _query.Where(servico => servico.Cliente.Estado.Contains(_parametroFiltroRelatorio.Estado));
            }

            return this;
        }

        public IServicoPrestadoFiltroBuilder ValorMinimo()
        {
            if (_parametroFiltroRelatorio.ValorMinimo.HasValue)
            {
                _query = _query.Where(servico => servico.ValorServico >= _parametroFiltroRelatorio.ValorMinimo.Value);
            }

            return this;
        }

        public IServicoPrestadoFiltroBuilder ValorMaximo()
        {
            if (_parametroFiltroRelatorio.ValorMaximo.HasValue)
            {
                _query = _query.Where(servico => servico.ValorServico <= _parametroFiltroRelatorio.ValorMaximo.Value);
            }

            return this;
        }
    }
}