using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;


namespace MyDoggyDetails.Models;

[INotifyPropertyChanged]
public abstract partial class BaseModel
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private bool isDirty = false;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    private string title = string.Empty;


}
