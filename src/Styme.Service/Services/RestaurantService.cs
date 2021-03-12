using AutoMapper;
using Styme.Domain.Entities;
using Styme.Domain.Filters;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Service.Models.Results;
using System.Collections;
using System.Collections.Generic;
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

        public async Task<Result> Add(NewRestaurantInputModel input)
        {
            if (!input.IsValid)
            {
                return new Result(input.ValidationResult);
            }

            var restaurant = _mapper.Map<Restaurant>(input);

            await _repository.Insert(restaurant);

            return Result.SuccessResult();
        }

        public async Task<Result> Update(UpdateRestaurantInputModel input)
        {
            if (!input.IsValid)
            {
                return new Result(input.ValidationResult);
            }

            var restaurant = _mapper.Map<Restaurant>(input);

            await _repository.Update(restaurant);

            return Result.SuccessResult();
        }

        public async Task<Result> Delete(long id)
        {
            if(id <= 0)
            {
                return Result.ErrorResult(message: "Id inválido");
            }

            if(await _repository.Delete(id))
            {
                return Result.SuccessResult(message: "Removido com sucesso");
            }

            return Result.ErrorResult(message: "Não encontrado");
        }

        public async Task<Result<IEnumerable<RestaurantOutputModel>>> Select()
        {
            var restaurants = await _repository.Select();

            var output = restaurants?.Select(_mapper.Map<RestaurantOutputModel>);

            output ??= new List<RestaurantOutputModel>();

            return Result<IEnumerable<RestaurantOutputModel>>.SuccessResult(output);
        }

        public async Task<Result<RestaurantOutputModel>> SelectById(long id)
        {
            if (id <= 0)
            {
                return Result<RestaurantOutputModel>
                    .ErrorResult()
                    .AddError("Id inválido!");
            }

            var restaurant = await _repository.SelectById(id);

            var output = _mapper.Map<RestaurantOutputModel>(restaurant);

            return Result<RestaurantOutputModel>.SuccessResult(output);
        }

        public async Task<PaginatedResult<RestaurantOutputModel>> SelectPaginated(RestaurantPaginatedFilter filter)
        {
            var total = await _repository.TotalWithFilter(filter);
            var results = await _repository.SelectPaginated(filter);

            return new PaginatedResult<RestaurantOutputModel>(
                results?.Select(_mapper.Map<RestaurantOutputModel>),
                total,
                filter);
        }
    }
}
