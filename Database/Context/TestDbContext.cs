using Database.Configurations.Securities;
using Database.Models.Securities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
        {

        }
        public TestDbContext(DbContextOptions<TestDbContext> options) 
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        #region Tables
        public DbSet<Security> Security { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WS-PC-88\SQLEXPRESS03;Database=TestDb;Trusted_Connection=True;");

            optionsBuilder.LogTo(Console.WriteLine);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigurationSecurity());
            modelBuilder.ApplyConfiguration(new ConfigurationUser());
        }
}
}
