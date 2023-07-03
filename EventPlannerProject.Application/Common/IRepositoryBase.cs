using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerProject.Application.Common
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAllAsync(bool trackChanges);
        IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
