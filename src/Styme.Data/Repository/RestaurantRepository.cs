﻿using Microsoft.EntityFrameworkCore;
using Styme.Domain.Entities;
using Styme.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task Delete(long id)
        {
            var restaurant = await SelectById(id);
            _context.Remove(restaurant);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<Restaurant>> Select()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> SelectById(long id)
        {
            return await _context
                .Restaurants
                .FindAsync(id);
        }
    }
}