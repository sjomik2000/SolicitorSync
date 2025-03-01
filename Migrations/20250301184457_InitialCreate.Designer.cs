﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using legalcases.EntityModels;

#nullable disable

namespace SolicitorSync.Migrations
{
    [DbContext(typeof(LegalCasesContext))]
    [Migration("20250301184457_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("legalcases.EntityModels.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssignedAttorney")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CaseDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CaseName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CaseStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CaseType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CourtDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Documents")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });
#pragma warning restore 612, 618
        }
    }
}
