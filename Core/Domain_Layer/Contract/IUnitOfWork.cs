using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Contract
{
    public interface IUnitOfWork
    {
        //public IGenricRepository<Product,int> genricRepository { get; }
        IGenricRepository<TEntity, Tkey> genricRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;

        Task<int> SaveChanges();
    }
}
