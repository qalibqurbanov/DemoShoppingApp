using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DemoShoppingApp.DataAccess.DbContext;
using DemoShoppingApp.DataAccess.Repositories.Abstract;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DemoShoppingApp.DataAccess.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<T> setOfEntities;

        public BaseRepository(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
            this.setOfEntities = this.dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            setOfEntities.Add(entity);
        }

        public void Delete(T entity)
        {
            setOfEntities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            setOfEntities.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, List<string> includeProperties = null)
        {
            IQueryable<T> query = setOfEntities;

            if (predicate != null) query = query.Where(predicate);

            if (includeProperties?.Count > 0)
            {
                foreach (string prop in includeProperties)
                {
                    query = query.Include(prop);
                }
            }

            return query.ToList();
        }

        public T GetEntity(Expression<Func<T, bool>> predicate, List<string> includeProperties = null)
        {
            IQueryable<T> query = setOfEntities;

            query = query.Where(predicate);

            if (includeProperties?.Count > 0)
            {
                foreach (string prop in includeProperties)
                {
                    query = query.Include(prop);
                }
            }

            return query.FirstOrDefault()!;
        }
    }
}