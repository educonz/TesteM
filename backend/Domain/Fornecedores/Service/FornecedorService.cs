using Core.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TesteMeta.Domain;

namespace Domain.Fornecedores.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IRepositoryGeneric _repositoryGeneric;

        public FornecedorService(IRepositoryGeneric repositoryGeneric)
        {
            _repositoryGeneric = repositoryGeneric;
        }

        public Fornecedor BuscarFornecedorPeloUsuario(string userName) =>
            _repositoryGeneric
                .ReadOnlyQuery<Fornecedor>()
                .Include(x => x.Usuario)
                .FirstOrDefault(x => x.Usuario.UserName.Equals(userName));
        
    }
}
