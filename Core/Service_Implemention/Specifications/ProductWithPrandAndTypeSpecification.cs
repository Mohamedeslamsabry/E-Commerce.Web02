using Domain_Layer.Models.Prpducts;
using Shared;
using Shared.Enums;
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
        public ProductWithPrandAndTypeSpecification(ProductQueryParamter productQuery) :
            base(P => (!productQuery.BrandId.HasValue || P.BrandId == productQuery.BrandId) &&
                 (!productQuery.TypeId.HasValue || P.TypeId == productQuery.TypeId)
            && (string.IsNullOrEmpty(productQuery.search) || P.Name.ToLower().Contains(productQuery.search.ToLower()))
            )

        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);

            switch (productQuery.sort)
            {
                case ProductSortingSpecifications.NameAsc:
                    SetOrdery(P => P.Name);
                    break;
                case ProductSortingSpecifications.NameDesc:
                    SetOrderyDesc(P => P.Name);
                    break;
                case ProductSortingSpecifications.PriceAsc:
                    SetOrdery(P => P.Price);
                    break;
                case ProductSortingSpecifications.PriceDesc:
                    SetOrderyDesc(P => P.Price);
                    break;
                default:
                    break;
            }

            ApplyPagention(productQuery.pageSize, productQuery.PageIndex);
        }

        //Get By Id
        public ProductWithPrandAndTypeSpecification(int id) : base(P => P.Id == id)
        {
            AddInclude(P => P.productBrand);
            AddInclude(P => P.productType);

        }
    }
}
