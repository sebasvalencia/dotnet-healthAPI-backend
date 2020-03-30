﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_healthAPI_backend.Models;
using Microsoft.EntityFrameworkCore;



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
                .HasKey(x => new { x.UserId, x.SicknessId});
        }

    }
}
