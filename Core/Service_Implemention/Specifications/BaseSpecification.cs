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


        #region Order By
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }
        #endregion

        #region Order By (Set)

        protected void SetOrdery(Expression<Func<TEntity, object>> orderBy)
        {
            OrderBy = orderBy;
        }

        protected void SetOrderyDesc(Expression<Func<TEntity, object>> orderByDesc)
        {
            OrderByDesc = orderByDesc;
        } 
        #endregion

        #region Set Include
        protected void AddInclude(Expression<Func<TEntity, object>> incudeExpression)
        {
            IncudeExpression.Add(incudeExpression);
        } 
        #endregion
    }
}
