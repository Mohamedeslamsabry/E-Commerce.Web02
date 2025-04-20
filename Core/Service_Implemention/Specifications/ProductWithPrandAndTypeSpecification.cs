using Domain_Layer.Models;
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
        public ProductWithPrandAndTypeSpecification(int? BrandId, int? TypeId , ProductSortingSpecifications productSorting) :
            base(P => (!BrandId.HasValue || P.BrandId == BrandId) &&
                 (!TypeId.HasValue || P.TypeId == TypeId))

        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);

            switch (productSorting)
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

        }
        public ProductWithPrandAndTypeSpecification(int id) : base(P => P.Id == id)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);

        }
    }
}
