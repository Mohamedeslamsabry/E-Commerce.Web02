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
        public ProductWithPrandAndTypeSpecification() : base(null!)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }
        public ProductWithPrandAndTypeSpecification(int id) : base(P=>P.Id == id)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);

        }
    }
}
