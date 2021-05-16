using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Infrastructure.Persistence
{
    // Configuração com banco de dados

    public class DevFreelaDbContext : DbContext
    {
        // API : EntityFrameworkCore, EntityFrameworkCore.Design
        //Persistence: EntityFrameworkCore ,EntityFrameworkCore.SqlServer

        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSkill> UsersSkills { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // fluent api

            modelBuilder
                .Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.UserSkills)
                .WithOne()
                .HasForeignKey(s => s.IdUser)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder
               .Entity<UserSkill>()
               .HasKey(u => u.Id);

            modelBuilder
               .Entity<ProvidedService>()
               .HasKey(u => u.Id);

            modelBuilder
             .Entity<ProvidedService>()
             .HasOne(p => p.Freelancer)
             .WithMany(f=> f.ProvidedServices)
             .HasForeignKey(p=> p.IdFreelancer)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
            .Entity<ProvidedService>()
            .HasOne(p => p.Client)
            .WithMany(o => o.OwningProvidedServices)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Skill>()
               .HasKey(u => u.Id);

            modelBuilder
             .Entity<Skill>()
             .HasMany(s => s.UserSkills)
             .WithOne()
             .HasForeignKey(s => s.IdSkill)
             .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
