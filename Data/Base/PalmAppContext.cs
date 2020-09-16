using Data.DatosBasicos.Mappers;
using Domain.Cultivos;
using Domain.DatosBasicos;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TerceroEntityTypeConfiguration());
        }
    }
}