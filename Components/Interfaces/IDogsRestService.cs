using MyDoggyDetails.Models;


namespace MyDoggyDetails.Interfaces;


public interface IDogsRestService
{

    Task<IEnumerable<BreedModel>> GetAllBreedsAsync();

}
