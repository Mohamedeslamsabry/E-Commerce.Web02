using Domain_Layer.Contract;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Specification
{
    public static class SpecificationElavautor
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, Tkey>(IQueryable<TEntity> StartQuery, ISpecification<TEntity, Tkey> specification) where TEntity : BaseEntity<Tkey>
        {
            var Query = StartQuery;
            if (specification.Criteria is not null)
            {
                Query = Query.Where(specification.Criteria);
            }

            if(specification.OrderBy is not null)
            {
                Query = Query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDesc is not null)
            {
                Query = Query.OrderByDescending(specification.OrderByDesc);
            }

            if (specification.IncudeExpression is not null && specification.IncudeExpression.Count() > 0)
            {
                //foreach (var spec in specification.IncudeExpression)                
                //    Query = Query.Include(spec);

                Query = specification.IncudeExpression.Aggregate(Query, (Current, IncludeExp) => Current.Include(IncludeExp));

            }
            if (specification.IsPaginate)
            {
                Query = Query.Skip(specification.Skip).Take(specification.Take);
            }
            return Query;
        }
    }
}
