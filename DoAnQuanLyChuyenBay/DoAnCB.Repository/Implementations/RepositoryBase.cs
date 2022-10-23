using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Repository.Implementations
{
    public abstract class RepositoryBase<T, K> : IRepositoryBase<T> where T : class where K : DbContext
    {
        protected K RepositoryContext { get; set; }
        protected int EntityContext { get; set; } = -1;
        protected string UserContext { get; set; }
        protected string Facility { get; set; }

        private Dictionary<string, T> _firstOrDefaultCache = new Dictionary<string, T>();

        public RepositoryBase(K repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public virtual Expression<Func<T, bool>> FilterEntityContext()
        {
            return p => true;
        }

        public IQueryable<T> FindAll(bool isTracking = false)
        {
            if (!isTracking)
            {
                return this.InternalFilter().AsNoTracking();
            }
            return this.InternalFilter();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking = false)
        {
            if (!isTracking)
            {
                return this.InternalFilter().AsNoTracking().Where(expression);
            }
            return this.InternalFilter().Where(expression);
        }

        //public async Task<T> FirstOrDefaultCacheAsync(Expression<Func<T, bool>> expression, bool isTracking = false)
        //{
        //    var key = _GetKey(expression);
        //    if (!_firstOrDefaultCache.ContainsKey(key))
        //    {
        //        _firstOrDefaultCache[key] = await FirstOrDefaultAsync(expression, isTracking);
        //    }
        //    return _firstOrDefaultCache[key];
        //}

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool isTracking = false)
        {
            if (!isTracking)
            {
                return await this.InternalFilter().AsNoTracking().FirstOrDefaultAsync(expression);
            }
            return await this.InternalFilter().FirstOrDefaultAsync(expression);
        }

        public async Task<T> FirstOrDefaultAsync(bool isTracking = false)
        {
            if (!isTracking)
            {
                return await this.InternalFilter().AsNoTracking().FirstOrDefaultAsync();
            }
            return await this.InternalFilter().FirstOrDefaultAsync();
        }

        public void Attach(T entity)
        {
            this.RepositoryContext.Set<T>().Attach(entity);
        }

        public void Detact(T entity)
        {
            this.RepositoryContext.Entry(entity).State = EntityState.Detached;
        }

        public void Add(T entity)
        {
            this.BeforeAdd(entity);
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            foreach (var entity in entities)
                this.BeforeAdd(entity);
            this.RepositoryContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            this.BeforeUpdate(entity);
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            foreach (var entity in entities)
                this.BeforeUpdate(entity);
            this.RepositoryContext.Set<T>().UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            this.BeforeDelete(entity);
            this.RepositoryContext.Set<T>().Remove(entity);
        }
        public void DeleteRange(List<T> entities)
        {
            if (entities == null)
                return;
            foreach (var entity in entities)
                this.BeforeDelete(entity);
            this.RepositoryContext.Set<T>().RemoveRange(entities);
        }

        public virtual IQueryable<T> InternalFilter()
        {
            if (EntityContext > 0)
            {
                return this.RepositoryContext.Set<T>().Where(FilterEntityContext());
            }
            else
            {
                return this.RepositoryContext.Set<T>();
            }
        }

        public void SetContext(int entityContext, string userContext)
        {
            this.EntityContext = entityContext;
            this.UserContext = userContext;
        }

        public void SetContext(int entityContext, string userContext, string facility)
        {
            this.EntityContext = entityContext;
            this.UserContext = userContext;
            this.Facility = facility;
        }

        public void RemoveContext()
        {
            this.EntityContext = 0;
            this.UserContext = null;
        }

        public virtual void BeforeAdd(T entity)
        {

        }

        public virtual void BeforeUpdate(T entity)
        {

        }

        public virtual void BeforeDelete(T entity)
        {

        }
        public void SaveChanges()
        {
            this.RepositoryContext.SaveChanges();
        }
        public void Remove(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(List<T> entity)
        {
            this.RepositoryContext.Set<T>().RemoveRange(entity);
        }

        //public string _GetKey(Expression<Func<T, bool>> expression)
        //{
        //    return expression.And(FilterEntityContext()).ToKey();
        //}
    }
}
