using MyDoggyDetails.Models;
using System.Threading.Tasks;


namespace MyDoggyDetails.API
{

    public interface IRestService
    {
        Task<PokemonHeader> GetPokemonHeadersAsync();
        Task<PokemonDetail> GetPokemonDetailAsync(int pokemonId);

        Task<PokemonDetail> GetPokemonDetailAsync(string url);

    }

}
