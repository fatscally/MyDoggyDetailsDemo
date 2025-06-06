using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Repository;

public class DoggyRepository : BaseRepository, IDoggyRepository
{


    public DoggyRepository(IDatabaseConnection connection) : base(connection)
    {

    }

    public async Task<long> SaveAsync(DoggyModel model)
    {
            return model.Id == 0 ? await base.InsertAsync(model) : await base.UpdateAsync(model);
    }

    public async Task<IEnumerable<DoggyModel>> GetAllDoggiesAsync()
    {
            return conn.Table<DoggyModel>();
    }

    public async Task CreateDatabaseAsync()
    {
        conn.CreateTable<DoggyModel>();
    }

    public async Task SeedDoggyDataAsync()
    {

            await SaveAsync(new DoggyModel { DogGuid = "0000", GivenName = "Nala", DateOfBirth = "2022-06-18 00:00:00", Sex = false, ChipNumber = "abc123" });
            await SaveAsync(new DoggyModel { DogGuid = "0001", GivenName = "Tiko", DateOfBirth = "2021-10-18 00:00:00", Sex = true, ChipNumber = "abc123" });
            await SaveAsync(new DoggyModel { DogGuid = "0002", GivenName = "Fido", DateOfBirth = "2020-01-01 00:00:00", Sex = true, ChipNumber = "abc123" });
    }
}