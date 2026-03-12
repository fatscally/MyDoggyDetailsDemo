using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyDoggyDetails.API;

public class DogsRestService(HttpClient httpClient) : IDogsRestService
{

    private readonly HttpClient _httpClient = httpClient
        ?? throw new ArgumentNullException(nameof(httpClient));


    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        AllowTrailingCommas = true
    };


    public async Task<IEnumerable<BreedModel>> GetAllBreedsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("breeds").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var x = JsonSerializer.Deserialize<BreedModel[]>(content, SerializerOptions)
                ?? Array.Empty<BreedModel>();

            return x;
        }
        catch (HttpRequestException ex) when (ex.StatusCode != null)
        {
            Debug.WriteLine($"HTTP error {ex.StatusCode}: {ex.Message}");
            return Array.Empty<BreedModel>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unexpected error: {ex}");
            return Array.Empty<BreedModel>();
        }
    }





}