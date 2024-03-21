using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MyDoggyDetails.Models;

[INotifyPropertyChanged]
public abstract partial class BaseModel
{
    
    //[ObservableProperty]
    //[Key]
    //private int id;

    [ObservableProperty]
    private bool isDirty = false;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    private string title = string.Empty;


}
