using Domain_Layer.Models;
using Shared.Enums;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Implemention.Specifications
{
    public class ProductCountSpecification : BaseSpecification<Product, int>
    {
        public ProductCountSpecification(ProductQueryParamter productQuery) :
            base(P => (!productQuery.BrandId.HasValue || P.BrandId == productQuery.BrandId) &&
                 (!productQuery.TypeId.HasValue || P.TypeId == productQuery.TypeId)
            && (string.IsNullOrEmpty(productQuery.SearchValue) || P.Name.ToLower().Contains(productQuery.SearchValue.ToLower()))
            )

        {


            
        }
    }
}
