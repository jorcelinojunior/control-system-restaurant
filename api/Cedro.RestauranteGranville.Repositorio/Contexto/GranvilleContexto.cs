using Cedro.RestauranteGranville.Dominio.Entidades;
using Cedro.RestauranteGranville.Repositorio.Config;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Cedro.RestauranteGranville.Repositorio.Contexto
{
    public class GranvilleContexto : DbContext
    {
        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public GranvilleContexto(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new RestauranteConfiguration());
            modelBuilder.ApplyConfiguration(new PratoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
