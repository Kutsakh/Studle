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
    public class MarkRepository : IRepository<Mark>
    {
        private readonly AppDbContext _dbContext;

        private readonly DbSet<Mark> _dbSet;

        public MarkRepository(AppDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<Mark>();
        }

        public IEnumerable<Mark> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Mark> Get(Func<Mark, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Mark> GetAll()
        {
            return _dbContext.Marks;
        }

        public Mark Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Mark mark)
        {
            _dbContext.Marks.Add(mark);
        }

        public void Update(Mark mark)
        {
            _dbSet.Update(mark);
        }

        public IEnumerable<Mark> Find(Func<Mark, bool> predicate)
        {
            return _dbContext.Marks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Mark mark = _dbSet.Find(id);
            if (mark != null)
                _dbSet.Remove(mark);
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