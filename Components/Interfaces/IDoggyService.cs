using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Interfaces;

public interface IDoggyService
{
    Task SaveDoggyAsync(DoggyModel model);
    Task<IEnumerable<DoggyModel>> GetAllDoggiesAsync();
    Task SaveDoggyPhotoAsync(DoggyPhotoModel model);
    Task<IEnumerable<DoggyPhotoModel>> GetPhotosByDoggyIdAsync(string dogGuid);
}
