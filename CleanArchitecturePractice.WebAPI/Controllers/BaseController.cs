using CleanArchitecturePractice.Shared.Abstractions.Commands;
using CleanArchitecturePractice.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecturePractice.WebAPI.Controllers
{
    [ApiController]
    public abstract class BaseController: ControllerBase
    {
        protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
        {
            return result is null ? NotFound() : Ok(result);
        }
    }
}
