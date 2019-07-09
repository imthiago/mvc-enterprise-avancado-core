using System;
using System.IO;
using System.Linq;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Infra.Data.EntityConfig;
using EP.CursoMvc.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EP.CursoMvc.Infra.Data.Context
{
    public class CursoMvcContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Convenções
            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.AddConfiguration(new ClienteConfig());
            modelBuilder.AddConfiguration(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return base.SaveChanges();
        }
    }
}