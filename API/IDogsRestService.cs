using MyDoggyDetails.Models;


namespace MyDoggyDetails.API
{

    public interface IDogsRestService
    {

        public Task<BreedModel> GetAllBreedsAsync();

    }

}
