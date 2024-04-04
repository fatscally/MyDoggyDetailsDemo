using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System.Text.Json.Serialization;


namespace MyDoggyDetails.Models;

[Table("Breeds")]
public partial class BreedTableModel : BaseTableModel
{

    [ObservableProperty]
    [JsonPropertyName("name")]
    private string name;

    [ObservableProperty]
    [JsonPropertyName("subbreed")]
    private string subBreed;


    [ObservableProperty]
    private string size;
    [ObservableProperty]
    private string description;
    [ObservableProperty]
    private string imgPup;
    [ObservableProperty]
    private string imgAdult;


}
