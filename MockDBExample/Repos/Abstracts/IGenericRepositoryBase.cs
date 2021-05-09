using MockDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MockDBExample.Repos.Abstracts
{
    public interface IGenericRepositoryBase<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Delete(T entity);
    }
}
