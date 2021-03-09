using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Domain.Filters
{
    public class PaginatedFilter
    {
        private int _page;

        public int Page
        {
            get => _page;

            set => _page = value == 0 ? 1 : value;
        }

        public string SearchTerm { get; set; }

        public int PageSize { get; set; }

        public bool OrderByDesc { get; set; }

        public int StartIndex => (Page - 1) * PageSize;
    }
}
