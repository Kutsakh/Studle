using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studle.DAL.Abstractions;
using Studle.DAL.Interfaces;

namespace Studle.Tests.Mocks
{
    public class MockRepository<T> : IRepository<T>
        where T : AbstractEntity
    {
        private readonly List<T> items;

        public MockRepository()
        {
            items = new List<T>();
        }

        public IEnumerable<T> Get()
        {
            return items;
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }

        public T Get(int id)
        {
            return items.Find(x => x.Id == id);
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return items.Where(predicate);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return items.Where(predicate);
        }

        public void Create(T item)
        {
            items.Add(item);
        }

        public void Update(T item)
        {
            var index = items.FindIndex(x => x.Id == item.Id);
            items[index] = item;
        }

        public void Delete(int id)
        {
            var index = items.FindIndex(x => x.Id == id);
            items.RemoveAt(index);
        }

        public void Save()
        {
        }

        public Task SaveAsync()
        {
            return Task.FromResult(0);
        }
    }
}
