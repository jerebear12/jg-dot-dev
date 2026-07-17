using CSharpFunctionalExtensions;
using Resend;

namespace Infrastructure.Email;

public static class ResendExtensions
{
    public static Result<T, ResendException> ToResult<T>(this ResendResponse<T> response)
    {
        return response.Success ?
            Result.Success<T, ResendException>(response.Content) :
            Result.Failure<T, ResendException>(response.Exception!);
    }
}
