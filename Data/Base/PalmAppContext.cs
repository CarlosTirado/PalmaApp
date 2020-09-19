using Data.Cultivos.Mappers;
using Data.DatosBasicos.Mappers;
using Data.Lotes.Mappers;
using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Lotes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class PalmAppContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "PalmApp";

        public PalmAppContext(DbContextOptions<PalmAppContext> options)
              : base(options) { }

        public DbSet<Tercero> Terceros { get; set; }
        public DbSet<Cultivo> Cultivos { get; set; }
        public DbSet<Lote> Lotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TerceroEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CultivoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LoteEntityTypeConfiguration());
        }
    }
}