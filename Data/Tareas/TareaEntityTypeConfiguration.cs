using Data.Context;
using Domain.Lotes;
using Domain.DatosBasicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Tareas;

namespace Data.Tareas.Mappers
{
    public class TareaEntityTypeConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.ToTable(typeof(Tarea).Name, PalmAppContext.DEFAULT_SCHEMA);
            builder.HasKey(t => t.Id);
        }
    }
}