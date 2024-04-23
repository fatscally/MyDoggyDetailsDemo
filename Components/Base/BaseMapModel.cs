using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Models;
using SQLite;

namespace MyDoggyDetails.Base;

public partial class BaseMapModel : BaseTableModel
{

    [Ignore]
    public NavigationMode NavigationMode { get; set; }

    //these are Google Map variables - often repurposed.
    [ObservableProperty] public double longitude;
    [ObservableProperty] public double latitude;
    [ObservableProperty] public string label;
    [ObservableProperty] public string address;
    [ObservableProperty] public int type;


    [ObservableProperty] public string addedByUserGUID;

}
