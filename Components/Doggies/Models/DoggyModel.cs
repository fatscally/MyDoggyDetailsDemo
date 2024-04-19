using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Utilities;

namespace MyDoggyDetails.Models;


public partial class DoggyModel : DoggyTableModel
{
    [ObservableProperty]
    private string formattedAge;
    [ObservableProperty]
    private string totalDogDays;






}
