using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Services;

public class DoggyService(IDoggyRepository doggyRepository) : IDoggyService
{
    private readonly IDoggyRepository _doggyRepository = doggyRepository
        ?? throw new ArgumentNullException(nameof(doggyRepository));

    public async Task SaveDoggyAsync(DoggyModel model)
        => await _doggyRepository.SaveAsync(model);

    public async Task<IEnumerable<DoggyModel>> GetAllDoggiesAsync()
        => await _doggyRepository.GetAllDoggiesAsync();
}
