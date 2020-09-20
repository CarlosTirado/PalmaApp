using Data.Context;
using Domain.Cultivos;
using Domain.DatosBasicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Cultivos.Mappers
{
    public class CultivoEntityTypeConfiguration : IEntityTypeConfiguration<Cultivo>
    {
        public void Configure(EntityTypeBuilder<Cultivo> builder)
        {
            builder.ToTable(typeof(Cultivo).Name, PalmAppContext.DEFAULT_SCHEMA);
            builder.HasKey(t => t.Id);

            builder.HasMany(x => x.Lotes).WithOne(t=> t.Cultivo).HasForeignKey(x => x.CultivoId).OnDelete(DeleteBehavior.Restrict);
            builder.Metadata.FindNavigation(nameof(Cultivo.Lotes)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
