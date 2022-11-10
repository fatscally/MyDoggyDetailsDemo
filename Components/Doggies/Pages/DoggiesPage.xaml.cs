using MyDoggyDetails.Utilities;
using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class DoggiesPage : ContentPage
{

    
	public DoggiesPage(DoggiesViewmodel vm)
	{
		InitializeComponent();
        
        BindingContext = vm;

        GetDogsAge();
    }

    private void GetDogsAge()
    {

        AgeCalculator dogCalc = new(DogDob.Date);

        lblDogsAge.Text = dogCalc.FormattedAge();
        lblDogsAgeInDays.Text = "(" + dogCalc.TotalDogDays.ToString() + " days)";

    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        GetDogsAge();
    }

    private void DogButton_Clicked(object sender, EventArgs e)
    {
        GetDogsAge();
    }

    private void DogDob_DateSelected(object sender, DateChangedEventArgs e)
    {
        GetDogsAge();
    }





}