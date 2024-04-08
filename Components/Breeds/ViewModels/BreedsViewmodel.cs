using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.API;
using MyDoggyDetails.Pages;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using MyDoggyDetails.Utilities.Pictures;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

[QueryProperty("DogId", "DogId")]

internal partial class BreedsViewmodel : BaseViewModel
{
    public int TotalOnlineCount;

    IDoggyPictures pictures;

    [ObservableProperty]
    private ObservableCollection<BreedModel> breeds;

    [ObservableProperty]
    private BreedModel selectedBreed;




    public BreedsViewmodel()
    {

            #if (ANDROID)
                    pictures = new PicturesAndroid();

            #elif (WINDOWS)

            #elif (__IOS__)

            #endif

        GetBreedsFromDb();


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
        Task.Run(() => GetButtonText = "clicked...");
        GetBreedsFromAPI();
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

                Task<byte[]> downloadimage = pictures.DownloadImageFromWeb(new Uri(b.Image_url));

                b.LocalImage = await downloadimage;

                b.LocalIcon = pictures.DownsizeImage(b.LocalImage, 60, 60);

                await new BreedsRepository().SaveBreed(b);

            i++;
        }

        GetButtonText = $"{i}";
    }

    async void SaveAsync()
    {
        await new BreedsRepository().InsertList(Breeds.ToList());
    }




    [ObservableProperty]
    public string getButtonText = "Get API";


    private async void GetBreedsFromDb()
    {
        Task<ObservableCollection<BreedModel>> getBreedsFromDb = new BreedsRepository().SelectAllBreeds();
        Breeds = await getBreedsFromDb;

    }

    private void GetBreedsFromAPI()
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



    [RelayCommand]
    async Task GoToBreedDetailsPage(int workerId)
    {
        await Shell.Current.GoToAsync($"{nameof(BreedDetailPage)}?DogId={SelectedBreed.Id}");
    }



}
