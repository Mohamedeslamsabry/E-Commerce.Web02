using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Contract
{
    public interface ISpecification<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Expression<Func<TEntity, bool>> Criteria { get; } // Where
        List<Expression<Func<TEntity, object>>> IncudeExpression { get; }//ListOfIncude 
                                                                         //object => Once ProductBrand AnotherOnce => ProductType

        #region OrderBy
        Expression<Func<TEntity, object>> OrderBy { get; }
        Expression<Func<TEntity, object>> OrderByDesc { get; }
        #endregion

        #region Pagenation
        public int Skip { get;}
        public int Take { get;}
        public bool IsPaginate { get; set; }
        #endregion
    }
}
