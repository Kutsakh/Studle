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
        private readonly AppDbContext _dbContext;

        private readonly DbSet<Subject> _dbSet;

        public SubjectRepository(AppDbContext context)
        {
            this._dbContext = context;
            _dbSet = _dbContext.Set<Subject>();
        }

        public IEnumerable<Subject> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Subject> Get(Func<Subject, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Subject> GetAll()
        {
            return _dbContext.Subjects;
        }

        public Subject Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Subject subject)
        {
            _dbContext.Subjects.Add(subject);
        }

        public void Update(Subject subject)
        {
            _dbSet.Update(subject);
        }

        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            return _dbContext.Subjects.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Subject subject = _dbSet.Find(id);
            if (subject != null)
                _dbSet.Remove(subject);
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