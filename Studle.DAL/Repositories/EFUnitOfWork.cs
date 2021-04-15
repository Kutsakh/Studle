using System;
using Studle.DAL.EF;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;

namespace Studle.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        private bool disposed;

        public EFUnitOfWork(
            AppDbContext dbContext,
            IRepository<User> userRepository,
            IRepository<Mark> markRepository,
            IRepository<Subject> subjectRepository)
        {
            this.dbContext = dbContext;
            Users = userRepository;
            Marks = markRepository;
            Subjects = subjectRepository;
        }

        public IRepository<User> Users { get; }

        public IRepository<Mark> Marks { get; }

        public IRepository<Subject> Subjects { get; }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                dbContext.Dispose();
            }

            disposed = true;
        }
    }
}
