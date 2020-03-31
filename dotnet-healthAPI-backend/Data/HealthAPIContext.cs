﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_healthAPI_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_healthAPI_backend.Data
{
    public class HealthAPIContext : DbContext
    {
        public HealthAPIContext(DbContextOptions<HealthAPIContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Sickness> Sickness { get; set; }
        public DbSet<UserSickness> UserSickness { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSickness>()
                .HasKey(x => new {x.Id}); // x.UserId, x.SicknessId
            modelBuilder.Entity<UserSickness>().
                HasOne(x => x.User).WithMany(x => x.UserSicknessUser).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserSickness>().
                HasOne(x => x.Sickness).WithMany(x => x.UserSicknessSickness).HasForeignKey(x => x.SicknessId);

        }

    }
}
