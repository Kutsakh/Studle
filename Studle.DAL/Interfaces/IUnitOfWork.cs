using System;
using Studle.DAL.Entities;

namespace Studle.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Mark> Marks { get; }

        IRepository<Subject> Subjects { get; }

        void Save();
    }
}
