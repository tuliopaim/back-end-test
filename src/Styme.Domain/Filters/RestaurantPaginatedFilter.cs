namespace Styme.Domain.Filters
{
    public class RestaurantPaginatedFilter
    {
        private int _page;

        public int Page
        {
            get => _page;

            set => _page = value == 0 ? 1 : value;
        }

        public string Name { get; set; }

        public bool IncludeMenus { get; set; }

        public int PageSize { get; set; }

        public bool OrderByDesc { get; set; }

        public int StartIndex => (Page - 1) * PageSize;
    }
}
