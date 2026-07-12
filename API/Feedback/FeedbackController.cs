using Asp.Versioning;
using API.Controllers;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using API.Feedback.Submit;

namespace API.Feedback;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/" + ROUTE_NAME)]
public class FeedbackController : RootController
{

    #region Constants

    private const string ROUTE_NAME = "feedback";

    #endregion

    #region Routes

    [HttpPost("submit")]
    public async Task<IActionResult> Submit(
        [FromForm] SubmitFeedbackRequest request,
        CancellationToken cancellationToken)
    {
        return PartialView("_SubmitFeedbackResponse", new SubmitFeedbackModel(request.FullName));
    }

    #endregion

}
