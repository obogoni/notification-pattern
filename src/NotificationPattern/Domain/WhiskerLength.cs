using CSharpFunctionalExtensions;

namespace NotificationPattern.Domain;

public class WhiskerLength : ValueObject
{
    public double Value { get; }

    private WhiskerLength(double value)
    {
        Value = value;
    }

    public static Result<WhiskerLength> Create(double value)
    {
        if (value < 1.0 || value > 20.0)
        {
            return Result.Failure<WhiskerLength>("Whisker Length must be between 1.0 and 20.0 cm.");
        }

        return Result.Success(new WhiskerLength(value));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

