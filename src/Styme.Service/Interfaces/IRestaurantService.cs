using Styme.Domain.Filters;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Service.Models.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Styme.Service.Interfaces
{
    public interface IRestaurantService
    {
        Task<Result> Add(NewRestaurantInputModel input);

        Task<Result> Update(UpdateRestaurantInputModel input);

        Task<Result> Delete(long id);

        Task<Result<IEnumerable<RestaurantOutputModel>>> Select();

        Task<Result<RestaurantOutputModel>> SelectById(long id);

        Task<PaginatedResult<RestaurantOutputModel>> SelectPaginated(RestaurantPaginatedFilter filter);
    }
}
