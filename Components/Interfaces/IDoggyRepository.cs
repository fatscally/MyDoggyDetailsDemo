using MyDoggyDetails.Models;

namespace MyDoggyDetails.Interfaces;

public interface IDoggyRepository
{
    Task<long> SaveAsync(DoggyModel model);
    Task<IEnumerable<DoggyModel>> GetAllDoggiesAsync();
    Task CreateDatabaseAsync();
    Task SeedDoggyDataAsync();
}
