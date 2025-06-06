using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.API;

public class DogItemManager : IDogApiService
{

    private readonly IDogsRestService _restService;

    public DogItemManager(IDogsRestService service)
    {
        _restService = service;
    }


    public IEnumerable<BreedModel> GetAllBreeds()
    {
        return _restService.GetAllBreedsAsync().Result;
    }


}
