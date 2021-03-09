using AutoMapper;
using Styme.Domain.Entities;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Service.Models.Results;
using System.Linq;
using System.Threading.Tasks;

namespace Styme.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;
        private readonly IMapper _mapper;

        public MenuService(
            IMenuRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResult> Add(NewMenuInputModel input)
        {
            if (!input.IsValid)
            {
                return new ServiceResult(input.ValidationResult);
            }

            var restaurant = _mapper.Map<Menu>(input);

            await _repository.Insert(restaurant);

            return ServiceResult.SuccessResult();
        }

        public async Task<ServiceResult> Update(UpdateMenuInputModel input)
        {
            if (!input.IsValid)
            {
                return new ServiceResult(input.ValidationResult);
            }

            var restaurant = _mapper.Map<Menu>(input);

            await _repository.Update(restaurant);

            return ServiceResult.SuccessResult();
        }

        public async Task<ServiceResult> Delete(long id)
        {
            if (id <= 0)
            {
                ServiceResult.ErrorResult(message: "Id inválido");
            }

            if (await _repository.Delete(id))
            {
                return ServiceResult.SuccessResult(message: "Removido com sucesso");
            }

            return ServiceResult.ErrorResult(message: "Não encontrado");
        }

        public async Task<ServiceResult> Select()
        {
            var menus = await _repository.Select();

            var output = menus?.Select(_mapper.Map<MenuOutputModel>);

            return output is null
                ? ServiceResult.SuccessResult(message: "Nenhum registro encontrado")
                : ServiceResult.SuccessResult(data: output);
        }

        public async Task<ServiceResult> SelectById(long id)
        {
            if (id <= 0)
            {
                ServiceResult.ErrorResult(message: "Id inválido");
            }

            var menu = await _repository.SelectById(id);

            var output = _mapper.Map<MenuOutputModel>(menu);

            return output is null
                ? ServiceResult.SuccessResult(message: "Nenhum registro encontrado")
                : ServiceResult.SuccessResult(data: output);
        }
    }
}
