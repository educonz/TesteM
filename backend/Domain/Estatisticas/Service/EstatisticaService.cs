using Core.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using TesteMeta.Domain;
using System.Linq;
using Domain.Estatisticas.DTO;
using System.Globalization;
using Domain.Extensions;

namespace Domain.Estatisticas.Service
{
    public class EstatisticaService : IEstatisticaService
    {
        private readonly IRepositoryGeneric _repository;

        public EstatisticaService(IRepositoryGeneric repository)
        {
            _repository = repository;
        }

        public IEnumerable<ClientesMaisGastaramMesDto> ObterTresClientesQueMaisGastaram() =>
             (from servicoPrestado in _repository.ReadOnlyQuery<ServicoPrestado>()
              join cliente in _repository.ReadOnlyQuery<Cliente>() on servicoPrestado.IdCliente equals cliente.Id
              where servicoPrestado.DataAtendimento.Year == DateTime.Now.Year
              group servicoPrestado by new { servicoPrestado.DataAtendimento.Month, servicoPrestado.IdCliente, cliente.Nome }
             into servicoPrestadoAgrupado
              select new
              {
                  servicoPrestadoAgrupado.Key.IdCliente,
                  Cliente = servicoPrestadoAgrupado.Key.Nome,
                  Mes = servicoPrestadoAgrupado.Key.Month,
                  Total = servicoPrestadoAgrupado.Sum(servico => servico.ValorServico)
              }
             into totalClientesAgrupadoPorMes
              group totalClientesAgrupadoPorMes by totalClientesAgrupadoPorMes.Mes
             into clientesAgrupadoPorMes
              select clientesAgrupadoPorMes)
            .AsEnumerable()
            .Select(clientesAgrupadoPorMes => new ClientesMaisGastaramMesDto
            {
                Mes = ObterMesDescritivo(clientesAgrupadoPorMes.Key),
                Clientes = clientesAgrupadoPorMes
                 .OrderByDescending(x => x.Total)
                 .Take(3)
                 .Select(x => new ClientesGastoDto
                 {
                     IdCliente = x.IdCliente,
                     NomeCliente = x.Cliente,
                     ValorTotal = $"R$ {string.Format("{0:0.00}", x.Total)}"
                 })
            });

        private string ObterMesDescritivo(int mes)
        {
            return new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(mes);
        }

        public IEnumerable<MediaFornecedorDto> ObterMediaFornecedor() =>
            (from servicoPrestado in _repository.ReadOnlyQuery<ServicoPrestado>()
             join fornecedor in _repository.ReadOnlyQuery<Fornecedor>() on servicoPrestado.IdFornecedor equals fornecedor.Id
             group servicoPrestado by new { servicoPrestado.IdFornecedor, fornecedor.Nome, servicoPrestado.TipoServico }
            into servicosAgrupadosPorFornecedor
             select new
             {
                 servicosAgrupadosPorFornecedor.Key.IdFornecedor,
                 Fornecedor = servicosAgrupadosPorFornecedor.Key.Nome,
                 servicosAgrupadosPorFornecedor.Key.TipoServico,
                 Media = servicosAgrupadosPorFornecedor.Average(x => x.ValorServico)
             }
            into servicosAgrupados
             group servicosAgrupados by new { servicosAgrupados.IdFornecedor, servicosAgrupados.Fornecedor }
            into fornecedorAgrupado
             select fornecedorAgrupado)
            .AsEnumerable()
            .Select(fornecedorAgrupado => new MediaFornecedorDto
            {
                IdFornecedor = fornecedorAgrupado.Key.IdFornecedor,
                Fornecedor = fornecedorAgrupado.Key.Fornecedor,
                MediaServico = fornecedorAgrupado.Select(x =>
                new ValorServicoDto
                {
                    Servico = x.TipoServico.GetDescription(),
                    Media = $"R$ {string.Format("{0:0.00}", x.Media)}"
                })
            });

        public IEnumerable<FornecedorSemServicoPrestadoDto> ObterFornecedoresSemServico()
        {
            var queryAgrupaaServicoPorMes = (from servicoPrestado in _repository.ReadOnlyQuery<ServicoPrestado>()
                                             group servicoPrestado by servicoPrestado.DataAtendimento.Month
                          into agrupadoServicoPorMes
                                             select agrupadoServicoPorMes);

            var fornecedores = _repository.ReadOnlyQuery<Fornecedor>().AsEnumerable();

            foreach (var agrupadoServicoPorMes in queryAgrupaaServicoPorMes)
            {
                var fornecedoresQueTemServico = agrupadoServicoPorMes.Select(y => y.IdFornecedor).ToList();

                yield return new FornecedorSemServicoPrestadoDto
                {
                    Mes = ObterMesDescritivo(agrupadoServicoPorMes.Key),
                    Fornecedores = fornecedores
                                    .Where(x => !fornecedoresQueTemServico.Contains(x.Id))
                                    .Select(x =>
                                    new FornecedorDto
                                    {
                                        Nome = x.Nome,
                                        IdFornecedor = x.Id,
                                    })
                                    .AsEnumerable()

                };
            }
        }
    }
}
