using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Service.Models.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Styme.Service.Interfaces
{
    public interface IMenuService
    {
        Task<Result> Add(NewMenuInputModel input);

        Task<Result> Update(UpdateMenuInputModel input);

        Task<Result> Delete(long id);

        Task<IEnumerable<MenuOutputModel>> Select();

        Task<MenuOutputModel> SelectById(long id);
    }
}
