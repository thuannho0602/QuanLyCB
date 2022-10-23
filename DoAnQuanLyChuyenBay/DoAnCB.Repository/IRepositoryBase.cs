using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Repository
{
   public interface IRepositoryBase<T>
   {
        Expression<Func<T, bool>> FilterEntityContext();
        IQueryable<T> InternalFilter();
        IQueryable<T> FindAll(bool isTracking = false);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking = false);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool isTracking = false);
        Task<T> FirstOrDefaultAsync(bool isTracking = false);
        //Task<T> FirstOrDefaultCacheAsync(Expression<Func<T, bool>> expression, bool isTracking = false);
        void Attach(T entity);
        void Detact(T entity);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        void BeforeAdd(T entity);
        void BeforeUpdate(T entity);
        void BeforeDelete(T entity);
        void SetContext(int entityContext, string userContext);
        void SetContext(int entityContext, string userContext, string facility);
        void RemoveContext();
        void SaveChanges();
        void Remove(T entity);

        void RemoveRange(List<T> entity);

    }
}
