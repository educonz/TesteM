using Core.Data;
using Core.Injector;

namespace Data
{
    public class DataBootstrapper : IBootstrapper
    {
        public void Load(IInjector injector)
        {
            injector.AddTransient<IDataContext, Contexto>();
        }
    }
}
