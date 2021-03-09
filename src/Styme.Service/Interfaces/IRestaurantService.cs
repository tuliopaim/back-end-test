using Microsoft.AspNetCore.Mvc;
using Styme.Domain.Entities;
using Styme.Domain.Filters;
using Styme.Service.Models;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Service.Models.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Styme.Service.Interfaces
{
    public interface IRestaurantService
    {
        Task<ServiceResult> Add(NewRestaurantInputModel input);

        Task<ServiceResult> Update(UpdateRestaurantInputModel input);

        Task<ServiceResult> Delete(long id);

        Task<ServiceResult> Select();

        Task<ServiceResult> SelectById(long id);

        Task<PaginatedResult<RestaurantOutputModel>> SelectPaginated(PaginatedFilter filter);
    }
}
