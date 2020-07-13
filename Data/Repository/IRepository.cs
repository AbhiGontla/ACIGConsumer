using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepository<TEntity>
    {

        IQueryable<TEntity> GetDbSet();

        /// <summary>
        /// generic Get method for Entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Get();


        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetByID(object id);


        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);


        /// <summary>
        /// generic bulk insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        void AddRange(IEnumerable<TEntity> entity);


        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);


        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Delete(TEntity entityToDelete);


        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Update(TEntity entityToUpdate);


        /// <summary>
        /// generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);


        /// <summary>
        /// generic method to get many record on the basis of a condition but query able.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where);

        /// <summary>
        /// generic get method , fetches data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        TEntity Get(Func<TEntity, Boolean> where);


        /// <summary>
        /// generic method to get count
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int GetCount(Func<TEntity, bool> where);


        /// <summary>
        /// generic delete method , deletes data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        void Delete(Func<TEntity, Boolean> where);


        /// <summary>
        /// generic method to fetch all the records from db
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();


        /// <summary>
        /// Inclue multiple
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include">inclue</param>
        /// <returns></returns>
        IQueryable<TEntity> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include);


        /// <summary>
        /// Generic method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        bool Exists(object primaryKey);


        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        TEntity GetSingle(Func<TEntity, bool> predicate);


        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        TEntity GetFirst(Func<TEntity, bool> predicate);


        #region Async Methods

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIDAsync(object id);

        Task InsertAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entity);

        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, Boolean>> where);

        Task<TEntity> GetAsync(Expression<Func<TEntity, Boolean>> where);

        Task<int> GetCountAsync(Expression<Func<TEntity, Boolean>> where);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<bool> ExistsAsync(object primaryKey);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<TEntity> entities);

    }

}
