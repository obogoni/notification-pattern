using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using NotificationPattern.Shared.Validator;

namespace NotificationPattern.Domain;

public class Cat
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string FavoriteToy { get; set; }

    public WhiskerLength WhiskerLength { get; set; }

    public string NapTime { get; set; }

    private Cat(Guid id, string name, int age, string favoriteToy, WhiskerLength whiskerLength, string napTime)
    {
        Id = id;
        Name = name;
        Age = age;
        FavoriteToy = favoriteToy;
        WhiskerLength = whiskerLength;
        NapTime = napTime;
    }

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
}
