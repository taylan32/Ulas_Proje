using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Repositories
{
    public interface IRepository<T> where T : Entity, new()
    {
        T Get(Expression<Func<T, bool>> predicate);
        T GetWithInclude(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        List<T> GetList(Expression<Func<T, bool>>? predicate = null,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
