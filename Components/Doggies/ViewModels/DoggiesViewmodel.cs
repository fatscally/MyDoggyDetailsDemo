
using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.ViewModels;

public partial class DoggiesViewmodel : BaseViewModel
{

    public DoggiesViewmodel()
    {
        SelectedDoggy = new() { GivenName = "Charlie", 
            DateOfBirth = new DateTime(2020, 08, 07) };

    }

    //private ObservableCollection<DogModel> doggies;

    //public ObservableCollection<DogModel> Doggies
    //{
    //    get { return doggies; }
    //    set
    //    {
    //        doggies = value;
    //        SetProperty(ref doggies, value);
    //    }
    //}

    [ObservableProperty]
    private DogModel selectedDoggy;




}
