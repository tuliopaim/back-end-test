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
        void Insert(Menu menu);

        void Update(Menu menu);

        void Delete(Menu menu);

        IList<Menu> Select();

        Menu SelectById(long id);
    }
}
