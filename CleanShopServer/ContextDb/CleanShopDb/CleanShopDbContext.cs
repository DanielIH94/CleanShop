using System;
using System.Collections.Generic;
using CleanShopServer.Models.CleanShopDb;
using Microsoft.EntityFrameworkCore;

namespace CleanShopServer.ContextDb.CleanShopDb;

public partial class CleanShopDbContext : DbContext
{
    public CleanShopDbContext()
    {
    }

    public CleanShopDbContext(DbContextOptions<CleanShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProductos).HasName("PK__Producto__D63049745E6F40C4");

            entity.Property(e => e.IdProductos).HasColumnName("IDProductos");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVentas).HasName("PK__Ventas__A19910311BB1F899");

            entity.Property(e => e.IdVentas).HasColumnName("IDVentas");
            entity.Property(e => e.Idproductos).HasColumnName("IDProductos");

            entity.HasOne(d => d.Producto).WithMany(p => p.Ventas)
                .HasForeignKey(d => d.Idproductos)
                .HasConstraintName("FK__Ventas__IDProduc__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
