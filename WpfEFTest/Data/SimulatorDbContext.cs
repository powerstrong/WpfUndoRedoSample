using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEFTest.Models;

namespace WpfEFTest.Data
{
    public class SimulatorDbContext : DbContext
    {
        public DbSet<JointAngle> JointAngles { get; set; }
        public DbSet<PrimitiveObject> PrimitiveObjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=simulatordb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JointAngle>().ToTable("JointAngle");
            modelBuilder.Entity<PrimitiveObject>().ToTable("PrimitiveObject");
        }
    }
}
