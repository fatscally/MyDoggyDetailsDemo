using Microsoft.Extensions.Logging;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Repository;

public class BreedsRepository : BaseRepository, IBreedsRepository
{
    private readonly ILogger<BreedsRepository> _logger;
    public BreedsRepository(IDatabaseConnection connection, ILogger<BreedsRepository> logger) : base(connection)
    {
        _logger = logger;
    }

    public async Task InsertListAsync(IEnumerable<BreedModel> breedModels)
    {
        
        foreach (var model in breedModels)
        {
            await SaveAsync(model);
        }
    }

    public async Task<long> SaveAsync(BreedModel model)
    {
        var existingBreed = await Task.Run(() => conn.Table<BreedModel>().FirstOrDefault(x => x.Name == model.Name));
        if (existingBreed != null)
        {
            model.Id = existingBreed.Id;
            return await base.UpdateAsync(model);
        }
        return await base.InsertAsync(model);
    }


    public async Task CreateDatabaseAsync()
    {
        try
        {
            await Task.Run(() => conn.CreateTable<BreedModel>());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating breeds database");
            throw;
        }
    }


    public async Task<BreedModel> GetByIdAsync(int id)
    {
        return conn.Table<BreedModel>().FirstOrDefault(b => b.Id == id);
    }


    public async Task<IEnumerable<BreedModel>> GetAllBreedsAsync()
    {
        var breeds = conn.Table<BreedModel>();

        return breeds.ToList().AsEnumerable();
    }


}
