﻿using Microsoft.AspNetCore.Mvc;
using Styme.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Styme.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected ActionResult<ServiceResult> ReturnResult(ServiceResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        protected ActionResult<ServiceResult> ReturnResult(Exception exception)
        {
            var result = new ServiceResult(exception);

            return BadRequest(result);
        }
    }
}
