using DockerDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetails> ProductDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Primary Keys
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<ProductDetails>()
                .HasKey(pd => pd.ProductDetailId);

            // One Product -> Many ProductDetails
            modelBuilder.Entity<ProductDetails>()
                .HasOne(pd => pd.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(pd => pd.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Column configurations
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<ProductDetails>()
                .Property(pd => pd.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<ProductDetails>()
                .Property(pd => pd.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}