using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;


namespace MyDoggyDetails.Models;

[INotifyPropertyChanged]
public abstract partial class BaseTableModel
{
    //Certain functionality cannot see this (Id) variable so it 
    //has to be put in every class until further investigation.
    //It seems the Dapper ORM is not finding it.

    //[ObservableProperty]
    //[property: PrimaryKey]
    //[property: AutoIncrement]
    //private int id;

    [ObservableProperty]
    private bool isDirty = false;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    private string title = string.Empty;


}
