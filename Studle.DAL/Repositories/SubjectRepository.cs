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
    public class SubjectRepository : IRepository<Subject>
    {
        private readonly AppDbContext dbContext;

        private readonly DbSet<Subject> dbSet;

        public SubjectRepository(AppDbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<Subject>();
        }

        public IEnumerable<Subject> Get()
        {
            return dbSet.ToList();
        }

        public IEnumerable<Subject> Get(Func<Subject, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Subject> GetAll()
        {
            return dbContext.Subjects;
        }

        public Subject Get(int id)
        {
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Subject subject)
        {
            dbContext.Subjects.Add(subject);
        }

        public void Update(Subject subject)
        {
            dbSet.Update(subject);
        }

        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            return dbContext.Subjects.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var subject = dbSet.Find(id);
            if (subject != null)
            {
                dbSet.Remove(subject);
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
