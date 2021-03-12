using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Styme.Service.Interfaces
{
    public interface IMenuService
    {
        Task<Result> Add(NewMenuInputModel input);

        Task<Result> Update(UpdateMenuInputModel input);

        Task<Result> Delete(long id);

        Task<Result<IEnumerable<MenuOutputModel>>> Select();

        Task<Result<MenuOutputModel>> SelectById(long id);
    }
}
