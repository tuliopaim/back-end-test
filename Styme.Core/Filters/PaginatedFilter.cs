using System.ComponentModel.DataAnnotations;

namespace Styme.Core.Filters
{
    public class PaginatedFilter
    {
        private int _page;
        private int _pageSize;

        [Range(1, int.MaxValue)]
        public int Page
        {
            get => _page == default ? 1 : _page;
            set => _page = value;
        }

        [Range(1, int.MaxValue)]
        public int PageSize
        {
            get => _pageSize == default ? 1 : _pageSize;
            set => _pageSize = value;
        }

        public bool OrderByDesc { get; set; }

        public int StartIndex => (Page - 1) * PageSize;
    }
}