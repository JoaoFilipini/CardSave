using CardSave.Model;
using Microsoft.EntityFrameworkCore;

namespace CardSave.DBContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<CardEntity> Card { get; set; }
        public DbSet<CardRegisterEntity> CardRegister { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared"); 
    }
}
