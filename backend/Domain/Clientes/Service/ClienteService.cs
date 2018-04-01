using Core.Data.Repository;
using Domain.AutoComplete;
using System.Collections.Generic;
using System.Linq;
using TesteMeta.Domain;

namespace Domain.Clientes.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IRepositoryGeneric _repository;

        public ClienteService(IRepositoryGeneric repository)
        {
            _repository = repository;
        }

        public IEnumerable<AutoCompleteDto<long>> ObterClientesCadastrados() =>
            _repository
            .ReadOnlyQuery<Cliente>()
            .Select(cliente => new AutoCompleteDto<long>
            {
                Label = cliente.Nome,
                Value = cliente.Id,
            });
    }
}
