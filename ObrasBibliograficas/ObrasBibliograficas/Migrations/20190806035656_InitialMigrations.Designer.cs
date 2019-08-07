﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObrasBibliograficas.Data;

namespace ObrasBibliograficas.Migrations
{
    [DbContext(typeof(ObraBibliograficaDbContext))]
    [Migration("20190806035656_InitialMigrations")]
    partial class InitialMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("ObrasBibliograficas.Model.Autor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeCompleto");

                    b.HasKey("id");

                    b.ToTable("Autor");
                });
#pragma warning restore 612, 618
        }
    }
}
