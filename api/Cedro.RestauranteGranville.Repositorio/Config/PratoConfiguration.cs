using Cedro.RestauranteGranville.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Cedro.RestauranteGranville.Repositorio.Config
{
    public class PratoConfiguration : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(p => p.Preco)
                .IsRequired();

            builder.HasOne(p => p.Restaurante);
        }
    }
}
