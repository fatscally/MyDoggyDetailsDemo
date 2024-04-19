using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using MyDoggyDetails.Pages;
using MyDoggyDetails.Utilities;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

//passed in from MyDoggiesPage
//[QueryProperty("DogId", "DogId")]



public partial class DoggiesViewmodel : BaseViewModel
{


     public DoggiesViewmodel()
    {
       LoadUpDoggies();
    }

    internal void LoadUpDoggies()
    {
        Doggies = new DoggyRepository().SelectAllDoggies();
    }

    [ObservableProperty]
    private ObservableCollection<DoggyTableModel> doggies;


    public BreedModel Breed { get; set; }


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FormattedAge))]
    [NotifyPropertyChangedFor(nameof(TotalDogDays))]
    private DoggyTableModel selectedDoggy;

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
    public void SaveDogDetails()
    {
        new DoggyRepository().Save(SelectedDoggy);
    }

    public void Entry_TextChanged()
    {
        DoggyData.Save(SelectedDoggy);
    }

}
