using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Repository.Repository
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll(bool eager);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindandInclude(Expression<Func<T, bool>> expression, bool eager);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        public void Update(T entity);
    }
}
