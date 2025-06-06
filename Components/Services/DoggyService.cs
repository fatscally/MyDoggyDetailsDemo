using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Services
{
    public class DoggyService : IDoggyService
    {
        private readonly IDoggyRepository _doggyRepository;
        private readonly IDoggyPhotoRepository _photoRepository;

        public DoggyService(IDoggyRepository doggyRepository, IDoggyPhotoRepository photoRepository)
        {
            _doggyRepository = doggyRepository;
            _photoRepository = photoRepository;
        }

        public async Task SaveDoggyAsync(DoggyModel model)
        {
            await _doggyRepository.SaveAsync(model);
        }

        public async Task<IEnumerable<DoggyModel>> GetAllDoggiesAsync()
        {
            return await _doggyRepository.GetAllDoggiesAsync();
        }

        public async Task SaveDoggyPhotoAsync(DoggyPhotoModel model)
        {
            await _photoRepository.SaveAsync(model);
        }

        public async Task<IEnumerable<DoggyPhotoModel>> GetPhotosByDoggyIdAsync(string dogGuid)
        {
            return _photoRepository.SelectPhotosByDoggyId(dogGuid);
        }
    }
}
