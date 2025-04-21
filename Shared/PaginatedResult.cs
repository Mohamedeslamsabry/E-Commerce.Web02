using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PaginatedResult<TEntity>
    {
        public PaginatedResult(int totalCount, int pageSize, int pageIndex, IEnumerable<TEntity> data)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;
            Data = data;
        }

        public int TotalCount { get; set; }
        public int PageSize  { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}
