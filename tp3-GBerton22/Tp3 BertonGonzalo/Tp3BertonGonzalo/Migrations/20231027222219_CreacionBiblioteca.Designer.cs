﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp3BertonGonzalo;

#nullable disable

namespace Biblioteca.Migrations
{
    [DbContext(typeof(LibrosContext))]
    [Migration("20231027222219_CreacionBiblioteca")]
    partial class CreacionBiblioteca
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tp2Biblioteca.Biblioteca", b =>
                {
                    b.Property<int>("BibliotecaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BibliotecaId"));

                    b.Property<string>("NombreBiblioteca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BibliotecaId");

                    b.ToTable("Bibliotecas");
                });

            modelBuilder.Entity("Tp2Biblioteca.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("EstadoL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Tp2Biblioteca.Libro", b =>
                {
                    b.Property<int>("LibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibroId"));

                    b.Property<int?>("BibliotecaId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibroId");

                    b.HasIndex("BibliotecaId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Tp2Biblioteca.Prestamo", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestamoId"));

                    b.Property<int>("CantidadDias")
                        .HasColumnType("int");

                    b.Property<bool>("Devuelto")
                        .HasColumnType("bit");

                    b.Property<int>("LibroId")
                        .HasColumnType("int");

                    b.Property<string>("NombreSolicitante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrestamoId");

                    b.HasIndex("LibroId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Tp2Biblioteca.Libro", b =>
                {
                    b.HasOne("Tp2Biblioteca.Biblioteca", null)
                        .WithMany("LstLibro")
                        .HasForeignKey("BibliotecaId");

                    b.HasOne("Tp2Biblioteca.Estado", "Estado")
                        .WithMany("LstLibros")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Tp2Biblioteca.Prestamo", b =>
                {
                    b.HasOne("Tp2Biblioteca.Libro", "libro")
                        .WithMany("Prestamos")
                        .HasForeignKey("LibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("libro");
                });

            modelBuilder.Entity("Tp2Biblioteca.Biblioteca", b =>
                {
                    b.Navigation("LstLibro");
                });

            modelBuilder.Entity("Tp2Biblioteca.Estado", b =>
                {
                    b.Navigation("LstLibros");
                });

            modelBuilder.Entity("Tp2Biblioteca.Libro", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
