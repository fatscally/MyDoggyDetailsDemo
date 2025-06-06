using MyDoggyDetails.Base;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Services;

public class BreedService : IBreedService
{
    private readonly IBreedsRepository _breedsRepository;
    private readonly IDoggyPictures _pictures;
    private readonly IDogApiService _dogItemManager;
    public IEnumerable<BreedModel> Breeds { get; set; }

    public BreedService(IBreedsRepository breedsRepository, IDoggyPictures pictures, IDogApiService dogItemManager)
    {
        _breedsRepository = breedsRepository;
        _pictures = pictures;
        _dogItemManager = dogItemManager;
    }

    public async Task<IEnumerable<BreedModel>> GetAllBreedsAsync()
    {
        return await _breedsRepository.GetAllBreedsAsync();
    }

    public async Task<BreedModel> GetBreedByIdAsync(int id)
    {
        return await _breedsRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<BreedModel>> RefreshBreedsFromApiAsync()
    {
        Breeds = _dogItemManager.GetAllBreeds();

        _ = _breedsRepository.InsertListAsync(Breeds);

        _ = DownloadBreedImagesAsync(Breeds);

        return Breeds;
    }

    public async Task SaveBreedsAsync()
    {
        await _breedsRepository.InsertListAsync(Breeds);
    }

    public async Task SaveBreedAsync(BreedModel breed)
    {
        await _breedsRepository.SaveAsync(breed);
    }

    public async Task DownloadBreedImagesAsync(IEnumerable<BreedModel> breeds)
    {
        int i = 0;

        foreach (var breed in breeds)
        {
            if (breed.LocalIcon != null) continue;

            var imageBytes = await _pictures.DownloadImageFromWeb(new Uri(breed.Image_url));
            var imagePath = Path.Combine(Constants.BreedsPhotosPath, Path.GetFileName(breed.Image_url));
            Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
            await File.WriteAllBytesAsync(imagePath, imageBytes);

            breed.LocalImagePath = imagePath;
            breed.LocalIcon = _pictures.DownsizeImage(imageBytes, 60, 60);

            await _breedsRepository.SaveAsync(breed);
            i++;
        }
    }

}
