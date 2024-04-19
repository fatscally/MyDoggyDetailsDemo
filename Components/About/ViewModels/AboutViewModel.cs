using CommunityToolkit.Mvvm.ComponentModel;

namespace MyDoggyDetails.ViewModels;

public partial class AboutViewModel : BaseViewModel
{
    [ObservableProperty]
    private string name = AppInfo.Current.Name;
    [ObservableProperty]
    private string package = AppInfo.Current.PackageName;
    [ObservableProperty]
    private string version = AppInfo.Current.VersionString;
    [ObservableProperty]
    private string build = AppInfo.Current.BuildString;
    [ObservableProperty]
    private string author = "Ray Brennan";
    [ObservableProperty]
    private string email = "mr.raymond.brennan@outlook.com";

}
