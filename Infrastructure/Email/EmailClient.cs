using Microsoft.Extensions.Logging;
using CSharpFunctionalExtensions;
using Resend;
using Domain.Types;

namespace Infrastructure.Email;

public class EmailClient(IResend resendClient, ILogger<EmailClient> logger) : IEmailClient
{

    #region

    private readonly IResend _resendClient = resendClient;
    private readonly ILogger<EmailClient> _logger = logger;

    #endregion


    public async Task<UnitResult<string>> SendEmailAsync(Email message, CancellationToken cancellationToken)
    {
        var emailMessage = new EmailMessage()
        {
            From = message.From,
            To = EmailAddressList.From(message.To),
            Subject = message.Subject,
            TextBody = message.TextBody,
        };
        try
        {
            var response = await _resendClient.EmailSendAsync(emailMessage, cancellationToken);
            if (response.Success)
                _logger.LogInformation(nameof(EmailClient) + " - Email send successfully with id: {EmailId}", response.Content);
            else
                _logger.LogWarning(nameof(EmailClient) + " - Email failed to send with error: @{EmailError}", response.Exception);
            return UnitResult.Success<string>();
        }
        catch (ResendException ex)
        {
            _logger.LogError(ex, $"{nameof(EmailClient)} - Exception caught: ");
            return UnitResult.Failure("Something went wrong.");
        }
    }
}
