using MyDoggyDetails.Models;

namespace MyDoggyDetails.Interfaces;

public interface IDoggyPhotoService
{
    Task SaveDoggyPhotoAsync(DoggyPhotoModel model);
    Task<IEnumerable<DoggyPhotoModel>> GetPhotosByDoggyIdAsync(string dogGuid);
}
