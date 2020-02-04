using Cedro.RestauranteGranville.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Cedro.RestauranteGranville.Repositorio.Config
{
    public class RestauranteConfiguration : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .Property(r => r.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(r => r.Pratos)
                .WithOne(prato => prato.Restaurante);
        }
    }
}
