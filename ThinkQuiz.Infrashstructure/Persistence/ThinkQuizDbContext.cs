﻿using Microsoft.EntityFrameworkCore;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence
{
    public class ThinkQuizDbContext : DbContext
    {
        public ThinkQuizDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThinkQuizDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
