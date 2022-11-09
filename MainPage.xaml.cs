using MyDoggyDetails.Utilities;

namespace MyDoggyDetails;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		GetDogsAge();
	}

	private void GetDogsAge()
	{

        AgeCalculator dogCalc = new(DogDob.Date);

        lblDogsAge.Text = dogCalc.FormattedAge();

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

