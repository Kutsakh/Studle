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
        private readonly AppDbContext _dbContext;

        private readonly DbSet<User> _dbSet;

        public UserRepository(AppDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<User>();
        }

        public IEnumerable<User> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Guests;
        }

        public User Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User user)
        {
            _dbContext.Guests.Add(user);
        }

        public void Update(User user)
        {
            _dbSet.Update(user);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _dbContext.Guests.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = _dbSet.Find(id);
            if (user != null)
                _dbSet.Remove(user);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}