using Styme.Domain.Entities;
using Styme.Domain.Filters;
using System.Collections.Generic;
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

        Task<List<Restaurant>> SelectPaginated(RestaurantPaginatedFilter filter);

        Task<long> TotalWithFilter(RestaurantPaginatedFilter filter);
    }
}
