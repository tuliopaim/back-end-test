﻿using Microsoft.AspNetCore.Mvc;
using Styme.Core.Results;
using Styme.Domain.Filters;
using Styme.Service.Interfaces;
using Styme.Service.Models.InputModels;
using Styme.Service.Models.OutputModels;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<Result>> Create([FromBody] NewRestaurantInputModel input)
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
        public async Task<ActionResult<Result>> Update([FromBody] UpdateRestaurantInputModel input)
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
        /// Busca todos os restaurantes
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<RestaurantOutputModel>>>> Get()
        {
            try
            {
                var result = await _service.Select();

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult<IEnumerable<RestaurantOutputModel>>(ex);
            }
        }

        /// <summary>
        /// Busca um restaurante por Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<RestaurantOutputModel>>> GetById(long id)
        {
            try
            {
                var result = await _service.SelectById(id);

                return ReturnResult(result);
            }
            catch (Exception ex)
            {
                return ReturnResult<RestaurantOutputModel>(ex);
            }
        }

        /// <summary> 
        /// Busca restaurantes de forma paginada, filtrando e ordenando por Name
        /// </summary>
        [HttpPost("paginated-filter")]
        public async Task<ActionResult<PaginatedResult<RestaurantOutputModel>>> GetPaginated([FromBody] RestaurantPaginatedFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _service.SelectPaginated(filter);            
        }
    }
}
