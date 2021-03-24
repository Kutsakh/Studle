using System;
using Studle.DAL.EF;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;

namespace Studle.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        private bool _disposed = false;
        
        public IRepository<User> Users { get; }
        public IRepository<Mark> Marks { get; }
        public IRepository<Subject> Subjects { get; }

        public EFUnitOfWork(
            AppDbContext dbContext,
            IRepository<User> userRepository,
            IRepository<Mark> markRepository,
            IRepository<Subject> subjectRepository)
        {
            _dbContext = dbContext;
            Users = userRepository;
            Marks = markRepository;
            Subjects = subjectRepository;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _dbContext.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}