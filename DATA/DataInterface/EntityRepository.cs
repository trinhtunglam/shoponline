﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DATA.DataInterface
{
    public partial class EntityRepository<T> : IDisposable, IEntityRepository<T> where T : class
    {
        #region Fields

        protected readonly DbContext _entitiesContext;

        public EntityRepository(DbContext entitiesContext)
        {
            if (entitiesContext == null)
            {
                throw new ArgumentNullException("entitiesContext");
            }
            _entitiesContext = entitiesContext;
        }

        private DbSet<T> _entities;

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _entitiesContext.Set<T>();
                }
                return _entities as DbSet<T>;
            }
        }

        public virtual IQueryable<T> AllIncluding(
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _entitiesContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _entitiesContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            Entities.Add(entity);
        }

        public virtual void Edit(T entity)
        {
            var dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void UpdateRange(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            entities.ForEach(entity =>
            {
                if (_entitiesContext.Entry(entity).State == EntityState.Detached)
                {
                    _entitiesContext.Entry(entity).State = EntityState.Modified;
                }
            });
            _entitiesContext.SaveChanges();
        }

        public virtual void InsertRange(List<T> entities, int batchSize = 100)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                if (entities.Any())
                {
                    if (batchSize <= 0)
                    {
                        // insert all in one step
                        entities.ForEach(x => this.Entities.Add(x));
                        _entitiesContext.SaveChanges();
                    }
                    else
                    {
                        int i = 1;
                        bool saved = false;
                        foreach (var entity in entities)
                        {
                            this.Entities.Add(entity);
                            saved = false;
                            if (i % batchSize == 0)
                            {
                                _entitiesContext.SaveChanges();
                                i = 0;
                                saved = true;
                            }
                            i++;
                        }

                        if (!saved)
                        {
                            _entitiesContext.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void DeleteRange(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            entities.ForEach(entity =>
            {
                if (_entitiesContext.Entry(entity).State == EntityState.Detached)
                {
                    this.Entities.Attach(entity);
                }
            });

            this.Entities.RemoveRange(entities);
            _entitiesContext.SaveChanges();
        }

        public virtual void Save()
        {
            _entitiesContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _entitiesContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        public virtual T GetSingleById(int id)
        {
            return this.Entities.Find(id);
        }

        public virtual T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _entitiesContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return _entitiesContext.Set<T>().FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = _entitiesContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return _entitiesContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = _entitiesContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return _entitiesContext.Set<T>().AsQueryable();
        }

        public void Delete(int id)
        {
            var model = Entities.Find(id);
            Entities.Remove(model);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        //public virtual IQueryable<T> Table
        //{
        //    get
        //    {
        //        return this.Entities;
        //    }
        //}

        ///// <summary>
        ///// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        ///// </summary>
        //public virtual IQueryable<T> TableNoTracking
        //{
        //    get
        //    {
        //        return this.Entities.AsNoTracking();
        //    }
        //}

        ///// <summary>
        ///// Entities
        ///// </summary>
        //protected virtual DbSet<T> Entities
        //{
        //    get
        //    {
        //        if (_entities == null)
        //            _entities = _context.Set<T>();
        //        return _entities;
        //    }
        //}

        #endregion
    }
}
