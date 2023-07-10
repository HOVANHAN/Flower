using HFlower.Areas.Identity.Data;
using HFlower.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HFlower.Areas.Identity.Data;

public class HFlowerContext : IdentityDbContext<HFlowerUser>
{
    public HFlowerContext(DbContextOptions<HFlowerContext> options)
        : base(options)
    {
    }

    public DbSet<HFlower.Models.Flower> Flower { get; set; } = default!;

    public DbSet<HFlower.Models.Category>? Category { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Order>()
           .HasMany(o => o.OrderDetails)
           .WithOne(od => od.Order)
           .HasForeignKey(od => od.OrderId);

        builder.Entity<OrderDetail>()
            .HasOne(od => od.Flower)
            .WithMany()
            .HasForeignKey(od => od.FlowerId);

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new HFlowerUserEntityConfiguration());
    }
}

public class HFlowerUserEntityConfiguration : IEntityTypeConfiguration<HFlowerUser>
{
    public void Configure(EntityTypeBuilder<HFlowerUser> builder)
    {
        builder.Property(u=>u.Name).HasMaxLength(256);
    }
}