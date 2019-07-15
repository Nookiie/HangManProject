using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities.Users;
using HM.Data.Entities;
using HM.Data.Entities.GameItems;
using Microsoft.EntityFrameworkCore;

namespace HM.Data.Context
{
    public class HangmanDbContext : DbContext
    {
        public HangmanDbContext(DbContextOptions<HangmanDbContext> options) : base(options)
        {

        }

        public DbSet<Word> Words { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().ToTable("Words");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
