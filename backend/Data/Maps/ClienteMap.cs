using Core.Provider.EntityFramework.ConfigurationsModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteMeta.Domain;

namespace Data.Maps
{
    public class ClienteMap : EntityMappingConfiguration<Cliente>
    {
        public override void Map(EntityTypeBuilder<Cliente> model)
        {
            model
                .HasKey(x => x.Id);

            model
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            model.Property(x => x.Nome);
            model.Property(x => x.Bairro);
            model.Property(x => x.Cidade);
            model.Property(x => x.Estado);
        }
    }
}
