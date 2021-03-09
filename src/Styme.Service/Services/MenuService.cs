using AutoMapper;
using Styme.Domain.Entities;
using Styme.Domain.Interfaces.Repository;
using Styme.Service.Interfaces;
using Styme.Service.Models;
using Styme.Service.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (id == 0)
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

            return ServiceResult.SuccessResult(data: menus);
        }

        public async Task<ServiceResult> SelectById(long id)
        {
            var menu = await _repository.SelectById(id);

            return ServiceResult.SuccessResult(data: menu);
        }
    }
}
