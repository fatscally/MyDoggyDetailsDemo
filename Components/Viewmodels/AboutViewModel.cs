using CommunityToolkit.Mvvm.ComponentModel;
using System.Text;

namespace MyDoggyDetails.ViewModels;

public partial class AboutViewModel : BaseViewModel
{
    [ObservableProperty] private string name = AppInfo.Current.Name;
    [ObservableProperty] private string package = AppInfo.Current.PackageName;
    [ObservableProperty] private string version = AppInfo.Current.VersionString;
    [ObservableProperty] private string build = AppInfo.Current.BuildString;
    [ObservableProperty] private string author = "Ray Brennan";
    [ObservableProperty] private string email = "mr.raymond.brennan@outlook.com";

    [ObservableProperty] private string description = "Coding demo app.";

    public AboutViewModel()
    {
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        Description = await LoadCommentsAsync();
    }



    private async Task<string> LoadCommentsAsync()
    {
        var sb = new StringBuilder();

        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("README.md");
            using var reader = new StreamReader(stream);
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                sb.AppendLine(line);
            }
        }
        catch (FileNotFoundException)
        {
            sb.AppendLine("README.md file not found.");
        }

        return sb.ToString();
    }

}
