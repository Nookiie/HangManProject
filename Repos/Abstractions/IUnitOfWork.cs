using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace HM.Repositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IRepository<Word> Words { get; }

        IRepository<GameTracker> GameTrackers { get; }
    }
}
