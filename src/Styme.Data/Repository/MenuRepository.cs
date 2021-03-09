using Microsoft.EntityFrameworkCore;
using Styme.Domain.Entities;
using Styme.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Data.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly StymeContext _context;

        public MenuRepository(StymeContext context)
        {
            _context = context;
        }
        public async Task Insert(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Menu menu)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Menu>> Select()
        {
            throw new NotImplementedException();
        }

        public async Task<Menu> SelectById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
