using System.ComponentModel.DataAnnotations;

namespace Styme.Domain.Filters
{
    public class RestaurantPaginatedFilter
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; }

        public string Name { get; set; }

        public bool IncludeMenus { get; set; }

        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        public bool OrderByDesc { get; set; }

        public int StartIndex => (Page - 1) * PageSize;
    }
}
