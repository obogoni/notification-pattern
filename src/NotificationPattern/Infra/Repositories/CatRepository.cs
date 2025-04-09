using NotificationPattern.Domain;

namespace NotificationPattern.Infra.Repositories;

public class CatRepository : ICatRepository
{
    private static readonly List<Cat> Cats = new List<Cat>();

    public Task AddCat(Cat cat)
    {
        Cats.Add(cat);

        return Task.CompletedTask;
    }

    public Task<Cat> GetCatByName(string name)
    {
        return Task.FromResult(Cats.FirstOrDefault(cat => cat.Name == name));
    }

    public Task<List<Cat>> GetAllCats()
    {
        return Task.FromResult(new List<Cat>(Cats));
    }
}