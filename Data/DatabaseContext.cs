using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DTS_Tugas6.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Education> Educations { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Profiling> Profilings { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Account --‡ AccountRoles
        modelBuilder.Entity<Account>()
            .HasMany<AccountRole>(a => a.AccountRoles)
            .WithOne(ar => ar.Account)
            .HasForeignKey(ar => ar.AccountNik)
            .OnDelete(DeleteBehavior.NoAction);

        // Role --‡ AccountRoles
        modelBuilder.Entity<Role>()
            .HasMany<AccountRole>(r => r.AccountsRoles)
            .WithOne(ar => ar.Role)
            .HasForeignKey(ar => ar.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        // AccountRoles ‡-- Account
        modelBuilder.Entity<AccountRole>()
            .HasOne<Account>(ar => ar.Account)
            .WithMany(a => a.AccountRoles)
            .HasForeignKey(ar => ar.AccountNik)
            .OnDelete(DeleteBehavior.NoAction);

        // AccountRoles ‡-- Role
        modelBuilder.Entity<AccountRole>()
            .HasOne<Role>(ar => ar.Role)
            .WithMany(r => r.AccountsRoles)
            .HasForeignKey(ar => ar.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        // Account -- Employee
        modelBuilder.Entity<Account>()
            .HasKey(a => a.EmployeeNik);

        // Employee -- Account
        modelBuilder.Entity<Employee>()
            .HasOne<Account>(e => e.Account)
            .WithOne(a => a.Employee);

        // Profiling -- Employee
        modelBuilder.Entity<Profiling>()
            .HasKey(p => p.EmployeeNik);

        // Employee -- Profiling
        modelBuilder.Entity<Employee>()
            .HasOne<Profiling>(e => e.Profiling)
            .WithOne(p => p.Employee);

        // Profiling -- Education
        modelBuilder.Entity<Profiling>()
            .HasKey(p => p.EmployeeNik);

        // Education -- Profiling
        modelBuilder.Entity<Education>()
            .HasOne<Profiling>(e => e.Profiling)
            .WithOne(p => p.Education);

        // University --‡ Education
        modelBuilder.Entity<University>()
            .HasMany<Education>(u => u.Educations)
            .WithOne(e => e.University)
            .HasForeignKey(e => e.UniversityId)
            .OnDelete(DeleteBehavior.NoAction);

        // Education ‡-- University
        modelBuilder.Entity<Education>()
            .HasOne<University>(e => e.University)
            .WithMany(u => u.Educations)
            .HasForeignKey(e => e.UniversityId)
            .OnDelete(DeleteBehavior.NoAction);

        // Roles seed data
        modelBuilder.Entity<Role>()
            .HasData(
                new Role
                {
                    Id = -1,
                    Name = "User"
                },
                new Role
                {
                    Id = -2,
                    Name = "Admin"
                });
    }
}