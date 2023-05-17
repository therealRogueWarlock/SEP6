using BestMovies.Models;
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
        modelBuilder.Entity<User>(x =>
        {
            x.HasKey(u => u.Id);
            x.Property(u => u.ShowAdultContent).HasDefaultValue(false);
            x.HasMany<Review>(u => u.Reviews)
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .IsRequired();
            x.HasMany<Favourite>(u => u.Favourites)
                .WithOne()
                .HasForeignKey(f => f.UserId)
                .IsRequired();
            x.HasMany<FanMovie>(u => u.FanMovies)
                .WithOne()
                .HasForeignKey(fm => fm.UserId)
                .IsRequired();
        });
        modelBuilder.Entity<FanMovie>(x =>
        {
            x.HasKey(fm => fm.Id);
            x.HasMany<LinkedEntity>(fm => fm.LinkedEntities)
                .WithOne()
                .HasForeignKey(le => le.ReferenceId)
                .IsRequired();
        });
        modelBuilder.Entity<Favourite>().HasKey(x => x.Id);
        modelBuilder.Entity<Review>().HasKey(x => x.Id);
        modelBuilder.Entity<LinkedEntity>().HasKey(x => x.Id);
    }
}