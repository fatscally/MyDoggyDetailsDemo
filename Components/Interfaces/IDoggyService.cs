using MyDoggyDetails.Models;

namespace MyDoggyDetails.Interfaces;

public interface IDoggyService
{
    Task SaveDoggyAsync(DoggyModel model);
    Task<IEnumerable<DoggyModel>> GetAllDoggiesAsync();
}
