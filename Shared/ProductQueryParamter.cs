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
        public ProductSortingSpecifications sort { get; set; }
        public string? search { get; set; }

        #region pagention
        private const int DeafultPageSize = 5;
        private const int MaxPageSize = 10;
        public int PageIndex { get; set; } = 1;

        private int PageSize = DeafultPageSize;

        public int pageSize
        {
            get { return PageSize; }
            set { PageSize = value > MaxPageSize ? DeafultPageSize : value; }
        }
        #endregion
    }
}
