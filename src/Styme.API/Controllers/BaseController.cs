using Microsoft.AspNetCore.Mvc;
using Styme.Core.Results;
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

        protected ActionResult<Result<T>> ReturnResult<T>(
            Result<T> result)
        {
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        protected ActionResult<Result<T>> ReturnResult<T>(Exception exception)
        {
            var result = new Result(exception);

            return BadRequest(result);
        }
    }
}
