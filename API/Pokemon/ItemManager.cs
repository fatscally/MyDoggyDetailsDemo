using MyDoggyDetails.Models;

namespace MyDoggyDetails.API;

public class ItemManager
{

    IRestService restService;

    public ItemManager(IRestService service)
    {
        restService = service;
    }


    public Task<PokemonHeader> GetPokemonHeadersAsync()
    {
        //Task<PokemonHeader> task;

        return restService.GetPokemonHeadersAsync();

        //PokemonHeader ph = task.Result;

        //return task;
    }   


    public Task<PokemonDetail> GetPokemonDetailAsync(int pokemonId)
    {
        return restService.GetPokemonDetailAsync(pokemonId);
    }
    public Task<PokemonDetail> GetPokemonDetailAsync(string url)
    {
        return restService.GetPokemonDetailAsync(url);
    }

}
