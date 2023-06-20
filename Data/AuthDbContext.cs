using Microsoft.EntityFrameworkCore;
using Practical_13.Models;
using System.Collections.Generic;

namespace Practical_13.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DesignationDetail> Designations { get; set; }
        public DbSet<EmployeeTest1> EmployeeTests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
            .HasOne(b => b.DesignationDetail)               // Employee has one Des
            .WithMany(a => a.Employees)              // Des has many Emp
            .HasForeignKey(b => b.DesignationId);     // Foreign key relationship
        }
    }
}
