using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using MyDoggyDetails.Pages;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

[QueryProperty("DogId", "DogId")]

public partial class BreedsListViewModel : BaseViewModel
{
    private readonly IBreedService _breedService;
    private readonly IConnectivity _connectivity;
    public int TotalOnlineCount;

    [ObservableProperty] private string feedbackMessage = "Using Local Doggie Database";
    [ObservableProperty] private ObservableCollection<BreedModel> breeds = [];
    [ObservableProperty] private BreedModel selectedBreed;
    [ObservableProperty] private Brush backgroundBrush = Brush.White;
    [ObservableProperty] private bool isRefreshing;
    [ObservableProperty] private bool hourglassRunning;
    [ObservableProperty] private bool hourglassVisible;
    [ObservableProperty] private string getButtonText = "Get API";
    [ObservableProperty] private int counter;
    [ObservableProperty] int dogId;

    partial void OnDogIdChanged(int value) => _ = GetBreedByIdAsync(value);

    partial void OnHourglassRunningChanged(bool value) => HourglassVisible = value;

    public BreedsListViewModel(IBreedService breedService, IConnectivity connectivity)
    {
        _breedService = breedService;
        _connectivity = connectivity;
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        CheckNetworkStatus();
        await LoadUpBreedsAsync();
    }

    private void CheckNetworkStatus()
    {
        BackgroundBrush = _connectivity.NetworkAccess == NetworkAccess.Internet
            ? Brush.Green
            : Brush.Gray;
    }

    private async Task LoadUpBreedsAsync()
    {
        IsBusy = true;
        try
        {
            Breeds = (await _breedService.GetAllBreedsAsync()).ToObservableCollection();

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

    partial void OnBreedsChanged(ObservableCollection<BreedModel> value) { }

    [RelayCommand]
    public async Task GetBreedsFromWeb()
    {
        IsRefreshing = true;
        FeedbackMessage = "Refreshing content from API...";
        try
        {
            Breeds = (await _breedService.RefreshBreedsFromApiAsync()).ToObservableCollection();
            FeedbackMessage = $"Found {Breeds.Count} breeds from API.";
        }
        catch (Exception ex)
        {
            FeedbackMessage = $"Error refreshing breeds: {ex.Message}";
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task SaveBreedsToDb()
    {
        IsBusy = true;
        try
        {
            await _breedService.SaveBreedsAsync(Breeds);
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

    [ObservableProperty] private ObservableCollection<BreedModel> webResults = [];

    [RelayCommand]
    private async Task GoToBreedDetailsPage(int id)
        => await Shell.Current.GoToAsync($"{nameof(BreedDetailPage)}?DogId={id}");
}
