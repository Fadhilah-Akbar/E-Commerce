using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerce_API.Models
{
    public partial class DB_Market_PlaceContext : DbContext
    {
        public DB_Market_PlaceContext()
        {
        }

        public DB_Market_PlaceContext(DbContextOptions<DB_Market_PlaceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MBiodataAddress> MBiodataAddresses { get; set; } = null!;
        public virtual DbSet<MBiodatum> MBiodata { get; set; } = null!;
        public virtual DbSet<MCategory> MCategories { get; set; } = null!;
        public virtual DbSet<MMerchant> MMerchants { get; set; } = null!;
        public virtual DbSet<MProduct> MProducts { get; set; } = null!;
        public virtual DbSet<MRole> MRoles { get; set; } = null!;
        public virtual DbSet<MShippingMethod> MShippingMethods { get; set; } = null!;
        public virtual DbSet<MToken> MTokens { get; set; } = null!;
        public virtual DbSet<MUser> MUsers { get; set; } = null!;
        public virtual DbSet<TCart> TCarts { get; set; } = null!;
        public virtual DbSet<TOrder> TOrders { get; set; } = null!;
        public virtual DbSet<TOrderItem> TOrderItems { get; set; } = null!;
        public virtual DbSet<TPayment> TPayments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=DB_Market_Place;user id=sa;Password=P@ssw0rd; Command Timeout=300");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MBiodataAddress>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Biodata)
                    .WithMany(p => p.MBiodataAddresses)
                    .HasForeignKey(d => d.BiodataId)
                    .HasConstraintName("FK__m_biodata__bioda__4D94879B");
            });

            modelBuilder.Entity<MBiodatum>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MBiodata)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__m_biodata__user___48CFD27E");
            });

            modelBuilder.Entity<MCategory>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MMerchant>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MMerchants)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__m_merchan__user___52593CB8");
            });

            modelBuilder.Entity<MProduct>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Stock).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__m_product__categ__5CD6CB2B");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MProducts)
                    .HasForeignKey(d => d.MerchantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__m_product__merch__5BE2A6F2");
            });

            modelBuilder.Entity<MRole>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MShippingMethod>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MToken>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsExpired).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MUser>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.MUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__m_users__role_id__440B1D61");
            });

            modelBuilder.Entity<TCart>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TCarts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__t_cart__product___7B5B524B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TCarts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__t_cart__user_id__7A672E12");
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderStatus).HasDefaultValueSql("('pending')");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.TOrders)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .HasConstraintName("FK__t_orders__shippi__6477ECF3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TOrders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__t_orders__user_i__6383C8BA");
            });

            modelBuilder.Entity<TOrderItem>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPrice).HasComputedColumnSql("([quantity]*[price])", false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TOrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__t_order_i__order__693CA210");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TOrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__t_order_i__produ__6A30C649");
            });

            modelBuilder.Entity<TPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__t_paymen__ED1FC9EA902A8995");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentStatus).HasDefaultValueSql("('pending')");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TPayments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__t_payment__order__70DDC3D8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
