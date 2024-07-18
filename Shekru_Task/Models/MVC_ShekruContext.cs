﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shekru_Task.Models;

public partial class MVC_ShekruContext : DbContext
{
    public MVC_ShekruContext(DbContextOptions<MVC_ShekruContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<DesignationGrade> DesignationGrades { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.Did);

            entity.ToTable("Designation");

            entity.Property(e => e.Did).HasColumnName("DId");
            entity.Property(e => e.Designationname).HasMaxLength(100);
        });

        modelBuilder.Entity<DesignationGrade>(entity =>
        {
            entity.HasKey(e => e.Dgid);

            entity.ToTable("DesignationGrade");

            entity.Property(e => e.Dgid).HasColumnName("DGID");
            entity.Property(e => e.Designationref).HasColumnName("designationref");
            entity.Property(e => e.Gradename).HasMaxLength(100);

            entity.HasOne(d => d.DesignationrefNavigation).WithMany(p => p.DesignationGrades)
                .HasForeignKey(d => d.Designationref)
                .HasConstraintName("FK_Gd");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.Firstname).HasMaxLength(100);
            entity.Property(e => e.Lastname).HasMaxLength(100);

            entity.HasOne(d => d.DesignationRefNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DesignationRef)
                .HasConstraintName("FK_EMPDESIG");

            entity.HasOne(d => d.GraderefNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Graderef)
                .HasConstraintName("FK_EMPDESIGgrade");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}