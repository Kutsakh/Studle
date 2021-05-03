using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Studle.DAL.Abstractions;
using Studle.DAL.Entities;

namespace Studle.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        public IRepository<Mark> Marks { get; }

        public IRepository<Subject> Subjects { get; }

        public IRepository<Group> Groups { get; }

        public IRepository<Student> Students { get; }

        public IRepository<Teacher> Teachers { get; }

        public IRepository<Topic> Topics { get; }

        public UserManager<User> UserManager { get; }

        public RoleManager<Role> RoleManager { get; }

        public SignInManager<User> SignInManager { get; }

        public void Save();

        public Task SaveAsync();


    }
}
