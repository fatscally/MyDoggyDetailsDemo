using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Services;

public class DoggyPhotoService(IDoggyPhotoRepository photoRepository) : IDoggyPhotoService
{
    private readonly IDoggyPhotoRepository _photoRepository = photoRepository
        ?? throw new ArgumentNullException(nameof(photoRepository));

    public async Task SaveDoggyPhotoAsync(DoggyPhotoModel model)
        => await _photoRepository.SaveAsync(model);

    public async Task<IEnumerable<DoggyPhotoModel>> GetPhotosByDoggyIdAsync(string dogGuid)
        => await _photoRepository.SelectPhotosByDoggyId(dogGuid);
}
