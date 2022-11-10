using MyDoggyDetails.Enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MyDoggyDetails.Models;

public partial class DogModel : BaseModel
{
    public BreedModel Breed { get; set; }

    [ObservableProperty]
    public string colour;

    /// <summary>
    /// Name given to the dog
    /// </summary>
    [ObservableProperty]
    public string givenName = "Bruno";
    /// <summary>
    /// The date of birth recorded
    /// </summary>
    [ObservableProperty]
    public DateTime dateOfBirth;
    
    [ObservableProperty] 
    public string chipId;

    [ObservableProperty] 
    public Genders gender;

    [ObservableProperty] 
    public byte[] photo1;

    [ObservableProperty]
    public byte[] photo2;
}
