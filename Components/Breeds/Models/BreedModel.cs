using CommunityToolkit.Mvvm.ComponentModel;


namespace MyDoggyDetails.Models;

public partial class BreedModel : BaseModel
{
    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string size;
    [ObservableProperty]
    private string description;
    [ObservableProperty]
    private string imgPup;
    [ObservableProperty]
    private string imgAdult;
}
