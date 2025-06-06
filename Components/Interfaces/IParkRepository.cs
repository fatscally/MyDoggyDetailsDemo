using MyDoggyDetails.Models;

namespace MyDoggyDetails.Interfaces;

public interface IParkRepository
{
    Task<IEnumerable<ParkTableModel>> GetAllParksAsync();
    Task CreateDatabaseAsync();
    Task<long> SaveAsync(ParkTableModel model);
    Task SeedParkDataAsync();

}