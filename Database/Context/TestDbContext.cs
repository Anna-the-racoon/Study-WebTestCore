using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class TestDbContext : DbContext
    {
        public DbSet<Security> Security { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WS-PC-88\SQLEXPRESS03;Database=TestDb;Trusted_Connection=True;");
        }
    }
}
