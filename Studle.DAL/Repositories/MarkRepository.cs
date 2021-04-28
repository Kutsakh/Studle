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
        private readonly AppDbContext dbContext;

        private readonly DbSet<Mark> dbSet;

        public MarkRepository(AppDbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<Mark>();
        }

        public IEnumerable<Mark> Get()
        {
            return dbSet.ToList();
        }

        public IEnumerable<Mark> Get(Func<Mark, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Mark> GetAll()
        {
            return dbContext.Marks;
        }

        public Mark Get(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Mark mark)
        {
            dbContext.Marks.Add(mark);
        }

        public void Update(Mark mark)
        {
            dbSet.Update(mark);
        }

        public IEnumerable<Mark> Find(Func<Mark, bool> predicate)
        {
            return dbContext.Marks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var mark = dbSet.Find(id);
            if (mark != null)
            {
                dbSet.Remove(mark);
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
