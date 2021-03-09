using AutoMapper;
using Styme.Domain.Entities;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Models;
using Styme.Service.Models.InputModels;
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

        public async Task<ServiceResultModel> Add(NewRestaurantInputModel input)
        {
            if (!input.ItsValid)
            {
                //return erro
            }

            var restaurant = _mapper.Map<Restaurant>(input);

            await _repository.Insert(restaurant);

            return new ServiceResultModel();
        }

        public async Task<ServiceResultModel> Update(UpdateRestaurantInputModel input)
        {
            if (!input.ItsValid)
            {
                //return erro
            }

            var restaurant = _mapper.Map<Restaurant>(input);

            await _repository.Update(restaurant);

            return new ServiceResultModel();
        }

        public async Task<ServiceResultModel> Delete(long id)
        {
            if(id == 0)
            {
                //return erro
            }

            await _repository.Delete(id);

            return new ServiceResultModel();
        }

        public async Task<ServiceResultModel> Select()
        {
            var restaurants = await _repository.Select();

            return new ServiceResultModel();
        }

        public async Task<ServiceResultModel> SelectById(long id)
        {
            var restaurant = await _repository.SelectById(id);
        
            return new ServiceResultModel();
        }

    }
}
