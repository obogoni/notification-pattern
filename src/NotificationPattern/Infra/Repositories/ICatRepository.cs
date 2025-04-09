using NotificationPattern.Domain;

namespace NotificationPattern.Infra.Repositories;

public interface ICatRepository
{
    /// <summary>
    /// Adds a new cat to the repository.
    /// </summary>
    /// <param name="cat">The cat to add.</param>
    Task AddCat(Cat cat);

    /// <summary>
    /// Retrieves a cat by its name.
    /// </summary>
    /// <param name="name">The name of the cat.</param>
    /// <returns>The cat with the specified name, or null if not found.</returns>
    Task<Cat> GetCatByName(string name);

    /// <summary>
    /// Retrieves all cats in the repository.
    /// </summary>
    /// <returns>A list of all cats.</returns>
    Task<List<Cat>> GetAllCats();
}