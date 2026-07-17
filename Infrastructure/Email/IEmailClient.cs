using CSharpFunctionalExtensions;

namespace Infrastructure.Email;

public interface IEmailClient
{
    public Task<UnitResult<string>> SendEmailAsync(Email message, CancellationToken cancellationToken);
}
