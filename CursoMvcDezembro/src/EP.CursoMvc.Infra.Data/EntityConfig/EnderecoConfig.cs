using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EP.CursoMvc.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> modelBuilder)
        {
            modelBuilder.HasKey(e => e.EnderecoId);

            modelBuilder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(150)");

            modelBuilder.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Property(e => e.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)")
                .IsFixedLength();

            modelBuilder.HasOne(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            modelBuilder.ToTable("Enderecos");
        }
    }
}