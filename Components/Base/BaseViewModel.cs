using CommunityToolkit.Mvvm.ComponentModel;

using System.ComponentModel;


namespace MyDoggyDetails.ViewModels;


[INotifyPropertyChanged]
public abstract partial class BaseViewModel
{

    [ObservableProperty]
    bool isBusy = false;


    [ObservableProperty]
    string title = string.Empty;

}



