using MyDoggyDetails.Interfaces;

namespace MyDoggyDetails.Repository;

public class DataSeeder
{
    private readonly IDoggyRepository _doggyRepository;
    private readonly IParkRepository _parkRepository;


    public DataSeeder(IDoggyRepository doggyRepository, IParkRepository parkRepository)
    {
        _doggyRepository = doggyRepository ?? throw new ArgumentNullException(nameof(doggyRepository));
        _parkRepository = parkRepository ?? throw new ArgumentNullException(nameof(parkRepository));
    }

    public async Task SeedAsync()
    {
        await _doggyRepository.SeedDoggyDataAsync();
        await _parkRepository.SeedParkDataAsync();
    }
}