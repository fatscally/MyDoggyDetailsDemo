using Microsoft.Maui.Controls.Maps;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Repository;

public class DataSeeder(IDoggyRepository doggyRepository, IParkRepository parkRepository)
{
    private readonly IDoggyRepository _doggyRepository = doggyRepository ?? throw new ArgumentNullException(nameof(doggyRepository));
    private readonly IParkRepository _parkRepository = parkRepository ?? throw new ArgumentNullException(nameof(parkRepository));

    public async Task SeedAsync()
    {
        await SeedDoggiesAsync();
        await SeedParksAsync();
    }

    private async Task SeedDoggiesAsync()
    {
        await _doggyRepository.SaveAsync(new DoggyModel { DogGuid = "0000", GivenName = "Nala", DateOfBirth = "2022-06-18 00:00:00", Sex = false, ChipNumber = "abc123" });
        await _doggyRepository.SaveAsync(new DoggyModel { DogGuid = "0001", GivenName = "Tiko", DateOfBirth = "2021-10-18 00:00:00", Sex = true, ChipNumber = "abc123" });
        await _doggyRepository.SaveAsync(new DoggyModel { DogGuid = "0002", GivenName = "Fido", DateOfBirth = "2020-01-01 00:00:00", Sex = true, ChipNumber = "abc123" });
    }

    private async Task SeedParksAsync()
    {
        await _parkRepository.SaveAsync(new ParkTableModel { Latitude = 53.372929871499075, Longitude = -6.173369488792618, Label = "St. Anne's Park.", Address = "Two parks for big doggies and little doggies.", Type = (int)PinType.Generic });
        await _parkRepository.SaveAsync(new ParkTableModel { Latitude = 53.30548059641863, Longitude = -6.34339356050867, Label = "Tymon Dog Park.", Address = "One big park for all the doggies.", Type = (int)PinType.Generic });
        await _parkRepository.SaveAsync(new ParkTableModel { Latitude = 53.342604703264804, Longitude = -6.440872837563679, Label = "Grifeen Valley Park.", Address = "A doggy park inside a human park", Type = (int)PinType.Generic });
    }
}
