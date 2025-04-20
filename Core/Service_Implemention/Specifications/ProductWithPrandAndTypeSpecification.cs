using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Specifications
{
    class ProductWithPrandAndTypeSpecification : BaseSpecification<Product, int>
    {
        //Get All Products Including Their Brand And Type 
        //_dbcontext.set<TEntity>().where(P=>P.BrandId == BrandId && P.TypeId == TypeId)
        public ProductWithPrandAndTypeSpecification(int? BrandId, int? TypeId) :
            base(P => (!BrandId.HasValue || P.BrandId == BrandId) &&
                 (!TypeId.HasValue || P.TypeId == TypeId))

        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }
        public ProductWithPrandAndTypeSpecification(int id) : base(P => P.Id == id)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);

        }
    }
}
