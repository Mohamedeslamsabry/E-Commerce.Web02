using Domain_Layer.Contract;
using Domain_Layer.Models;
using Persistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Implment_Repo
{
    public class UnitOfWork(StroreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositry = [];
        public IGenricRepository<TEntity, Tkey> genricRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            // Get Type Name
            var TypeName = typeof(TEntity).Name;
            //if (_repositry.ContainsKey(TypeName))
            //{
            //    return (IGenricRepository<TEntity, Tkey>)_repositry[TypeName];
            //}
            if (_repositry.TryGetValue(TypeName, out object? value))
            {
                return (IGenricRepository<TEntity, Tkey>)value;
            }
            else
            {
                var Repo = new GenricRepository<TEntity, Tkey>(_dbContext);
                _repositry.Add(TypeName, Repo);
                return Repo;
            }
        }

        public async Task<int> SaveChanges() => await _dbContext.SaveChangesAsync();

    }
}
