using EmailValidation;
using CSharpFunctionalExtensions;

namespace Domain.Types;

public class Email
{
    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; init; }

    public static Result<Email> Create(string value)
    {
        var allowTopLevelDomains = true;
        var allowInternationalEmailAddresses = true;
        var isValid = EmailValidator.TryValidate(value, allowTopLevelDomains, allowInternationalEmailAddresses, out var error);
        if (!isValid) return Result.Failure<Email>($"Email is invalid. Error code: {error.Code}");
        return new Email(value);
    }
}
