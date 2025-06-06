using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Interfaces;

public interface IDoggyPhotoRepository
{
    Task<long> SaveAsync(DoggyPhotoModel model);
    IEnumerable<DoggyPhotoModel> SelectPhotosByDoggyId(string dogGuid);
    void CreateDatabase();
}
