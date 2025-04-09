using CSharpFunctionalExtensions;

namespace NotificationPattern.Shared.Validator;

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
