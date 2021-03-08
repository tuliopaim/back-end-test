using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Domain.Entities
{
    public class Restaurant : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public Uri ImageUri { get; set; }

        public IEnumerable<Menu> Menus { get; set; }
    }
}
