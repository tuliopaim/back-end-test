using Microsoft.AspNetCore.Mvc;
using Styme.Core.Results;
using Styme.Service.Interfaces;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Styme.API.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cria um novo menu
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] NewMenuInputModel input)
        {
            try
            {
                var result = await _service.Add(input);

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult(ex);
            }
        }

        /// <summary>
        /// Atualiza um menu existente
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<Result>> Update([FromBody] UpdateMenuInputModel input)
        {
            try
            {
                var result = await _service.Update(input);

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult(ex);
            }
        }

        /// <summary>
        /// Deleta um menu existente
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(long id)
        {
            try
            {
                var result = await _service.Delete(id);

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult(ex);
            }
        }

        /// <summary>
        /// Busca todos os menus
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<MenuOutputModel>>>> Get()
        {
            try
            {
                var result = await _service.Select();

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult<IEnumerable<MenuOutputModel>>(ex);
            }
        }

        /// <summary>
        /// Busca um menu por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<MenuOutputModel>>> GetById(long id)
        {
            try
            {
                var result = await _service.SelectById(id);

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult<MenuOutputModel>(ex);
            }
        }
    }
}
