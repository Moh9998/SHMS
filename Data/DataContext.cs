using Microsoft.EntityFrameworkCore;
using SHMS.Models;
using System.Collections.Generic;

namespace SHMS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users
        {
            get; set;
        }
        public DbSet<TestResult> TestResults
        {
            get; set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=patientMonitoring.db");
            }
        }
    }
}
