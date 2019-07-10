using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private HangmanDbContext _context = new HangmanDbContext();
        private GenericRepository<Word> _wordRepository;
        private GenericRepository<GameTracker> _gameTrackerRepository;

        public GenericRepository<Word> WordRepository
        {
            get
            {

                if (this._wordRepository == null)
                {
                    this._wordRepository = new GenericRepository<Word>(_context);
                }
                return _wordRepository;
            }
        }

        public GenericRepository<GameTracker> GameTrackerRepository
        {
            get
            {
                if (this._gameTrackerRepository == null)
                {
                    this._gameTrackerRepository = new GenericRepository<GameTracker>(_context);
                }
                return _gameTrackerRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
