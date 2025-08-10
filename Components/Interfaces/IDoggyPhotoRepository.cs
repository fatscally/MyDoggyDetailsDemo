using MyDoggyDetails.Models;

namespace MyDoggyDetails.Interfaces;

public interface IDoggyPhotoRepository
{
    Task<long> SaveAsync(DoggyPhotoModel model);
    Task <IEnumerable<DoggyPhotoModel>> SelectPhotosByDoggyId(string dogGuid);
    Task CreateDatabase();
}
