using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using MyDoggyDetails.Pages;
using MyDoggyDetails.Utilities;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;


[QueryProperty("DogId", "DogId")]



public partial class DoggiesViewmodel : BaseViewModel
{

    

    [ObservableProperty]
    int dogId;
    partial void OnDogIdChanged(int value)
    {
        SelectedDoggy = Doggies.FirstOrDefault(x => x.Id == value);
    }

    public DoggiesViewmodel()
    {
        Doggies = new DoggyRepository().SelectAllDoggies();
    }

    [ObservableProperty]
    private ObservableCollection<DoggyTableModel> doggies;


    public BreedTableModel Breed { get; set; }


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FormattedAge))]
    [NotifyPropertyChangedFor(nameof(TotalDogDays))]
    private DoggyTableModel selectedDoggy;

    
    public string FormattedAge
    {
        get
            {
            if (selectedDoggy == null) return string.Empty;
                return new AgeCalculator(selectedDoggy.DateOfBirth.ToDateTime()).FormattedAge();
            }
    }

    public string TotalDogDays
    {
        get
        {
            if (selectedDoggy == null) return string.Empty;
            return new AgeCalculator(selectedDoggy.DateOfBirth.ToDateTime()).TotalDogDays.ToString();
        }
    }

    [RelayCommand]
    async Task GoToDogDetailsPage(int workerId)
    {
        await Shell.Current.GoToAsync($"{nameof(DogDetailsPage)}?DogId={SelectedDoggy.Id}");
    }

    //[RelayCommand]
    //private void GoToDogDetailsPage(int workerId)
    //{
    //     Shell.Current.GoToAsync($"{nameof(DogDetailsPage)}?DogId={SelectedDoggy.Id}");
    //}

    [RelayCommand]
    public void SaveDogDetails()
    {
        new DoggyRepository().Save(selectedDoggy);
    }

    public void Entry_TextChanged()
    {
        DoggyData.Save(SelectedDoggy);
    }

}
