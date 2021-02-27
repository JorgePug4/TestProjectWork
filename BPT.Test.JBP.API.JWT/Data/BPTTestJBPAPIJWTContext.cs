using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BPT.Test.JBP.API.JWT.Entities;

namespace BPT.Test.JBP.API.JWT.Data
{
    public class BPTTestJBPAPIJWTContext : DbContext
    {
        public BPTTestJBPAPIJWTContext(DbContextOptions<BPTTestJBPAPIJWTContext> options)
            : base(options)
        {
        }

        public DbSet<BPT.Test.JBP.API.JWT.Entities.LoginJWT> LoginJWT { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoginJWT>().HasData(
                new LoginJWT() { Username = "Jorge", Password = "PASSWORDJWT" }
            );

        }
    }
}
