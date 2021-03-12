using Microsoft.AspNetCore.Mvc;
using Styme.Service.Models.Results;
using System;

namespace Styme.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected ActionResult<Result> ReturnResult(Result result)
        {
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        protected ActionResult<Result> ReturnResult(Exception exception)
        {
            var result = new Result(exception);

            return BadRequest(result);
        }
    }
}
