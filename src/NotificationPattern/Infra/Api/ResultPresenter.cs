using CSharpFunctionalExtensions;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace NotificationPattern.Infra.Api;


public static class ResultPresenter
{
    public static IResult ToHttpResult<T>(Result<T> result)
    {
        if (result.IsFailure)
        {
            var errors = result.Error.Split(Result.Configuration.ErrorMessagesSeparator);

            return Results.BadRequest(errors);
        }
        else
        {
            return Results.Ok(result.Value);
        }
    }
}
