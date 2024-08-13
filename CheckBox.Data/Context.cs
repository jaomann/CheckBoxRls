using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Text;

namespace CheckBox.Data
{
    public class Context : DbContext
    {
        private readonly string _connectionString;
        public Context(DbContextOptions options) : base(options) { }
        public Context(DbContextOptions options, string connectionString) : this(options)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseMySql(_connectionString, new MySqlServerVersion(new Version(8,0,11)));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
