using MyDoggyDetails.Base;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Services;

public class BreedService(IBreedsRepository breedsRepository, IDoggyPictures pictures, IDogsRestService restService) : IBreedService
{
    private readonly IBreedsRepository _breedsRepository = breedsRepository ?? throw new ArgumentNullException(nameof(breedsRepository));
    private readonly IDoggyPictures _pictures = pictures ?? throw new ArgumentNullException(nameof(pictures));
    private readonly IDogsRestService _restService = restService ?? throw new ArgumentNullException(nameof(restService));

    public async Task<IEnumerable<BreedModel>> GetAllBreedsAsync()
        => await _breedsRepository.GetAllBreedsAsync();

    public async Task<BreedModel> GetBreedByIdAsync(int id)
        => await _breedsRepository.GetByIdAsync(id);

    public async Task<IEnumerable<BreedModel>> RefreshBreedsFromApiAsync()
    {
        var breeds = (await _restService.GetAllBreedsAsync() ?? Enumerable.Empty<BreedModel>()).ToList();

        if (!breeds.Any())
            return Enumerable.Empty<BreedModel>();

        await _breedsRepository.InsertListAsync(breeds);
        await DownloadBreedImagesAsync(breeds);

        return breeds;
    }

    public async Task SaveBreedsAsync(IEnumerable<BreedModel> breeds)
        => await _breedsRepository.InsertListAsync(breeds);

    private async Task DownloadBreedImagesAsync(IEnumerable<BreedModel> breeds)
    {
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
        }
    }
}
