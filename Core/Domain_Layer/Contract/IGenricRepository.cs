using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Contract
{
    public interface IGenricRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        //GetAll
        Task<IEnumerable<TEntity>> GetAllAsync();
        //GetById
        Task<TEntity?> GetByIdAsync(Tkey id);
        //Update
        void Update(TEntity entity);
        //Remove
        void Remove(TEntity entity);
        //Add
        Task AddAsync(TEntity entity);
    }
}
