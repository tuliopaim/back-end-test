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
        Task Insert(Restaurant restaurant);

        Task Update(Restaurant restaurant);

        Task<bool> Delete(long id);

        Task<IList<Restaurant>> Select();

        Task<Restaurant> SelectById(long id);
    }
}
