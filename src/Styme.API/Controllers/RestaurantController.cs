using Microsoft.AspNetCore.Mvc;
using Styme.Domain.Filters;
using Styme.Service.Interfaces;
using Styme.Service.Models;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using Styme.Service.Models.Results;
using System;
using System.Threading.Tasks;

namespace Styme.API.Controllers
{    
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cria um novo restaurante
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ServiceResult>> Create([FromBody] NewRestaurantInputModel input)
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
        /// Atualiza um restaurante existente
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<ServiceResult>> Update([FromBody] UpdateRestaurantInputModel input)
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
        /// Deleta um restaurante existente
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult>> Delete(long id)
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
        /// Busca todos os restaurantes
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ServiceResult>> Get()
        {
            try
            {
                var result = await _service.Select();

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult(ex);
            }
        }

        /// <summary>
        /// Busca um restaurante por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult>> GetById(long id)
        {
            try
            {
                var result = await _service.SelectById(id);

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("paginated-filter")]
        public async Task<ActionResult<PaginatedResult<RestaurantOutputModel>>> GetPaginated([FromBody] PaginatedFilter filter)
        {
            return await _service.SelectPaginated(filter);
        }
    }
}
