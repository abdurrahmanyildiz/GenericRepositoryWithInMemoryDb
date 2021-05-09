using Microsoft.EntityFrameworkCore;
using MockDBExample.Models;
using MockDBExample.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MockDBExample.Repos
{
    public class GenericRepository<TEntity, TContext> : IGenericRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var ctx = new TContext())
            {
                var addedEntity = ctx.Entry(entity);
                addedEntity.State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var ctx = new TContext())
            {
                var deletedEntity = ctx.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var ctx = new TContext())
            {
                return ctx.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var ctx = new TContext())
            {
                if (filter == null)
                {
                    return ctx.Set<TEntity>().ToList();
                }
                else
                {
                    return ctx.Set<TEntity>().Where(filter).ToList();
                }
            }
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var ctx = new TContext())
            {
                if (filter == null)
                {
                    return ctx.Set<TEntity>().ToListAsync();
                }
                else
                {
                    return ctx.Set<TEntity>().Where(filter).ToListAsync();
                }
            }
        }
    }
}
