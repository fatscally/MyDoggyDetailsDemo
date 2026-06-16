using MyDoggyDetails.Models;

namespace MyDoggyDetails.Interfaces;

public interface IBreedService
{
    Task<IEnumerable<BreedModel>> GetAllBreedsAsync();
    Task<BreedModel> GetBreedByIdAsync(int id);
    Task<IEnumerable<BreedModel>> RefreshBreedsFromApiAsync();
    Task SaveBreedsAsync(IEnumerable<BreedModel> breeds);
}
