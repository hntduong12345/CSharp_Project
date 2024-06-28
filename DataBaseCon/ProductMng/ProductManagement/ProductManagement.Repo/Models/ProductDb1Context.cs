using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Repo.Models;

public partial class ProductDb1Context : DbContext
{
    private readonly string connectionString;

    public ProductDb1Context()
    {
    }

    public ProductDb1Context(string cs)
    {
        this.connectionString = cs;
    }

    public ProductDb1Context(DbContextOptions<ProductDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=MSI\\SERVER1;User ID=sa;Password=12345;Database=ProductDB1;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0781E38173");

            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07D47F8481");

            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__Product__CatId__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
