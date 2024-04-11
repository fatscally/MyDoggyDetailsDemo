using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using MyDoggyDetails.Utilities.Pictures;

namespace MyDoggyDetails.ViewModels;

[QueryProperty("DogId", "DogId")]

internal partial class BreedDetailsViewmodel : BaseViewModel
{

    IDoggyPictures pictures;


    [ObservableProperty]
    private BreedModel selectedBreed;

    [ObservableProperty]
    int dogId;
    partial void OnDogIdChanged(int value)
    {
        GetBreedById(value);
    }

    

    public BreedDetailsViewmodel()
    {

        #if (ANDROID)
                            pictures = new PicturesAndroid();

        #elif (WINDOWS)

        #elif (__IOS__)

        #endif

    }


    private async void GetBreedById(int id)
    {
        Task<BreedModel> getBreedsById = new BreedsRepository().SelectBreedById(id);
        SelectedBreed = await getBreedsById;

    }


}
