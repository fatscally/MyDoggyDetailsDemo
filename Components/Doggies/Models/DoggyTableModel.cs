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
    private string givenName;
    /// <summary>
    /// The date of birth recorded
    /// </summary>
    [ObservableProperty]
    private DateTime dateOfBirth;

    //[ObservableProperty] 
    //public string chipNumber;

    //[ObservableProperty] 
    //public Genders sex;

    //[ObservableProperty]
    //private string formattedAge;
    //[ObservableProperty]
    //private string totalDogDays;



}
