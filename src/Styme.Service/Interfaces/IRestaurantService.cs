using Styme.Service.Models;
using Styme.Service.Models.InputModels;
using System.Threading.Tasks;

namespace Styme.Service.Interfaces
{
    public interface IRestaurantService
    {
        Task<ServiceResultModel> Add(NewRestaurantInputModel input);

        Task<ServiceResultModel> Update(UpdateRestaurantInputModel input);

        Task<ServiceResultModel> Delete(long id);

        Task<ServiceResultModel> Select();

        Task<ServiceResultModel> SelectById(long id);
    }
}
