using Microsoft.EntityFrameworkCore;

namespace BestMovies.Data;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=tcp:246299.database.windows.net,1433;Initial Catalog=BestMovies;Persist Security Info=False;User ID=master;Password=Fred1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestModel>().HasKey(x => x.Id);
    }
}