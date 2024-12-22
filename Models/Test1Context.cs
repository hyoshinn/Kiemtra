using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sinhvien.Models
{
    public partial class Test1Context : DbContext
    {
        public Test1Context()
        {
        }

        public Test1Context(DbContextOptions<Test1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DangKy> DangKies { get; set; } = null!;
        public virtual DbSet<HocPhan> HocPhans { get; set; } = null!;
        public virtual DbSet<NganhHoc> NganhHocs { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-4015536H;Database=Test1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DangKy>(entity =>
            {
                entity.HasKey(e => e.MaDk)
                    .HasName("PK__DangKy__2725866C17AD56CB");

                entity.ToTable("DangKy");

                entity.Property(e => e.MaDk).HasColumnName("MaDK");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.NgayDk)
                    .HasColumnType("date")
                    .HasColumnName("NgayDK");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.DangKies)
                    .HasForeignKey(d => d.MaSv)
                    .HasConstraintName("FK__DangKy__MaSV__3E52440B");

                entity.HasMany(d => d.MaHps)
                    .WithMany(p => p.MaDks)
                    .UsingEntity<Dictionary<string, object>>(
                        "ChiTietDangKy",
                        l => l.HasOne<HocPhan>().WithMany().HasForeignKey("MaHp").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ChiTietDan__MaHP__4222D4EF"),
                        r => r.HasOne<DangKy>().WithMany().HasForeignKey("MaDk").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ChiTietDan__MaDK__412EB0B6"),
                        j =>
                        {
                            j.HasKey("MaDk", "MaHp").HasName("PK__ChiTietD__F557DC02CE91CCA4");

                            j.ToTable("ChiTietDangKy");

                            j.IndexerProperty<int>("MaDk").HasColumnName("MaDK");

                            j.IndexerProperty<string>("MaHp").HasMaxLength(6).IsUnicode(false).HasColumnName("MaHP").IsFixedLength();
                        });
            });

            modelBuilder.Entity<HocPhan>(entity =>
            {
                entity.HasKey(e => e.MaHp)
                    .HasName("PK__HocPhan__2725A6ECCB3153AC");

                entity.ToTable("HocPhan");

                entity.Property(e => e.MaHp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MaHP")
                    .IsFixedLength();

                entity.Property(e => e.TenHp)
                    .HasMaxLength(30)
                    .HasColumnName("TenHP");
            });

            modelBuilder.Entity<NganhHoc>(entity =>
            {
                entity.HasKey(e => e.MaNganh)
                    .HasName("PK__NganhHoc__A2CEF50D7EA4F703");

                entity.ToTable("NganhHoc");

                entity.Property(e => e.MaNganh)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNganh).HasMaxLength(30);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSv)
                    .HasName("PK__SinhVien__2725081A857B89D9");

                entity.ToTable("SinhVien");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaSV")
                    .IsFixedLength();

                entity.Property(e => e.GioiTinh).HasMaxLength(5);

                entity.Property(e => e.Hinh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaNganh)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.HasOne(d => d.MaNganhNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaNganh)
                    .HasConstraintName("FK__SinhVien__MaNgan__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
