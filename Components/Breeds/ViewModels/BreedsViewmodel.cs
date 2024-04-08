using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.API;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;
using MyDoggyDetails.Utilities;
using MyDoggyDetails.Utilities.Pictures;

namespace MyDoggyDetails.ViewModels;


internal partial class BreedsViewmodel : BaseViewModel
{
    public int TotalOnlineCount;

    IDoggyPictures pictures;

    public BreedsViewmodel()
    {

            #if (ANDROID)
                    pictures = new PicturesAndroid();

            #elif (WINDOWS)

            #elif (__IOS__)

            #endif


        Breeds = new BreedsRepository().SelectAllBreeds();
        Online();
    }

    [ObservableProperty]
    private Brush backgroundBrush = Brush.White;


    private void Online()
    {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        if (accessType == NetworkAccess.Internet)
        {
                BackgroundBrush = Brush.Green;
        }
        else { BackgroundBrush = Brush.Gray; }
    }

    [RelayCommand]
    public void GetBreedsFromWeb()
    {
        GetButtonText = "clicked...";
        GetBreeds();
    }

    [RelayCommand]
    public void SaveBreedsToDb()
    {
        SaveAsync();
    }

    [RelayCommand]
    public async void DownloadImage()
    {

        GetImagesForBreeds();

    }

    private async Task GetImagesForBreeds()
    {
        int i = 0;

        foreach(BreedModel b in Breeds)
        {

                b.LocalImage = pictures.DownloadImageFromWeb(new Uri(b.Image_url)).Result;

            i++;
        }

        GetButtonText = $"{i}";
    }

    async void SaveAsync()
    {
        await new BreedsRepository().InsertList(Breeds.ToList());
    }

    [ObservableProperty]
    private ObservableCollection<BreedModel> breeds;



    [ObservableProperty]
    public string getButtonText = "Get API";



    private void GetBreeds()
    {

        Task.Run( ()=> GetButtonText = "Fetching Breeds...");

        Breeds.Clear();

        DogItemManager http = new(new DogsRestService());

        Breeds = http.GetAllBreeds().Result.ToObservableCollection<BreedModel>();

        Task.Run(() => GetButtonText = "Found " + Breeds.Count + " breeds");

    }


   

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GetButtonText))]
    private int counter = 0;



    [ObservableProperty]
    private ObservableCollection<BreedModel> webResults = new();



}
