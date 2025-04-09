# Notification Pattern

A basic implementation of the Notification Pattern, as defined by [Martin Fowler](https://www.martinfowler.com/eaaDev/Notification.html), but somewhat adapted to my needs.

## implementation details

Result Pattern with [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions), where the Result object is used like the "NotificiationError" object that stores the validation errors:
```c#
public class Validator
{
    private readonly List<Result> results = new List<Result>();

    public void Add(bool validCondition, string message)
    {
        if (!validCondition)
        {
            results.Add(Result.Failure(message));
        }
    }

    public Result GetResult()
    {
        return Result.Combine(results);
    }
}
```
Clean Architecture to keep validation logic in the domain layer:
```c#
public static Result<Cat> Create(string name, int age, string favoriteToy, double whiskerLength, string napTime)
{
    var validator = new Validator();

    validator.Add(!string.IsNullOrWhiteSpace(name), "Name is required");
    validator.Add(name?.Length <= 50, "Name cannot be longer than 50 characters.");
    validator.Add(age < 0, "Age must be higher than 0.");
    validator.Add(age <= 30, "Cats don't live that long! (max: 30).");
    validator.Add(!string.IsNullOrWhiteSpace(favoriteToy), "Favorite toy is required");
    validator.Add(favoriteToy?.Length >= 3, "Favorite toy must be at least 3 characters long");

    var whiskerLengthResult = WhiskerLength.Create(whiskerLength);

    validator.Add(whiskerLengthResult.IsSuccess, whiskerLengthResult.Error);
    validator.Add(Regex.IsMatch(napTime, @"^(?:[01]\d|2[0-3]):[0-5]\d$"), "Nap Time must be in HH:mm format");

    var result = validator.GetResult();
    if (result.IsFailure) return Result.Failure<Cat>(result.Error);

    return Result.Success(
        new Cat(
          Guid.NewGuid(),
          name!,
          age,
          favoriteToy!,
          whiskerLengthResult.Value,
          napTime)
        );
}
``` 
REST API as the presentation layer, where the Result objet with combined errors is translated to a "http result":
```c#
using CSharpFunctionalExtensions;
using IResult = Microsoft.AspNetCore.Http.IResult;

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
```
## How to test

1. Start the app

```bash
dotnet run
```

2. Test with Swagger
