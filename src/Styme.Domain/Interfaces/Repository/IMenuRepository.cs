using Styme.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Styme.Domain.Interfaces.Repository
{
    public interface IMenuRepository
    {
        Task Insert(Menu menu);

        Task Update(Menu menu);

        Task<bool> Delete(long id);

        Task<IList<Menu>> Select();

        Task<Menu> SelectById(long id);
    }
}
