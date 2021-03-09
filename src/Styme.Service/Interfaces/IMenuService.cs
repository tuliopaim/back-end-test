using Styme.Service.Models.InputModels;
using Styme.Service.Models.Results;
using System.Threading.Tasks;

namespace Styme.Service.Interfaces
{
    public interface IMenuService
    {
        Task<ServiceResult> Add(NewMenuInputModel input);

        Task<ServiceResult> Update(UpdateMenuInputModel input);

        Task<ServiceResult> Delete(long id);

        Task<ServiceResult> Select();

        Task<ServiceResult> SelectById(long id);
    }
}
