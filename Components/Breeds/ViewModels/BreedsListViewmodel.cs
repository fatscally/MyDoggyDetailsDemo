using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.API;
using MyDoggyDetails.Base;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using MyDoggyDetails.Pages;
using MyDoggyDetails.Utilities.Pictures;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

[QueryProperty("DogId", "DogId")]

internal partial class BreedsListViewmodel : BaseViewModel
{
    public int TotalOnlineCount;

    IDoggyPictures pictures;

    [ObservableProperty]
    private string feedbackMessage = "Using Local Doggie Database";

    [ObservableProperty]
    private ObservableCollection<BreedModel> breeds = new();



    [ObservableProperty]
    private BreedModel selectedBreed;

    [ObservableProperty]
    int dogId;
    partial void OnDogIdChanged(int value)
    {
        GetBreedById(value);

    }

    [ObservableProperty]
    private Brush backgroundBrush = Brush.White;


    public BreedsListViewmodel()
    {

#if (ANDROID)
                                pictures = new PicturesAndroid();

#elif (WINDOWS)

#elif (__IOS__)

#endif


        Task.Run(() => LoadUpBreeds());

    }


    private async void LoadUpBreeds()
    {
        GetBreedsFromDb();

        if (Breeds.Count == 0)
        {
            FeedbackMessage = "0 dogs found in local database. Pull down to refresh.";
        }

    }


    private async void GetBreedsFromDb()
    {
        Breeds = new BreedsRepository().SelectAllBreeds();
    }
    partial void OnBreedsChanged(ObservableCollection<BreedModel> value)
    {
        _ = GetImagesForBreedsFromAPI();
    }

    [ObservableProperty]
    private bool hourglassRunning;
    partial void OnHourglassRunningChanged(bool value) { HourglassVisible = HourglassRunning; }


    [ObservableProperty]
    private bool hourglassVisible;

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
        FeedbackMessage = "Refreshing content from API...";

        GetBreedsFromAPI();

        _ = GetImagesForBreedsFromAPI();

        SaveBreedsToDb();

        IsRefreshing = false;
    }

    [RelayCommand]
    public void SaveBreedsToDb()
    {
        SaveAsync();
    }

    [RelayCommand]
    public void DownloadImages()
    {

        _ = GetImagesForBreedsFromAPI();

    }



    [ObservableProperty]
    private bool isRefreshing;

    private bool waitingForApi;



    private async void GetBreedById(int id)
    {
        Task<BreedModel> getBreedsById = new BreedsRepository().SelectBreedById(id);
        SelectedBreed = await getBreedsById;

    }

    private async void GetBreedsFromAPI()
    {
        waitingForApi = true;

        await Task.Run(() => FeedbackMessage = "Downloading from The Dog API... ");

        Breeds.Clear();

        DogItemManager http = new(new DogsRestService());


        Breeds = http.GetAllBreeds().Result.ToObservableCollection<BreedModel>();


        await Task.Run(() => FeedbackMessage = "Found " + Breeds.Count + " breeds");
        
        waitingForApi = false;

    }

    private async Task GetImagesForBreedsFromAPI()
    {
        int i = 0;



        foreach (BreedModel b in Breeds)
        {
            if (b.LocalIcon != null) continue;

            Task<byte[]> downloadimage = pictures.DownloadImageFromWeb(new Uri(b.Image_url));

            byte[] imgBytes = await downloadimage;

            await File.WriteAllBytesAsync(Constants.BreedsPhotosPath, imgBytes);

            //b.LocalImage = await downloadimage;
            b.LocalImagePath = Path.Combine(Constants.BreedsPhotosPath, Path.GetFileName(b.Image_url));

            b.LocalIcon = pictures.DownsizeImage(imgBytes, 60, 60);

            await new BreedsRepository().SaveBreed(b);

            i++;

            await Task.Run(() => FeedbackMessage = "downloading images from Dog API... " + i.ToString());

        }


        GetButtonText = $"{i}";
    }


    async void SaveAsync()
    {
        await new BreedsRepository().InsertList(Breeds.ToList());
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

    [ObservableProperty]
    public string getButtonText = "Get API";


}
