using MyDoggyDetails.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MyDoggyDetails.Models;

[Table("MyDoggies")]
public partial class DoggyTableModel : BaseModel
{
    //public BreedModel Breed { get; set; }

    //[ObservableProperty]
    //public string colour;

    /// <summary>
    /// Name given to the dog
    /// </summary>
    [ObservableProperty]
    public string givenName;
    /// <summary>
    /// The date of birth recorded
    /// </summary>
    [ObservableProperty]
    public string dateOfBirth;

    //[ObservableProperty] 
    //public string chipNumber;

    //[ObservableProperty] 
    //public Genders sex;


}
