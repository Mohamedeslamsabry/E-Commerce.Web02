using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Contract
{
    public interface IGenricRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        #region GetAll        
        Task<IEnumerable<TEntity>> GetAllAsync();
        #endregion
        
        #region GetById
        Task<TEntity?> GetByIdAsync(Tkey id);
        #endregion

        #region Update
        void Update(TEntity entity);
        #endregion

        #region Remove
        void Remove(TEntity entity);
        #endregion

        #region Add
        Task AddAsync(TEntity entity);
        #endregion

        #region specification
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, Tkey> specification);

        Task<TEntity?> GetByIdAsync(ISpecification<TEntity, Tkey> specification); 
        #endregion
    }
}
