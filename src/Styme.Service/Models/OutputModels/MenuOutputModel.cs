using System;

namespace Styme.Service.Models.OutputModels
{
    public class MenuOutputModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Uri ImageUri { get; set; }
        public string Category { get; set; }

        public long RestaurantId { get; set; }
    }
}
