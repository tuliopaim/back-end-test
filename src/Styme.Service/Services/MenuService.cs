using AutoMapper;
using Styme.Domain.Entities;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Service.Models.Results;
using System.Collections.Generic;
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

        public async Task<Result> Add(NewMenuInputModel input)
        {
            if (!input.IsValid)
            {
                return new Result(input.ValidationResult);
            }

            var restaurant = _mapper.Map<Menu>(input);

            await _repository.Insert(restaurant);

            return Result.SuccessResult();
        }

        public async Task<Result> Update(UpdateMenuInputModel input)
        {
            if (!input.IsValid)
            {
                return new Result(input.ValidationResult);
            }

            var restaurant = _mapper.Map<Menu>(input);

            await _repository.Update(restaurant);

            return Result.SuccessResult();
        }

        public async Task<Result> Delete(long id)
        {
            if (id <= 0)
            {
                return Result.ErrorResult(message: "Id inválido");
            }

            if (await _repository.Delete(id))
            {
                return Result.SuccessResult(message: "Removido com sucesso");
            }

            return Result.ErrorResult(message: "Não encontrado");
        }

        public async Task<Result<IEnumerable<MenuOutputModel>>> Select()
        {
            var menus = await _repository.Select();

            var output = menus?.Select(_mapper.Map<MenuOutputModel>);

            output ??= new List<MenuOutputModel>();

            return Result<IEnumerable<MenuOutputModel>>.SuccessResult(output);
        }

        public async Task<MenuOutputModel> SelectById(long id)
        {
            if (id <= 0)
            {
                return Result.ErrorResult(message: "Id inválido");
            }

            var menu = await _repository.SelectById(id);

            var output = _mapper.Map<MenuOutputModel>(menu);

            return Result<MenuOutputModel>.SuccessResult(output);
        }
    }
}
