using Styme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Domain.Interfaces.Repository
{
    public interface IMenuRepository
    {
        Task Insert(Menu menu);

        Task Update(Menu menu);

        Task Delete(long id);

        Task<IList<Menu>> Select();

        Task<Menu> SelectById(long id);
    }
}
