using MyDoggyDetails.Models;

namespace MyDoggyDetails.Interfaces;

public interface IDogApiService
{
    IEnumerable<BreedModel> GetAllBreeds();
}