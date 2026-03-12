using MyDoggyDetails.Models;

namespace MyDoggyDetails.Interfaces;

public interface IDogApiService
{
    Task<IEnumerable<BreedModel>> GetAllBreedsAsync();
}