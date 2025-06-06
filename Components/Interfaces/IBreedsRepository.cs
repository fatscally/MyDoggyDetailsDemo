using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Interfaces;

public interface IBreedsRepository
{
    Task CreateDatabaseAsync();
    Task<IEnumerable<BreedModel>> GetAllBreedsAsync();
    Task<long> SaveAsync(BreedModel model);

    Task<BreedModel> GetByIdAsync(int id);

    Task InsertListAsync(IEnumerable<BreedModel> list);
}
