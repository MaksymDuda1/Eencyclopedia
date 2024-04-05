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
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasMany(u => u.FavoriteBooks)
                .WithMany(b => b.Users)
                .UsingEntity<BookUser>(
                    j => j.HasOne(bu => bu.Book)
                        .WithMany(b => b.BooksUsers),
                    j => j.HasOne(bu => bu.User)
                        .WithMany(u => u.BooksUsers),
                    j =>
                    {
                        j.HasKey(bu => new { bu.BookId, bu.UserId });
                        j.ToTable("BookUser");
                    });
        });
            
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.HasOne(b => b.Publisher).WithMany().HasForeignKey(b => b.PublisherId);
            entity.HasOne(b => b.Author).WithMany().HasForeignKey(b => b.AuthorId);
        });
        

        modelBuilder.Entity<User>()
            .HasMany(u => u.FavoriteBooks)
            .WithMany(b => b.Users);
        
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        modelBuilder.Entity<Publisher>()
            .HasMany(p => p.PublishedBooks)
            .WithOne(b => b.Publisher)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}