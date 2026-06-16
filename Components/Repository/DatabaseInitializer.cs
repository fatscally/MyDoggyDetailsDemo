using MyDoggyDetails.Interfaces;

namespace MyDoggyDetails.Repository;

public class DatabaseInitializer(IDoggyRepository doggyRepository, IBreedsRepository breedsRepository, IParkRepository parkRepository, DataSeeder seeder)
{
    private readonly IDoggyRepository _doggyRepository = doggyRepository ?? throw new ArgumentNullException(nameof(doggyRepository));
    private readonly IBreedsRepository _breedsRepository = breedsRepository ?? throw new ArgumentNullException(nameof(breedsRepository));
    private readonly IParkRepository _parkRepository = parkRepository ?? throw new ArgumentNullException(nameof(parkRepository));
    private readonly DataSeeder _seeder = seeder ?? throw new ArgumentNullException(nameof(seeder));
    private const string FirstInstallKey = "IsFirstInstall";

    public async Task InitializeAsync()
    {
        // Always run — CreateTableAsync uses CREATE TABLE IF NOT EXISTS, so it is safe to call on every launch.
        // This recovers from scenarios where the DB file was deleted without clearing Preferences.
        await Task.WhenAll(
            _doggyRepository.CreateDatabaseAsync(),
            _breedsRepository.CreateDatabaseAsync(),
            _parkRepository.CreateDatabaseAsync()
        );

        if (Preferences.Get(FirstInstallKey, false))
            return;

        try
        {
            await _seeder.SeedAsync();
        }
        finally
        {
            // Set the flag whether or not seeding fully succeeded to avoid
            // re-seeding on the next launch and inserting duplicate rows.
            Preferences.Set(FirstInstallKey, true);
        }
    }
}