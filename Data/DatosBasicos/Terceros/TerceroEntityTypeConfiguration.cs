using Data.Context;
using Domain.DatosBasicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DatosBasicos.Mappers
{
    public class TerceroEntityTypeConfiguration : IEntityTypeConfiguration<Tercero>
    {
        public void Configure(EntityTypeBuilder<Tercero> builder)
        {
            builder.ToTable(typeof(Tercero).Name, PalmAppContext.DEFAULT_SCHEMA);
            builder.HasKey(t => t.Id);
        }
    }
}
