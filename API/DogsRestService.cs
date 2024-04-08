using MyDoggyDetails.Base;
using MyDoggyDetails.Models;
using System.Diagnostics;
using System.Text.Json;




namespace MyDoggyDetails.API;



public class DogsRestService
{
    HttpClient client;
    JsonSerializerOptions serializerOptions;



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



}

