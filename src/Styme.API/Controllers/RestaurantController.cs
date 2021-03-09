﻿using Microsoft.AspNetCore.Mvc;
using Styme.Domain.Entities;
using Styme.Service.Interfaces;
using Styme.Service.Models;
using Styme.Service.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}