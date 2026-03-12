using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.API;

public class DogItemManager : IDogApiService
{
  private readonly IDogsRestService _restService;

  public DogItemManager(IDogsRestService restService)
  {
    _restService = restService ?? throw new ArgumentNullException(nameof(restService));
  }

  public async Task<IEnumerable<BreedModel>> GetAllBreedsAsync()
  {
        var x = await _restService.GetAllBreedsAsync();
        return x;
  }


}