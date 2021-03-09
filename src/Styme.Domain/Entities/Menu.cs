using System;

namespace Styme.Domain.Entities
{
    public class Menu : Entity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Uri ImageUri { get; set; }
        public string Category { get; set; }

        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
