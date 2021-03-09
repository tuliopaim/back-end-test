﻿using Styme.Domain.Entities;
using Styme.Service.Models;
using Styme.Service.Models.InputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Styme.Service.Interfaces
{
    public interface IRestaurantService
    {
        Task<ServiceResult> Add(NewRestaurantInputModel input);

        Task<ServiceResult> Update(UpdateRestaurantInputModel input);

        Task<ServiceResult> Delete(long id);

        Task<ServiceResult> Select();

        Task<ServiceResult> SelectById(long id);
    }
}