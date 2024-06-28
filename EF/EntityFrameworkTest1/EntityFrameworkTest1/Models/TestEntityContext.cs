using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest1.Models;

public partial class TestEntityContext : DbContext
{
    public TestEntityContext()
    {
    }

    public TestEntityContext(DbContextOptions<TestEntityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SERVER1;User ID=sa;Password=12345;Database=TestEntity;Trusted_Connection=False;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lop__3214EC275BB3ED3B");

            entity.ToTable("Lop");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("(N'Kteam class')");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SinhVien__3214EC279665719A");

            entity.ToTable("SinhVien");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idlop).HasColumnName("IDLop");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("(N'Kter name')");

            entity.HasOne(d => d.IdlopNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.Idlop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SinhVien__IDLop__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
