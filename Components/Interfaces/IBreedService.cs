using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Interfaces;

public interface IBreedService
{
    Task<IEnumerable<BreedModel>> GetAllBreedsAsync();
    Task<BreedModel> GetBreedByIdAsync(int id);
    Task<IEnumerable<BreedModel>> RefreshBreedsFromApiAsync();
    Task SaveBreedsAsync();

    Task SaveBreedAsync(BreedModel breed);
    Task DownloadBreedImagesAsync(IEnumerable<BreedModel> breeds);
}
