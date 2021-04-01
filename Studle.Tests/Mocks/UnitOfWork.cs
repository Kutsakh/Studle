using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;

namespace Studle.Tests.Mocks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<User> Users { get; }

        public IRepository<Mark> Marks { get; }

        public IRepository<Subject> Subjects { get; }

       

        public UnitOfWork()
        {
            Users = new MockRepository<User>();

            Marks = new MockRepository<Mark>();

            Subjects = new MockRepository<Subject>();
            
        }

        public void Save() { }

        public void Dispose() { }
    }
}
