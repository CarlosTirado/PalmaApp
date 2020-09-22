using Data.Context;
using Domain.Tareas;
using Domain.DatosBasicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Lotes;

namespace Data.Lotes.Mappers
{
    public class LoteEntityTypeConfiguration : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.ToTable(typeof(Lote).Name, PalmAppContext.DEFAULT_SCHEMA);
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Cultivo).WithMany(x => x.Lotes).HasForeignKey(x => x.CultivoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
} 
