using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mttechne.Backend.Junior.Domain.Entidades;

namespace Mttechne.Backend.Junior.Infra.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID_PRODUTO");

            builder.Property(p => p.Nome)
                .HasColumnName("NM_PRODUTO")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Valor)
                .HasColumnName("VL_PRODUTO")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("ATIVO");

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DT_CADASTRO");

            builder.ToTable("TB_PRODUTOS");
        }
    }
}
