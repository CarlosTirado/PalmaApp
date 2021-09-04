using Data.Context;
using Domain.Tareas;
using Domain.DatosBasicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Alertas;

namespace Data.Alertas.Mappers
{
    public class AlertaEntityTypeConfiguration : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.ToTable(typeof(Alerta).Name, PalmAppContext.DEFAULT_SCHEMA);
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Cultivo).WithMany().HasForeignKey(x => x.CultivoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Lote).WithMany().HasForeignKey(x => x.LoteId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Palma).WithMany().HasForeignKey(x => x.PalmaId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class AlertaSeguimientoEntityTypeConfiguration : IEntityTypeConfiguration<AlertaSeguimiento>
    {
        public void Configure(EntityTypeBuilder<AlertaSeguimiento> builder)
        {
            builder.ToTable(typeof(AlertaSeguimiento).Name, PalmAppContext.DEFAULT_SCHEMA);
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Alerta).WithMany(t=> t.Seguimiento).HasForeignKey(x => x.AlertaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
} 
