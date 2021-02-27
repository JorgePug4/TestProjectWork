using BTP.Test.JBP.BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BTP.Test.JBP.BackEnd.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Students> Student { get; set; }
        public DbSet<StudentAssignments> StudentAssignments { get; set; }
        public DbSet<Assignments> Assignments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"server=DESKTOP-FLO6Q29\SQLEXPRESS;database=TESTENTITY;uid=Admin;password=123456789;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Students>().HasData(
                new Students() { ID=1, Name = "Jorge Bolaños Puga", BirthDate = Convert.ToDateTime("10/07/1995") },
                new Students() { ID = 2, Name = "Pedro Antonio Ramirez Henandez", BirthDate = Convert.ToDateTime("10/07/1996") },
                new Students() { ID = 3, Name = "Arturo Gomez Perez", BirthDate = Convert.ToDateTime("10/07/1997") }
            );

            modelBuilder.Entity<Assignments>().HasData(
                new Assignments() { ID = 1, Name = "Español" },
                new Assignments() { ID = 2, Name = "Matematicas" },
                new Assignments() { ID = 3, Name = "Ingles" }
                );

            modelBuilder.Entity<StudentAssignments>().HasData(
                new StudentAssignments() { ID = 1, IDAssignments = 1, IDStudent = 2 },
                new StudentAssignments() { ID = 2, IDAssignments = 3, IDStudent = 1 },
                new StudentAssignments() { ID = 3, IDAssignments = 2, IDStudent = 3 },
                new StudentAssignments() { ID = 4, IDAssignments = 1, IDStudent = 3 },
                new StudentAssignments() { ID = 5, IDAssignments = 3, IDStudent = 2 },
                new StudentAssignments() { ID = 6, IDAssignments = 2, IDStudent = 1 }
                );


        }
    }
}
