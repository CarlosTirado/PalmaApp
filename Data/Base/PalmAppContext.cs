﻿using Data.Alertas.Mappers;
using Data.Cultivos.Mappers;
using Data.DatosBasicos.Mappers;
using Data.Lotes.Mappers;
using Data.Palmas.Mappers;
using Data.Tareas;
using Data.Tareas.Mappers;
using Domain.Cultivos;
using Domain.DatosBasicos;
using Domain.Lotes;
using Domain.Palmas;
using Domain.Tareas;
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
        public DbSet<Palma> Palmas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TerceroEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CultivoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LoteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PalmaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TareaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlertaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlertaSeguimientoEntityTypeConfiguration());
        }
    }
}