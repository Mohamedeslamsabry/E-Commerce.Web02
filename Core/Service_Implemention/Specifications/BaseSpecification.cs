using Domain_Layer.Contract;
using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Specifications
{
    public abstract class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        #region set Criteria
        protected BaseSpecification(Expression<Func<TEntity, bool>> CriteriaExpersion)
        {
            Criteria = CriteriaExpersion;
        } 
        #endregion

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        public List<Expression<Func<TEntity, object>>> IncudeExpression { get; } = [];
        /*= new List<Expression<Func<TEntity, object>>>();*/

        #region Set Include
        protected void AddInclude(Expression<Func<TEntity, object>> incudeExpression)
        {
            IncudeExpression.Add(incudeExpression);
        } 
        #endregion
    }
}
