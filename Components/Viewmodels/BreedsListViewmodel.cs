using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.API;
using MyDoggyDetails.Base;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using MyDoggyDetails.Pages;
using MyDoggyDetails.Utilities.Pictures;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

[QueryProperty("DogId", "DogId")]

public partial class BreedsListViewModel : BaseViewModel
{

    private readonly IBreedService _breedService;
    public int TotalOnlineCount;

    IDoggyPictures pictures;

    [ObservableProperty] private string feedbackMessage = "Using Local Doggie Database";
    [ObservableProperty] private ObservableCollection<BreedModel> breeds = new();
    [ObservableProperty] private BreedModel selectedBreed;
    [ObservableProperty] private Brush backgroundBrush = Brush.White;
    [ObservableProperty] private bool isRefreshing;
    [ObservableProperty] private bool hourglassRunning;
    [ObservableProperty] private bool hourglassVisible;
    [ObservableProperty] private string getButtonText = "Get API";
    [ObservableProperty] private int counter;
    [ObservableProperty] int dogId;
    
    partial void OnDogIdChanged(int value)
    {
        _ = GetBreedByIdAsync(value);
    }

    partial void OnHourglassRunningChanged(bool value)
    {
        HourglassVisible = value;
    }




    public BreedsListViewModel(IBreedService breedService)
    {
        _breedService = breedService;
        InitializeAsync();

#if (ANDROID)
    pictures = new PicturesAndroid();

#elif (WINDOWS)

#elif (__IOS__)

#endif


    }

    private async void InitializeAsync()
    {
        CheckNetworkStatus();
        await LoadUpBreedsAsync();
    }

    private void CheckNetworkStatus()
    {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        BackgroundBrush = accessType == NetworkAccess.Internet ? Brush.Green : Brush.Gray;
    }

    private async Task LoadUpBreedsAsync()
    {
        IsBusy = true;
        try
        {
            Breeds = _breedService.GetAllBreedsAsync().Result.ToObservableCollection<BreedModel>();
            FeedbackMessage = Breeds.Count == 0
                ? "No breeds found in local database. Pull down to refresh."
                : $"Found {Breeds.Count} breeds locally.";
        }
        catch (Exception ex)
        {
            FeedbackMessage = $"Error loading breeds: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }


    partial void OnBreedsChanged(ObservableCollection<BreedModel> value)
    {
        //SaveBreedsToDb();
        //_ = GetImagesForBreedsFromAPI();
    }

    



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
    public async Task GetBreedsFromWeb()
    {
        IsRefreshing = true;
        FeedbackMessage = "Refreshing content from API...";
        try
        {
            Breeds = _breedService.RefreshBreedsFromApiAsync().Result.ToObservableCollection<BreedModel>();



            //Breeds = _breedService.GetAllBreedsAsync().Result.ToObservableCollection<BreedModel>();
            FeedbackMessage = $"Found {Breeds.Count} breeds from API.";
        }
        catch (Exception ex)
        {
            FeedbackMessage = $"Error refreshing breeds: {ex.Message}";
        }
        finally
        {
            _ = SaveBreedsToDb();
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task SaveBreedsToDb()
    {
        IsBusy = true;
        try
        {
            _ = _breedService.SaveBreedsAsync();
            FeedbackMessage = "Breeds saved to database.";
        }
        catch (Exception ex)
        {
            FeedbackMessage = $"Error saving breeds: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    //[RelayCommand]
    //public async Task DownloadImages()
    //{
    //    IsBusy = true;
    //    try
    //    {
    //        await _breedService.DownloadBreedImagesAsync(Breeds);
    //        FeedbackMessage = "Images downloaded successfully.";
    //    }
    //    catch (Exception ex)
    //    {
    //        FeedbackMessage = $"Error downloading images: {ex.Message}";
    //    }
    //    finally
    //    {
    //        IsBusy = false;
    //    }
    //}




    private bool waitingForApi;



    private async Task GetBreedByIdAsync(int id)
    {
        try
        {
            SelectedBreed = await _breedService.GetBreedByIdAsync(id);
        }
        catch (Exception ex)
        {
            FeedbackMessage = $"Error fetching breed: {ex.Message}";
        }
    }

    //private async void GetBreedsFromAPI()
    //{
    //    waitingForApi = true;

    //    await Task.Run(() => FeedbackMessage = "Downloading from The Dog API... ");

    //    Breeds.Clear();

    //    DogItemManager http = new(new DogsRestService());


    //    Breeds = http.GetAllBreeds().ToObservableCollection<BreedModel>();


    //    await Task.Run(() => FeedbackMessage = "Found " + Breeds.Count + " breeds");
        
    //    waitingForApi = false;

    //}

    //private async Task GetImagesForBreedsFromAPI()
    //{
    //    int i = 0;



    //    foreach (BreedModel b in Breeds)
    //    {
    //        if (b.LocalIcon != null) continue;

    //        Task<byte[]> downloadimage = pictures.DownloadImageFromWeb(new Uri(b.Image_url));

    //        byte[] imgBytes = await downloadimage;

    //        await File.WriteAllBytesAsync(Constants.BreedsPhotosPath, imgBytes);

    //        b.LocalImagePath = Path.Combine(Constants.BreedsPhotosPath, Path.GetFileName(b.Image_url));

    //        b.LocalIcon = pictures.DownsizeImage(imgBytes, 60, 60);

    //        await _breedService.SaveBreedAsync(b);

    //        i++;

    //        await Task.Run(() => FeedbackMessage = "downloading images from Dog API... " + i.ToString());

    //    }

    //}



    [ObservableProperty] private ObservableCollection<BreedModel> webResults = new();

    [RelayCommand]
    private async Task GoToBreedDetailsPage(int id)
    {
        await Shell.Current.GoToAsync($"{nameof(BreedDetailPage)}?DogId={id}");
    }




}
