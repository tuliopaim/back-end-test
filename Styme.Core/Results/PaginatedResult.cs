using Styme.Core.Filters;
using System;
using System.Collections.Generic;

namespace Styme.Core.Results
{
    public class PaginatedResult<T> : Result<IEnumerable<T>>
    {
        /// <summary>
        /// Create a PaginatedResult
        /// </summary>
        /// <param name="data">IEnumerable<T> results</param>
        /// <param name="total">Total items</param>
        /// <param name="page">Page number (>=1)</param>
        /// <param name="pageSize">Page Size</param>
        
        public PaginatedResult(
            IEnumerable<T> data,
            long total,
            PaginatedFilter filter)
        {
            Data = data;
            Page = filter.Page;
            Total = total;
            PageSize = filter.PageSize == default
                ? 1
                : filter.PageSize;
            TotalPages = (int)Math.Ceiling(Total / (double)PageSize);
        }

        public int PageSize { get; }

        public int Page { get; }

        public int TotalPages { get; }

        public long Total { get; }

        public bool HasPrevPage => Page > 1;

        public bool HasNextPage => Page < TotalPages;
    }
}
