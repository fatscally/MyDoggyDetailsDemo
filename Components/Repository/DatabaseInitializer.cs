using MyDoggyDetails.Interfaces;

namespace MyDoggyDetails.Repository;

public class DatabaseInitializer
{
    private readonly IDoggyRepository _doggyRepository;
    private readonly IBreedsRepository _breedsRepository;
    private readonly IParkRepository _parkRepository;
    private const string FirstInstallKey = "IsFirstInstall";


    public DatabaseInitializer(IDoggyRepository doggyRepository, 
                                IBreedsRepository breedsRepository, 
                                IParkRepository parkRepository)
    {
        _doggyRepository = doggyRepository ?? throw new ArgumentNullException(nameof(doggyRepository));
        _breedsRepository = breedsRepository ?? throw new ArgumentNullException(nameof(breedsRepository));
        _parkRepository = parkRepository ?? throw new ArgumentNullException(nameof(parkRepository));

    }

    public async Task InitializeAsync()
    {
        if (Preferences.Get(FirstInstallKey, false))
            return;

            await _doggyRepository.CreateDatabaseAsync();
            await _breedsRepository.CreateDatabaseAsync();
            await _parkRepository.CreateDatabaseAsync();
            await new DataSeeder(_doggyRepository, _parkRepository).SeedAsync();
            Preferences.Set(FirstInstallKey, true);
            

    }
}