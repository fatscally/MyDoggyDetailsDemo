using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.ViewModels;

[QueryProperty("DogId", "DogId")]

public partial class BreedDetailViewModel : BaseViewModel
{
    private readonly IBreedService _breedService;

    [ObservableProperty] private BreedModel selectedBreed;

    [ObservableProperty] int dogId;
    partial void OnDogIdChanged(int value) => _ = GetBreedByIdAsync(value);

    public BreedDetailViewModel(IBreedService breedService)
    {
        _breedService = breedService ?? throw new ArgumentNullException(nameof(breedService));
    }

    private async Task GetBreedByIdAsync(int id)
    {
        SelectedBreed = await _breedService.GetBreedByIdAsync(id);
    }
}
