using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Enums;


namespace MyDoggyDetails.Models;

[SQLite.Table("MyDoggies")]
[ObservableRecipient]
public partial class DoggyModel : BaseTableModel
{

    [ObservableProperty] private string dogGuid;
    [ObservableProperty] private int breedId;
    [ObservableProperty] public string colour;

    /// <summary>
    /// Name given to the dog
    /// </summary>
    [ObservableProperty] private string givenName;
    /// <summary>
    /// The date of birth recorded
    /// </summary>
    [ObservableProperty] private string dateOfBirth;
    [ObservableProperty] public string chipNumber;
    [ObservableProperty]  private string joinedFamilyDate;


    [ObservableProperty] private Genders gender;

    [ObservableProperty] public bool sex;
    partial void OnSexChanged(bool value)
    {
        if (value)
            Gender = Genders.Male;
        else
            Gender = Genders.Female;
    }





}
