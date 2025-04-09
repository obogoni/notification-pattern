namespace NotificationPattern.Contracts;

public class CreateCatResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string FavoriteToy { get; set; }
    public double WhiskerLength { get; set; }
    public string NapTime { get; set; }

    public CreateCatResponse(Guid id, string name, int age, string favoriteToy, double whiskerLength, string napTime)
    {
        Id = id;
        Name = name;
        Age = age;
        FavoriteToy = favoriteToy;
        WhiskerLength = whiskerLength;
        NapTime = napTime;
    }
}

