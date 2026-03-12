using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using MyDoggyDetails.Pages;
using MyDoggyDetails.Utilities;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;


public partial class DoggyListViewModel : BaseViewModel
{

    private readonly IDoggyService _doggyService;


    [ObservableProperty] private ObservableCollection<DoggyModel> doggies;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FormattedAge))]
    [NotifyPropertyChangedFor(nameof(TotalDogDays))]
    private DoggyModel selectedDoggy;


    public DoggyListViewModel(IDoggyService doggyService)
    {

        _doggyService = doggyService;

        LoadUpDoggies();

    }

    internal async void LoadUpDoggies()
    {
        if (Doggies != null)
            Doggies.Clear();

        Doggies = (await _doggyService.GetAllDoggiesAsync()).ToObservableCollection();
    }




    public BreedModel Breed { get; set; }

    public int UpdateDoggies
    {
        get
        {
            Doggies.FirstOrDefault(x => x.Id == SelectedDoggy.Id);
            return 0;
        }
    }


    public string FormattedAge
    {
        get
        {
            if (SelectedDoggy == null) return string.Empty;
            return AgeCalculator.CalculateAge(SelectedDoggy.DateOfBirth.ToDateTime()).ToString();

        }
    }

    public string TotalDogDays
    {
        get
        {
            if (SelectedDoggy == null) return string.Empty;

            return AgeCalculator.CalculateAge(SelectedDoggy.DateOfBirth.ToDateTime()).TotalDays.ToString();

        }
    }

    public string FormattedAgeShort
    {
        get
        {
            if (SelectedDoggy == null) return string.Empty;

            return "not implemented yet";

        }
    }

    [RelayCommand]
    async Task GoToDogDetailsPage(int workerId)
    {
        await Shell.Current.GoToAsync($"{nameof(DogDetailsPage)}?DogId={SelectedDoggy.Id}");
    }


    [RelayCommand]
    public async Task SaveDogDetails()
    {
        await _doggyService.SaveDoggyAsync(SelectedDoggy);
    }

    public async Task Entry_TextChanged()
    {
        await _doggyService.SaveDoggyAsync(SelectedDoggy);
    }

}
