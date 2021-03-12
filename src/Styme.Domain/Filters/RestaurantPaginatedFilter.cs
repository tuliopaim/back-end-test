using Styme.Core.Filters;

namespace Styme.Domain.Filters
{
    public class RestaurantPaginatedFilter : PaginatedFilter
    {
        public string Name { get; set; }

        public bool IncludeMenus { get; set; }
    }
}
