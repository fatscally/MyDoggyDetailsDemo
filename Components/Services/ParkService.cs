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

            var parks = await _parkRepository.GetAllParksAsync();
            return parks;

    }


}
