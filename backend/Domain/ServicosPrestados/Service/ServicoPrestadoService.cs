using Core.Data.Repository;
using Domain.AutoComplete;
using Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.FiltroBuilders;
using TesteMeta.Domain;
using Domain.Resultados;
using Domain.ServicosPrestados.DTO;
using Microsoft.EntityFrameworkCore;

namespace Domain.ServicosPrestados.Service
{
    public class ServicoPrestadoService : IServicoPrestadoService
    {
        private readonly IRepositoryGeneric _repository;
        private readonly IFiltroBuilderFactory _filtroBuilderFactory;

        public ServicoPrestadoService(IRepositoryGeneric repository,
            IFiltroBuilderFactory filtroBuilderFactory)
        {
            _repository = repository;
            _filtroBuilderFactory = filtroBuilderFactory;
        }

        public IEnumerable<AutoCompleteDto<string>> ObterTiposServico()
        {
            foreach (var tipoServico in Enum.GetValues(typeof(TipoServico)).Cast<TipoServico>())
            {
                yield return new AutoCompleteDto<string>
                {
                    Value = ((int)tipoServico).ToString(),
                    Label = tipoServico.GetDescription()
                };
            }
        }

        public IEnumerable<ResultadoValidacao> ValidarESalvarServicoPrestado(ServicoPrestadoDto servicoPrestadoDto)
        {
            if (string.IsNullOrEmpty(servicoPrestadoDto.Descricao))
            {
                yield return new ResultadoValidacao("Descrição não informada.");
                yield break;
            }

            if (string.IsNullOrEmpty(servicoPrestadoDto.DataAtendimento))
            {
                yield return new ResultadoValidacao("Data não informada.");
                yield break;
            }

            if (servicoPrestadoDto.ValorServico < 0)
            {
                yield return new ResultadoValidacao("Valor informado é inválido.");
                yield break;
            }

            SalvarServicoPrestado(servicoPrestadoDto);
        }

        private void SalvarServicoPrestado(ServicoPrestadoDto servicoPrestadoDto)
        {
            var servicoPrestado = new ServicoPrestado
            {
                DataAtendimento = Convert.ToDateTime(servicoPrestadoDto.DataAtendimento),
                DescricaoServico = servicoPrestadoDto.Descricao,
                ValorServico = servicoPrestadoDto.ValorServico,
                IdCliente = servicoPrestadoDto.Cliente,
                TipoServico = (TipoServico)Enum.ToObject(typeof(TipoServico), servicoPrestadoDto.TipoServico),
                IdFornecedor = servicoPrestadoDto.Fornecedor,
            };

            _repository.Add(servicoPrestado);
            _repository.Commit();
        }

        public IEnumerable<RelatorioServicoPrestadoDto> ObterRelatorio(FiltroServicoPrestadoDto parametroFiltroRelatorio)
        {
            var queryServicoPrestado = _repository
               .ReadOnlyQuery<ServicoPrestado>()
               .Include(x => x.Fornecedor)
               .Include(x => x.Cliente)
               .Where(servico => servico.IdFornecedor == parametroFiltroRelatorio.Fornecedor);

            return _filtroBuilderFactory
                    .CriarServicoPrestadoFiltroBuilder(queryServicoPrestado, parametroFiltroRelatorio)
                    .AplicarTodosFiltros()
                    .GetQueryable()
                    .AsEnumerable()
                    .Select(servico => new RelatorioServicoPrestadoDto
                    {
                        Bairro = servico.Cliente.Bairro,
                        Cliente = $"{servico.IdCliente} - {servico.Cliente.Nome}",
                        Cidade = servico.Cliente.Cidade,
                        Estado = servico.Cliente.Estado,
                        TipoServico = $"{(int)servico.TipoServico} - {servico.TipoServico.GetDescription()}",
                        DataAtendimento = servico.DataAtendimento.ToString("dd/MM/yyyy"),
                        Valor = $"R$ {string.Format("{0:0.00}", servico.ValorServico)}"
                    });
        }
    }
}
