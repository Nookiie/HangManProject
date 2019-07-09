using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Data.Entities;
using Data.Entities.Users;

namespace Data.Context
{
    public class HangmanDbContext : DbContext
    {
        public HangmanDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Word> Words { get; set; }

        public DbSet<GameTracker> GameTrackers { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
