using System;
using System.Collections.Generic;
using System.Text;
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

        public DbSet<GameTracker> GameTrackers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().ToTable("Word");
            modelBuilder.Entity<GameTracker>().ToTable("GameTracker");
        }
    }
}
