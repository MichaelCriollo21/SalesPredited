using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Context.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string[] IncludeProperties = null);
        void Dispose(bool disposing);
    }
}
