using Eencyclopedia.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eencyclopedia.Infrastructure.Data;

public class EencyclopediaDbContext : IdentityDbContext<User, Role, Guid>
{
    public EencyclopediaDbContext(DbContextOptions<EencyclopediaDbContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>()
            .HasData(
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    NormalizedName = "USER"
                },
                new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
    }
}