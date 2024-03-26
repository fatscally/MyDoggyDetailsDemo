using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;


namespace MyDoggyDetails.Models;

[Table("Breeds")]
public partial class BreedTableModel : BaseTableModel
{
    [ObservableProperty]
    [property: PrimaryKey]
    [property: AutoIncrement]
    private int id;

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

    //[ObservableProperty]
    //private List<DoggyTableModel> doggies;
}
