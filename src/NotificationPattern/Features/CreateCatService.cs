using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using NotificationPattern.Domain;
using NotificationPattern.Contracts;
using NotificationPattern.Infra.Repositories;

namespace NotificationPattern.Features
{
    public class CreateCatService : ICreateCatService
    {
        private readonly ICatRepository _catRepository;

        public CreateCatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Result<CreateCatResponse>> CreateCat(string name, int age, string favoriteToy, double whiskerLength, string napTime)
        {
            var catResult = Cat.Create(name, age, favoriteToy, whiskerLength, napTime);
            if (catResult.IsFailure) return Result.Failure<CreateCatResponse>(catResult.Error);

            var cat = catResult.Value;

            await _catRepository.AddCat(cat);

            return new CreateCatResponse(
                cat.Id,
                cat.Name,
                cat.Age,
                cat.FavoriteToy,
                cat.WhiskerLength.Value,
                cat.NapTime
            );
        }
    }
}

