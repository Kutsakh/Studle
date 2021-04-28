using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Studle.DAL.EF;
using Studle.DAL.Entities;
using Studle.DAL.Interfaces;

namespace Studle.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext dbContext;

        private readonly DbSet<User> dbSet;

        public UserRepository(AppDbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<User>();
        }

        public IEnumerable<User> Get()
        {
            return dbSet.ToList();
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Guests;

        public User Get(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User user)
        {
            _dbContext.Guests.Add(user);


        public void Update(User user)
        {
            dbSet.Update(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _dbContext.Guests.Where(predicate).ToList();



        public void Delete(int id)
        {
            var user = dbSet.Find(id);
            if (user != null)
            {
                dbSet.Remove(user);
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
