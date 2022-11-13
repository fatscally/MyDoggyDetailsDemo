using CommunityToolkit.Mvvm.ComponentModel;

namespace MyDoggyDetails.Models
{

    public partial class Doggy : DoggyTableModel
    {
        [ObservableProperty]
        private string formattedAge;
        [ObservableProperty]
        private string totalDogDays;


    }
}
