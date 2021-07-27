using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DAL
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : EntityBase
    {
        protected readonly OnlineShopDBContext dBContext;
        public RepositoryBase(OnlineShopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void Add(T entity)
        {
            dBContext.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            dBContext.Set<T>().AddRange(entities);
        }
        public void Update(T entity)
        {
            dBContext.Update(entity);
        }
        public T Get(int id)
        {
            var entity = dBContext.Set<T>().Find(id);
            return entity;
        }
        public IEnumerable<T> GetAll()
        {
            var entities = dBContext.Set<T>().ToArray();
            return entities;
        }
        public void Remove(T entity)
        {
            dBContext.Set<T>().Remove(entity);
        }
        public bool Any(Func<T, bool> condition)
        {
            return dBContext.Set<T>().Any(condition);
        }
        public T GetSingle(Func<T, bool> predicate)
        {
            return dBContext.Set<T>().FirstOrDefault(predicate);
        }
    }
}
