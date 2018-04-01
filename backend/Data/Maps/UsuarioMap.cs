using Core.Provider.EntityFramework.ConfigurationsModel;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps
{
    public class UsuarioMap : EntityMappingConfiguration<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> model)
        {
            model
                .HasKey(x => x.Id);

            model
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            model
                .Property(x => x.UserName)
                .IsRequired();

            model
                .Property(x => x.Password)
                .IsRequired();
        }
    }
}
