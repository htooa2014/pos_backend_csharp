﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DotNet7.PosBackendApi.DbService.DbModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblProductCategory> TblProductCategories { get; set; }

    public virtual DbSet<TblShop> TblShops { get; set; }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HA\\SQL2019;Database=Pos;User ID=sa;Password=sasa;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_ProductCategory");

            entity.ToTable("Tbl_ProductCategory");

            entity.Property(e => e.ProductCategoryCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductCategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_Customer");

            entity.ToTable("Tbl_Customer");

            
        });

        modelBuilder.Entity<TblShop>(entity =>
        {
            entity.HasKey(e => e.ShopId).HasName("PK_Shop");

            entity.ToTable("Tbl_Shop");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShopCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShopName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK_Staff");

            entity.ToTable("Tbl_Staff");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StaffCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StaffName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
