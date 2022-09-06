﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehiculosTransporte.App.Persistencia;

namespace VehiculosTransporte.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero_Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Verificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MecanicoId")
                        .HasColumnType("int");

                    b.Property<string>("Nivel_Aceite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel_Liquido_direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel_Liquido_frenos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel_Refrigerante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vehiculo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MecanicoId");

                    b.ToTable("Verificaciones");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Auxiliar", b =>
                {
                    b.HasBaseType("VehiculosTransporte.App.Dominio.Persona");

                    b.HasDiscriminator().HasValue("Auxiliar");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Mecanico", b =>
                {
                    b.HasBaseType("VehiculosTransporte.App.Dominio.Persona");

                    b.HasDiscriminator().HasValue("Mecanico");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Verificacion", b =>
                {
                    b.HasOne("VehiculosTransporte.App.Dominio.Mecanico", "Mecanico")
                        .WithMany()
                        .HasForeignKey("MecanicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mecanico");
                });
#pragma warning restore 612, 618
        }
    }
}
