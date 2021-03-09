using Microsoft.EntityFrameworkCore;
using Styme.Domain.Entities;
using Styme.Domain.Filters;
using Styme.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Styme.Data.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly StymeContext _context;

        public RestaurantRepository(StymeContext context)
        {
            _context = context;
        }

        public async Task Insert(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(long id)
        {
            var restaurant = await SelectById(id);

            if (restaurant is not null)
            {
                _context.Remove(restaurant);
            }
            
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IList<Restaurant>> Select()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> SelectById(long id)
        {
            return await _context
                .Restaurants
                .Include(r => r.Menus)
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Restaurant>> SelectPaginated(RestaurantPaginatedFilter filter)
        {
            var query = _context
                .Restaurants
                .AsQueryable<Restaurant>();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(r => r.Name.Contains(filter.Name));
            }

            if (filter.IncludeMenus)
            {
                query = query.Include(r => r.Menus);
            }

            if (filter.OrderByDesc)
            {
                query = query.OrderByDescending(r => r.Name);
            }
            else
            {
                query = query.OrderBy(r => r.Name);
            }

            return await query
                .Skip(filter.StartIndex)
                .Take(filter.PageSize)
                .ToListAsync();
        }

        public async Task<long> TotalWithFilter(RestaurantPaginatedFilter filter)
        {
            return await _context
                .Restaurants
                .Where(r => r.Name.Contains(filter.Name))
                .CountAsync();
        }
    }
}
