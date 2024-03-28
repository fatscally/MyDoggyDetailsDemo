using MyDoggyDetails.Base;
using MyDoggyDetails.Models;
using System.Diagnostics;
using System.Text.Json;




namespace MyDoggyDetails.API;



public class DogsRestService
{
    HttpClient client;
    JsonSerializerOptions serializerOptions;


    public PokemonHeader PokemonHeaderResult { get; set; }
    public PokemonDetail PokemonDetail { get; set; }

    internal BreedModel[] Breeds { get; set; }


    public DogsRestService()
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Add("x-api-key", "live_s746KZfbN7igVSlp80oJjREPiuX8DKRYtrcjodG2kebROT6diXysDyaTP48Ztvq5");

        serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }


    public async Task<BreedModel[]> GetAllBreedsAsync()
    {


        //Uri uri = new Uri(string.Format("https://dog.ceo/api/breeds/list/all", string.Empty));

        Uri uri = new Uri(string.Format("https://api.thedogapi.com/v1/breeds", string.Empty));

        try
        {
            
            //get just one to find out the count...
            HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Breeds = JsonSerializer.Deserialize<BreedModel[]>(content, serializerOptions);

            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return Breeds;
    }

    public async Task<PokemonHeader> GetPokemonHeadersAsync()
    {

        int count = 1;


        Uri uri = new Uri(string.Format(Constants.RestUrlDogs, string.Empty));
        try
        {
            //get just one to find out the count...
            HttpResponseMessage response = await client.GetAsync(uri + "?limit=" + count).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                PokemonHeaderResult = JsonSerializer.Deserialize<PokemonHeader>(content, serializerOptions);
            }

            count = PokemonHeaderResult.Count;

            //Now you gotta catch 'em all - get the full list of Pokemon 
            response = await client.GetAsync(uri + "?limit=" + count).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                PokemonHeaderResult = JsonSerializer.Deserialize<PokemonHeader>(content, serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return PokemonHeaderResult;
    }

    public async Task<PokemonDetail> GetPokemonDetailAsync(int pokemonId)
    {


        Uri uri = new Uri(string.Format(Constants.RestUrlDogs, string.Empty));

        try
        {
            //get just one to find out the count...
            HttpResponseMessage response = await client.GetAsync(uri + pokemonId.ToString());
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                PokemonDetail = JsonSerializer.Deserialize<PokemonDetail>(content, serializerOptions);
            }


        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return PokemonDetail;
    }

    public async Task<PokemonDetail> GetPokemonDetailAsync(string url)
    {


        //Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

        try
        {
            //get just one to find out the count...
            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                PokemonDetail = JsonSerializer.Deserialize<PokemonDetail>(content, serializerOptions);
            }


        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return PokemonDetail;
    }


}

