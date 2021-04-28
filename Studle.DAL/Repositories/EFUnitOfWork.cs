using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Studle.DAL.EF;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;

namespace Studle.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        private bool disposed;

        public UserManager<User> UserManager { get; }

        public RoleManager<Role> RoleManager { get; }

        public SignInManager<User> SignInManager { get; }

        public IRepository<Mark> Marks { get; }

        public IRepository<Subject> Subjects { get; }

        public IRepository<Group> Groups { get; }

        public IRepository<Student> Students { get; }

        public IRepository<Teacher> Teachers { get; }

        public IRepository<Topic> Topics { get; }

        public EFUnitOfWork()
        {
            this.dbContext = new AppDbContext();
        }

        public EFUnitOfWork(
            AppDbContext dbContext,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager)
        {
            this.dbContext = dbContext;
            this.UserManager = userManager;
            this.RoleManager = roleManager;
            this.SignInManager = signInManager;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
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
