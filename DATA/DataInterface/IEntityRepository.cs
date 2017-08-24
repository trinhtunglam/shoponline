using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DATA.DataInterface
{
    public partial interface IEntityRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string[] includes = null);

        T GetSingleById(int id);
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        void Delete(int id);
        void UpdateRange(List<T> entities);

        void InsertRange(List<T> entities, int batchSize = 100);

        void DeleteRange(List<T> entities);

        /// <summary>
        /// SUBMIT CHANGES dataContext
        /// </summary>
        void Save();

        //T GetById(object id);


        //void Insert(T entity);


        //void Insert(IEnumerable<T> entities);


        //void Update(T entity);


        //void Update(IEnumerable<T> entities);


        //void Delete(T entity);


        //void Delete(IEnumerable<T> entities);

        ///// <summary>
        ///// Gets a table
        ///// </summary>
        //IQueryable<T> Table { get; }

        ///// <summary>
        ///// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        ///// </summary>
        //IQueryable<T> TableNoTracking { get; }
    }
}
