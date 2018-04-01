using System.Linq;

namespace Domain.FiltrosBuilders
{
    public interface IFiltroBuilder<TEntity>
    {
        IQueryable<TEntity> GetQueryable();
    }
}
