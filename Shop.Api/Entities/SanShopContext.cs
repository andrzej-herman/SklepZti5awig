using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Api.Entities
{
    public partial class SanShopContext : DbContext
    {
        public SanShopContext()
        {
        }

        public SanShopContext(DbContextOptions<SanShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<DeliveryOption> DeliveryOptions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShopUser> ShopUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Polish_CI_AI");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductDateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.ShopUser)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ShopUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ShopUser");

                entity.HasMany(d => d.DeliveryOptions)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductDeliveryOption",
                        l => l.HasOne<DeliveryOption>().WithMany().HasForeignKey("DeliveryOptionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductDeliveryOption_DeliveryOption"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductDeliveryOption_Product"),
                        j =>
                        {
                            j.HasKey("ProductId", "DeliveryOptionId");

                            j.ToTable("ProductDeliveryOption");

                            j.IndexerProperty<string>("ProductId").HasMaxLength(200);

                            j.IndexerProperty<string>("DeliveryOptionId").HasMaxLength(200);
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
