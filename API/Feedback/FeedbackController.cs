using Asp.Versioning;
using API.Controllers;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using API.Feedback.Submit;
using Infrastructure.Email;

namespace API.Feedback;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/" + ROUTE_NAME)]
public class FeedbackController(IEmailClient emailClient) : RootController
{

    #region Fields

    private readonly IEmailClient _resendClient = emailClient;
    private readonly string _myEmail = "blog@jeremiahgavin.dev";

    #endregion

    #region Constants

    private const string ROUTE_NAME = "feedback";

    #endregion

    #region Routes

    [HttpPost("submit")]
    public async Task<IActionResult> Submit(
        [FromForm] SubmitFeedbackRequest request,
        CancellationToken cancellationToken)
    {
        var message = new Email(
            _myEmail,
            $"{request.FullName}: {request.Subject}",
            request.Message + $"\n\n {request.Email}",
            [_myEmail]);

        var result = await _resendClient.SendEmailAsync(message, cancellationToken);

        return PartialView("_SubmitFeedbackResponse", new SubmitFeedbackModel(request.FullName, result.IsFailure ? result.Error : null));
    }

    #endregion

}
