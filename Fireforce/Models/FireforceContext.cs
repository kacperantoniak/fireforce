using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Fireforce.Models;

public partial class FireforceContext : DbContext
{
    public FireforceContext()
    {
    }

    public FireforceContext(DbContextOptions<FireforceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Extinguisher> Extinguishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("brand");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.Model)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("model");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Plate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("plate");
            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .HasColumnName("vin");

            entity.HasOne(d => d.Dept).WithMany(p => p.Cars)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Cars_Dept");
        });

        modelBuilder.Entity<Dept>(entity =>
        {
            entity.ToTable("Dept");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aptnumber).HasColumnName("aptnumber");
            entity.Property(e => e.Bnumber).HasColumnName("bnumber");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(5)
                .HasColumnName("postal_code");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
            entity.Property(e => e.Voivodeship)
                .HasMaxLength(18)
                .HasColumnName("voivodeship");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.ToTable("Emp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");

            entity.HasOne(d => d.Dept).WithMany(p => p.Emps)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Emp_Dept");
        });

        modelBuilder.Entity<Extinguisher>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Serial).HasColumnName("serial");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.Dept).WithMany(p => p.Extinguishers)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Extinguishers_Dept");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
