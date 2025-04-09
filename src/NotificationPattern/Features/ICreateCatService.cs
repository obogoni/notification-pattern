using CSharpFunctionalExtensions;
using NotificationPattern.Contracts;
using NotificationPattern.Contracts;

namespace NotificationPattern.Features
{
    public interface ICreateCatService
    {
        /// <summary>
        /// Creates a new cat with the specified properties.
        /// </summary>
        /// <param name="name">The name of the cat.</param>
        /// <param name="age">The age of the cat.</param>
        /// <param name="favoriteToy">The favorite toy of the cat.</param>
        /// <param name="whiskerLength">The length of the cat's whiskers in cm.</param>
        /// <param name="napTime">The nap time of the cat in HH:mm format.</param>
        /// <returns>A CatOutputDto representing the created cat.</returns>
        Task<Result<CreateCatResponse>> CreateCat(string name, int age, string favoriteToy, double whiskerLength, string napTime);
    }
}

