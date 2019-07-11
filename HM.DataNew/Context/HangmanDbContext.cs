using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using HM.Data.Entities;
using HM.Data.Entities.GameItems;

namespace HM.Data.Context
{
    public class HangmanDbContext : DbContext
    {
        public HangmanDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Word> Words { get; set; }

        public DbSet<GameTracker> GameTrackers { get; set; }

    }
}
