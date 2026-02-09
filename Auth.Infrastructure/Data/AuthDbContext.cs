using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Data
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<InstructorProfile> InstructorProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

                entity.HasIndex(u => u.Email)
                .IsUnique();

                entity.Property(u => u.PasswordHash)
                .IsRequired();

                entity.Property(u=>u.Role)
                .IsRequired()
                .HasMaxLength (50);
            });

            modelBuilder.Entity<InstructorProfile>(entity =>
            {
                entity.HasKey(ip => ip.Id);

                entity.Property(ip => ip.YearsOfExperience)
                .IsRequired();

                entity.Property(ip => ip.Status)
                .HasConversion<int>()
                .IsRequired();

                entity.Property(ip => ip.ResumeUrl)
                .IsRequired();

                entity.HasOne<User>()
                .WithOne()
                .HasForeignKey<InstructorProfile>(ip => ip.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(ip => ip.UserId)
                .IsUnique();
            });
        }
    }
}
