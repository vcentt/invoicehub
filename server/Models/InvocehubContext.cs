using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public partial class InvocehubContext : DbContext
{
    public InvocehubContext()
    {
    }

    public InvocehubContext(DbContextOptions<InvocehubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoce> Invoces { get; set; }

    public virtual DbSet<InvoceProduct> InvoceProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8342A9720");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(9);
        });

        modelBuilder.Entity<Invoce>(entity =>
        {
            entity.HasKey(e => e.InvoceId).HasName("PK__Invoces__232AB1B93F656C56");

            entity.Property(e => e.InvoceId).HasColumnName("InvoceID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Itbis).HasColumnName("ITBIS");
            entity.Property(e => e.Status).HasMaxLength(5);

            // entity.HasOne(d => d.Customer).WithMany(p => p.Invoces)
            //     .HasForeignKey(d => d.CustomerId)
            //     .HasConstraintName("FK__Invoces__Custome__619B8048");

            // entity.HasOne(d => d.InvoceProduct).WithMany(p => p.Invoces)
            //     .HasForeignKey(d => d.InvoceProductId)
            //     .HasConstraintName("FK__Invoces__InvoceP__71D1E811");
        });

        modelBuilder.Entity<InvoceProduct>(entity =>
        {
            entity.HasKey(e => e.InvoceProductId).HasName("PK__InvocePr__5ED361D111E10C56");

            entity.Property(e => e.InvoceProductId).HasColumnName("InvoceProductID");
            entity.Property(e => e.InvoceId).HasColumnName("InvoceID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            // entity.HasOne(d => d.Invoce).WithMany(p => p.InvoceProducts)
            //     .HasForeignKey(d => d.InvoceId)
            //     .HasConstraintName("FK__InvocePro__Produ__6FE99F9F");

            // entity.HasOne(d => d.Product).WithMany(p => p.InvoceProducts)
            //     .HasForeignKey(d => d.ProductId)
            //     .HasConstraintName("FK__InvocePro__Produ__70DDC3D8");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDAC8D2E77");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
