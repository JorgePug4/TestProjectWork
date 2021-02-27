﻿// <auto-generated />
using System;
using BTP.Test.JBP.BackEnd.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BTP.Test.JBP.BackEnd.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BTP.Test.JBP.BackEnd.Entities.Assignments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ID");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Español"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Matematicas"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Ingles"
                        });
                });

            modelBuilder.Entity("BTP.Test.JBP.BackEnd.Entities.StudentAssignments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDAssignments")
                        .HasColumnType("int");

                    b.Property<int>("IDStudent")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDAssignments");

                    b.HasIndex("IDStudent");

                    b.ToTable("StudentAssignments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            IDAssignments = 1,
                            IDStudent = 2
                        },
                        new
                        {
                            ID = 2,
                            IDAssignments = 3,
                            IDStudent = 1
                        },
                        new
                        {
                            ID = 3,
                            IDAssignments = 2,
                            IDStudent = 3
                        },
                        new
                        {
                            ID = 4,
                            IDAssignments = 1,
                            IDStudent = 3
                        },
                        new
                        {
                            ID = 5,
                            IDAssignments = 3,
                            IDStudent = 2
                        },
                        new
                        {
                            ID = 6,
                            IDAssignments = 2,
                            IDStudent = 1
                        });
                });

            modelBuilder.Entity("BTP.Test.JBP.BackEnd.Entities.Students", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ID");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BirthDate = new DateTime(1995, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jorge Bolaños Puga"
                        },
                        new
                        {
                            ID = 2,
                            BirthDate = new DateTime(1996, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pedro Antonio Ramirez Henandez"
                        },
                        new
                        {
                            ID = 3,
                            BirthDate = new DateTime(1997, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Arturo Gomez Perez"
                        });
                });

            modelBuilder.Entity("BTP.Test.JBP.BackEnd.Entities.StudentAssignments", b =>
                {
                    b.HasOne("BTP.Test.JBP.BackEnd.Entities.Assignments", "Assignments")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("IDAssignments")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTP.Test.JBP.BackEnd.Entities.Students", "Students")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("IDStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignments");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("BTP.Test.JBP.BackEnd.Entities.Assignments", b =>
                {
                    b.Navigation("StudentAssignments");
                });

            modelBuilder.Entity("BTP.Test.JBP.BackEnd.Entities.Students", b =>
                {
                    b.Navigation("StudentAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
