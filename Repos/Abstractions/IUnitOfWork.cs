using HM.Data.Context;
using HM.Data.Entities.GameItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace HM.Repositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        HangmanDbContext Context { get; }

        IRepository<Word> Words { get; }

        IRepository<Category> Categories { get; }
    }
}
