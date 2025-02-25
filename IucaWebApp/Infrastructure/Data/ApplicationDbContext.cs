using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;  

namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<BasketProduct> BasketProducts { get; set; }
    public DbSet<Basket> Baskets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasMany(p => p.BasketProducts)
            .WithOne(bp => bp.Product)
            .HasForeignKey(bp => bp.ProductId);

        builder.Entity<Basket>()
            .HasMany(b => b.BasketProducts)
            .WithOne(bp => bp.Basket)
            .HasForeignKey(bp => bp.BasketId);
    }
}
