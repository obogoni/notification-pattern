namespace NotificationPattern.Contracts;

public class CreateCatRequest
{
    /// <summary>
    /// The name of the cat.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The age of the cat.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// The favorite toy of the cat.
    /// </summary>
    public string FavoriteToy { get; set; }

    /// <summary>
    /// The length of the cat's whiskers in cm.
    /// </summary>
    public double WhiskerLength { get; set; }

    /// <summary>
    /// The nap time of the cat in HH:mm format.
    /// </summary>
    public string NapTime { get; set; }
}


