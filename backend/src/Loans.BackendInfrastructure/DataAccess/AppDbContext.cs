




using Loans.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.BackendInfrastructure.DataAccess
{
    public class AppDbContext:DbContext
    {
        public DbSet<Loan> Loans=>Set<Loan>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.ApplicantName).IsRequired().HasMaxLength(250);
                entity.Property(l => l.Amount).HasColumnType("decimal(18,2)");
                entity.Property(l => l.CurrentBalance).HasColumnType("decimal(18,2)");
                entity.Property(l => l.Status).IsRequired().HasConversion<string>();
            });
        }
    }
}
