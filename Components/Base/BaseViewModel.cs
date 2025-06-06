using CommunityToolkit.Mvvm.ComponentModel;


namespace MyDoggyDetails.ViewModels;



public abstract partial class BaseViewModel : ObservableObject
{

    [ObservableProperty]
    bool isBusy = false;


    [ObservableProperty]
    string title = string.Empty;

}



