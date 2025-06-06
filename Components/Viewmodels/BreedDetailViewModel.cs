using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using MyDoggyDetails.Utilities.Pictures;

namespace MyDoggyDetails.ViewModels;

[QueryProperty("DogId", "DogId")]

public partial class BreedDetailViewModel : BaseViewModel
{

    private readonly IBreedsRepository _breedsRepository;
    IDoggyPictures pictures;


    [ObservableProperty] private BreedModel selectedBreed;

    [ObservableProperty] int dogId;
    partial void OnDogIdChanged(int value)
    {
        GetBreedById(value);
    }



    public BreedDetailViewModel(IBreedsRepository breedsRepository)
    {
        _breedsRepository = breedsRepository;

#if (ANDROID)
                            pictures = new PicturesAndroid();

#elif (WINDOWS)

#elif (__IOS__)

#endif

    }


    private async void GetBreedById(int id)
    {
        Task<BreedModel> getBreedsById = _breedsRepository.GetByIdAsync(id); //  new BreedsRepository().SelectBreedById(id);
        SelectedBreed = await getBreedsById;

    }


}
