using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Services;

public class ParkService : IParkService
{
    private readonly IParkRepository _parkRepository;

    public ParkService(IParkRepository parkRepository)
    {
        _parkRepository = parkRepository;
    }



    public async Task<IEnumerable<ParkTableModel>> GetAllParksAsync()
    {
        try
        {
            var parks = await _parkRepository.GetAllParksAsync();
            return parks;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ParkService: Error getting parks: {ex}");
            throw;
        }
    }


}
