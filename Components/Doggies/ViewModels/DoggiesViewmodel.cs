
using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

public partial class DoggiesViewmodel : BaseViewModel
{

    public DoggiesViewmodel()
    {
        DoggyRepository repository= new DoggyRepository();
        Doggies = repository.List();
    }

    private ObservableCollection<DoggyTableModel> doggies;

    public ObservableCollection<DoggyTableModel> Doggies
    {
        get { return doggies; }
        set
        {
            if (value is null) return;

            doggies = value;
            SetProperty(ref doggies, value);
        }
    }

    [ObservableProperty]
    private Doggy selectedDoggy;




}
