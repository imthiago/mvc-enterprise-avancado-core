using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EP.CursoMvc.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public override void Map(EntityTypeBuilder<Cliente> modelBuilder)
        {
            modelBuilder.HasKey(c => c.ClienteId);

            modelBuilder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            modelBuilder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            modelBuilder.Property(c => c.CPF)
                .IsRequired()
                .HasColumnType("varchar(11)")
                .IsFixedLength();

            modelBuilder.Property(c => c.DataNascimento)
                .IsRequired();

            modelBuilder.Property(c => c.Ativo)
                .IsRequired();

            modelBuilder.Ignore(c => c.ValidationResult);

            modelBuilder.ToTable("Clientes");
        }
    }
}