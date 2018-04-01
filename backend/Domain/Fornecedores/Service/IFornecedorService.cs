using TesteMeta.Domain;

namespace Domain.Fornecedores.Service
{
    public interface IFornecedorService
    {
        Fornecedor BuscarFornecedorPeloUsuario(string userName);
    }
}