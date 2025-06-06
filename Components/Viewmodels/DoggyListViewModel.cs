using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using MyDoggyDetails.Pages;
using MyDoggyDetails.Utilities;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

//passed in from MyDoggiesPage
//[QueryProperty("DogId", "DogId")]



public partial class DoggyListViewModel : BaseViewModel
{

    private readonly IDoggyService _doggyService;

    [ObservableProperty] private ObservableCollection<DoggyModel> doggies;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FormattedAge))]
    [NotifyPropertyChangedFor(nameof(TotalDogDays))]
    private DoggyModel selectedDoggy;


    //public DoggyListViewModel()
    //{
        
    //}
    public DoggyListViewModel(IDoggyService doggyService)
    {

        _doggyService = doggyService;

        LoadUpDoggies();

    }

    internal async void LoadUpDoggies()
    {
        if (Doggies != null)
            Doggies.Clear();

        Doggies = _doggyService.GetAllDoggiesAsync().Result.ToObservableCollection<DoggyModel>();
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
            return new AgeCalculator(SelectedDoggy.DateOfBirth.ToDateTime()).FormattedAge();
        }
    }

    public string TotalDogDays
    {
        get
        {
            if (SelectedDoggy == null) return string.Empty;
            return new AgeCalculator(SelectedDoggy.DateOfBirth.ToDateTime()).TotalDogDays.ToString();
        }
    }

    public string FormattedAgeShort
    {
        get
        {
            if (SelectedDoggy == null) return string.Empty;
            return new AgeCalculator(SelectedDoggy.DateOfBirth.ToDateTime()).FormattedAgeShort();
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
