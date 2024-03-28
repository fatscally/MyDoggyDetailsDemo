using MyDoggyDetails.Models;

namespace MyDoggyDetails.API
{
    public class DogItemManager 
    {

        DogsRestService restService;

        public DogItemManager(DogsRestService service)
        {
            restService = service;
        }


        public Task<BreedModel[]> GetAllBreeds()
        {
            return restService.GetAllBreedsAsync();
        }



    }


}
