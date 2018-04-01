using Core.Provider.EntityFramework.ConfigurationsModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteMeta.Domain;

namespace Data.Maps
{
    public class ServicoPrestadoMap : EntityMappingConfiguration<ServicoPrestado>
    {
        public override void Map(EntityTypeBuilder<ServicoPrestado> model)
        {
            model
                .HasKey(x => x.Id);

            model
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            model.Property(x => x.DescricaoServico);
            model.Property(x => x.DataAtendimento);
            model.Property(x => x.ValorServico);
            model.Property(x => x.TipoServico);

            model
                .HasOne(x => x.Fornecedor)
                .WithMany()
                .HasForeignKey(x => x.IdFornecedor);

            model
                .HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.IdCliente);
        }
    }
}
