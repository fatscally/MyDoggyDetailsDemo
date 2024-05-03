using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Enums;
using MyDoggyDetails.Utilities;
using SQLite;


namespace MyDoggyDetails.Models;

[SQLite.Table("MyDoggies")]
[ObservableRecipient]
public partial class DoggyTableModel : BaseTableModel
{

    [ObservableProperty]
    private string dogGuid;

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



    [ObservableProperty]
    private Genders gender;

    [ObservableProperty]
    public bool sex;
    partial void OnSexChanged(bool value)
    {
        if (value)
            Gender = Genders.Male;
        else
            Gender = Genders.Female;
    }

    [ObservableProperty]
    private string joinedFamilyDate;

    [Ignore]
    public string FormattedAge
    {
        get
        {
            return new AgeCalculator(DateOfBirth.ToDateTime()).FormattedAge();
        }
    }

    [Ignore]
    public string TotalDogDays
    {
        get
        {
            return new AgeCalculator(DateOfBirth.ToDateTime()).TotalDogDays.ToString();
        }
    }

    [Ignore]
    public string FormattedAgeShort
    {
        get
        {
            return new AgeCalculator(DateOfBirth.ToDateTime()).FormattedAgeShort();
        }
    }

}
