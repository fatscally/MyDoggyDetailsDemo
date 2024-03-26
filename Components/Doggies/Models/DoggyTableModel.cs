using CommunityToolkit.Mvvm.ComponentModel;


namespace MyDoggyDetails.Models;

[SQLite.Table("MyDoggies")]
[ObservableRecipient]
public partial class DoggyTableModel : BaseTableModel
{

    [ObservableProperty]
    private int breedId;
    

    [ObservableProperty]
    public string colour;

    /// <summary>
    /// Name given to the dog
    /// </summary>
    [ObservableProperty]
    private string givenName;
    /// <summary>
    /// The date of birth recorded
    /// </summary>
    [ObservableProperty]
    private string dateOfBirth;

    [ObservableProperty]
    public string chipNumber;


    //should be Genders enum but sqlite doesn't like the enum
    [ObservableProperty]
    public int sex;

    [ObservableProperty]
    private string formattedAge;
    [ObservableProperty]
    private string totalDogDays;



}
