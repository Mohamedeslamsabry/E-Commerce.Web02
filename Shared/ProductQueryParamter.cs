using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParamter
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingSpecifications productSorting { get; set; }
    }
}
