﻿// <auto-generated />
using System;
using FlightsHumano.Infrastructure.DataSource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlightsHumano.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240612142544_MOdifcarTipoCampoIDVueloReserva")]
    partial class MOdifcarTipoCampoIDVueloReserva
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FlightsHumano.Domain.Entities.Destino", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("IdDestino")
                        .HasColumnType("integer");

                    b.Property<string>("NombreDestino")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Destino");
                });

            modelBuilder.Entity("FlightsHumano.Domain.Entities.Origen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("IdOrigen")
                        .HasColumnType("integer");

                    b.Property<string>("NombreOrigen")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Origen");
                });

            modelBuilder.Entity("FlightsHumano.Domain.Entities.Outbox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Enviado")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdReserva")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroAsiento")
                        .HasColumnType("integer");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoOutbox")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Outbox");
                });

            modelBuilder.Entity("FlightsHumano.Domain.Entities.Reserva", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdReserva")
                        .HasColumnType("integer");

                    b.Property<Guid>("IdVuelo")
                        .HasColumnType("uuid");

                    b.Property<string>("MailUsuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroAsiento")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("FlightsHumano.Domain.Entities.Vuelos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FechaLlegada")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdDestino")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdOrigen")
                        .HasColumnType("uuid");

                    b.Property<int>("IdVuelo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Vuelos");
                });
#pragma warning restore 612, 618
        }
    }
}
