using Styme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Domain.Interfaces.Repository
{
    public interface IRestaurantRepository
    {
        void Insert(Restaurant restaurant);

        void Update(Restaurant restaurant);

        void Delete(Restaurant restaurant);

        IList<Restaurant> Select();

        Restaurant SelectById(long id);
    }
}
