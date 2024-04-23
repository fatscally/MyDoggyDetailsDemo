using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MyDoggyDetails.Models;

public abstract partial class BaseTableModel : ObservableObject
{

    [ObservableProperty]
    [property: PrimaryKey]
    [property: AutoIncrement]
    private int id;

    [ObservableProperty]
    private bool isDirty = false;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    private string title = string.Empty;


}


