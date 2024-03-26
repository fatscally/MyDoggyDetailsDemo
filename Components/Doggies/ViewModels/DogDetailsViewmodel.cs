using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.ViewModels;

//passed in from MyDoggiesPage
[QueryProperty("DogId", "DogId")]



public partial class DogDetailsViewmodel : BaseViewModel
{

    [ObservableProperty]
    int dogId;
    partial void OnDogIdChanged(int value)
    {
        SelectedDoggy = new DoggiesViewmodel().Doggies.FirstOrDefault(x => x.Id == value);
    }

    [ObservableProperty]
    private DoggyTableModel selectedDoggy;


    [RelayCommand]
    public void SaveDogDetails()
    {
        new DoggyRepository().Save(selectedDoggy);
    }

}
