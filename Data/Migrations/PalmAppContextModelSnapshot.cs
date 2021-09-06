﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(PalmAppContext))]
    partial class PalmAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Alertas.Alerta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Adjunto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Asunto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CultivoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LoteId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PalmaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CultivoId");

                    b.HasIndex("LoteId");

                    b.HasIndex("PalmaId");

                    b.ToTable("Alerta","PalmApp");
                });

            modelBuilder.Entity("Domain.Alertas.AlertaSeguimiento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Adjunto")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("AlertaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlertaId");

                    b.ToTable("AlertaSeguimiento","PalmApp");
                });

            modelBuilder.Entity("Domain.Cultivos.Cultivo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaSiembra")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cultivo","PalmApp");
                });

            modelBuilder.Entity("Domain.DatosBasicos.Tercero", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tercero","PalmApp");
                });

            modelBuilder.Entity("Domain.Lotes.Lote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CultivoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NumeroHectareas")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CultivoId");

                    b.ToTable("Lote","PalmApp");
                });

            modelBuilder.Entity("Domain.Palmas.Palma", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Consecutivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaSiembra")
                        .HasColumnType("datetime2");

                    b.Property<long>("LoteId")
                        .HasColumnType("bigint");

                    b.Property<long?>("LoteId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LoteId");

                    b.HasIndex("LoteId1");

                    b.ToTable("Palma","PalmApp");
                });

            modelBuilder.Entity("Domain.Tareas.Tarea", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tarea","PalmApp");
                });

            modelBuilder.Entity("Domain.Alertas.Alerta", b =>
                {
                    b.HasOne("Domain.Cultivos.Cultivo", "Cultivo")
                        .WithMany()
                        .HasForeignKey("CultivoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Lotes.Lote", "Lote")
                        .WithMany()
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Palmas.Palma", "Palma")
                        .WithMany()
                        .HasForeignKey("PalmaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Alertas.AlertaSeguimiento", b =>
                {
                    b.HasOne("Domain.Alertas.Alerta", "Alerta")
                        .WithMany("Seguimiento")
                        .HasForeignKey("AlertaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Lotes.Lote", b =>
                {
                    b.HasOne("Domain.Cultivos.Cultivo", "Cultivo")
                        .WithMany("Lotes")
                        .HasForeignKey("CultivoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Palmas.Palma", b =>
                {
                    b.HasOne("Domain.Lotes.Lote", "Lote")
                        .WithMany("Palmas")
                        .HasForeignKey("LoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Lotes.Lote", null)
                        .WithMany("Palmas2")
                        .HasForeignKey("LoteId1");
                });
#pragma warning restore 612, 618
        }
    }
}
