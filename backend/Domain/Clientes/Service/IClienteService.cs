using System.Collections.Generic;
using Domain.AutoComplete;

namespace Domain.Clientes.Service
{
    public interface IClienteService
    {
        IEnumerable<AutoCompleteDto<long>> ObterClientesCadastrados();
    }
}