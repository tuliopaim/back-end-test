using System;
using System.Collections.Generic;

namespace Styme.Service.Models.Results
{
    public class PaginatedResult<T>
    {
        /// <summary>
        /// Create a PaginatedResult
        /// </summary>
        /// <param name="results">List of the returned results</param>
        /// <param name="total">Total of results</param>
        /// <param name="page">Page number (starts at 1)</param>
        /// <param name="pageSize">Page Size</param>
        public PaginatedResult(IEnumerable<T> results = default, long total = 0, int page = 1, int pageSize = 10)
        {
            Results = results;
            Page = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
            Total = total;
        }

        public IEnumerable<T> Results { get; }

        public int PageSize { get; }

        public int Page { get; }

        public int TotalPages { get; }

        public long Total { get; }

        public bool HasPrevPage => Page > 1;

        public bool HasNextPage => Page < TotalPages;
    }
}
