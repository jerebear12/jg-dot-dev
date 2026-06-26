using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class RootController : Controller
    {

        #region Constants

        protected const char URL_PATH_SEPARATOR = '/';

        #endregion

        #region Protected Methods

        [NonAction]
        protected ObjectResult ToProblem(ProblemDetails problemDetails)
        {
            return Problem(
                detail: problemDetails.Detail,
                statusCode: problemDetails.Status,
                title: problemDetails.Title,
                type: problemDetails.Type
            );
        }

        #endregion

    }
}
