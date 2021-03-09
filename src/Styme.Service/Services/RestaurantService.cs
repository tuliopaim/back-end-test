﻿using AutoMapper;
using Styme.Domain.Entities;
using Styme.Domain.Filters;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Service.Models.Results;
using System.Linq;
using System.Threading.Tasks;

namespace Styme.Service.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;
        private readonly IMapper _mapper;

        public RestaurantService(
            IRestaurantRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResult> Add(NewRestaurantInputModel input)
        {
            if (!input.IsValid)
            {
                return new ServiceResult(input.ValidationResult);
            }

            var restaurant = _mapper.Map<Restaurant>(input);

            await _repository.Insert(restaurant);

            return ServiceResult.SuccessResult();
        }

        public async Task<ServiceResult> Update(UpdateRestaurantInputModel input)
        {
            if (!input.IsValid)
            {
                return new ServiceResult(input.ValidationResult);
            }

            var restaurant = _mapper.Map<Restaurant>(input);

            await _repository.Update(restaurant);

            return ServiceResult.SuccessResult();
        }

        public async Task<ServiceResult> Delete(long id)
        {
            if(id <= 0)
            {
                return ServiceResult.ErrorResult(message: "Id inválido");
            }

            if(await _repository.Delete(id))
            {
                return ServiceResult.SuccessResult(message: "Removido com sucesso");
            }

            return ServiceResult.ErrorResult(message: "Não encontrado");
        }

        public async Task<ServiceResult> Select()
        {
            var restaurants = await _repository.Select();

            var output = restaurants?.Select(_mapper.Map<RestaurantOutputModel>);

            return output is null
                ? ServiceResult.SuccessResult(message: "Nenhum registro encontrado")
                : ServiceResult.SuccessResult(data: output);
        }

        public async Task<ServiceResult> SelectById(long id)
        {
            if (id <= 0)
            {
                return ServiceResult.ErrorResult(message: "Id inválido");
            }

            var restaurant = await _repository.SelectById(id);

            var output = _mapper.Map<RestaurantOutputModel>(restaurant);

            return output is null
                ? ServiceResult.SuccessResult(message: "Nenhum registro encontrado")
                : ServiceResult.SuccessResult(data: output);
        }

        public async Task<PaginatedResult<RestaurantOutputModel>> SelectPaginated(RestaurantPaginatedFilter filter)
        {
            var total = await _repository.TotalWithFilter(filter);
            var results = await _repository.SelectPaginated(filter);

            return new PaginatedResult<RestaurantOutputModel>(
                results: results?.Select(_mapper.Map<RestaurantOutputModel>),
                total: total,
                page: filter.Page,
                pageSize: filter.PageSize);
        }
    }
}
