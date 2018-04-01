using Core.Provider.EntityFramework.ConfigurationsModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteMeta.Domain;

namespace Data.Maps
{
    public class FornecedorMap : EntityMappingConfiguration<Fornecedor>
    {
        public override void Map(EntityTypeBuilder<Fornecedor> model)
        {
            model
               .HasKey(x => x.Id);

            model
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            model.Property(x => x.Nome);

            model.Property(x => x.IdUsuario);

            model
                .HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);
        }
    }
}
