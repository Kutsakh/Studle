using System;
using Studle.DAL.Entities;

namespace Studle.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        void Save();
    }
}