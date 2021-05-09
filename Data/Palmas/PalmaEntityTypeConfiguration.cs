using Data.Context;
using Domain.Tareas;
using Domain.DatosBasicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Palmas;

namespace Data.Palmas.Mappers
{
    public class PalmaEntityTypeConfiguration : IEntityTypeConfiguration<Palma>
    {
        public void Configure(EntityTypeBuilder<Palma> builder)
        {
            builder.ToTable(typeof(Palma).Name, PalmAppContext.DEFAULT_SCHEMA);
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Lote).WithMany(x => x.Palmas).HasForeignKey(x => x.LoteId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Lote2).WithMany(x => x.Palmas2).HasForeignKey(x => x.Lote2Id).OnDelete(DeleteBehavior.Restrict);
        }
    }
} 
