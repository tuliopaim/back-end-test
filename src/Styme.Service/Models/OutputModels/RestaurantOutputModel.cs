using System;
using System.Collections.Generic;

namespace Styme.Service.Models.OutputModels
{
    public class RestaurantOutputModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public Uri ImageUri { get; set; }

        public IEnumerable<MenuOutputModel> Menus { get; set; }
    }
}
