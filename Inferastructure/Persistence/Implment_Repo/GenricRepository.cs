using Domain_Layer.Contract;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.DbContexts;
using Persistence.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Implment_Repo
{
    public class GenricRepository<TEntity, Tkey>(StroreDbContext _dbContext) : IGenricRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        #region GetAllAsync
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>()./*Include(P=>P.BrandNa)*/ToListAsync();

        #endregion

        #region GetByIdAsync
        public async Task<TEntity?> GetByIdAsync(Tkey id) => await _dbContext.Set<TEntity>().FindAsync(id);

        #endregion

        #region AddAsync
        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);

        #endregion

        #region Update
        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);

        #endregion

        #region Remove
        public void Remove(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        #endregion

        #region specification
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, Tkey> specification)
        {
            return await SpecificationElavautor.CreateQuery(_dbContext.Set<TEntity>(), specification).ToListAsync();
            //return await _dbContext.Set<TEntity>().Where(specification.Criteria).Include
        }

        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity, Tkey> specification)
        {
            return await SpecificationElavautor.CreateQuery(_dbContext.Set<TEntity>(), specification).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity, Tkey> specification)
        {
            return await SpecificationElavautor.CreateQuery(_dbContext.Set<TEntity>(), specification).CountAsync();
        }
        #endregion
    }
}
