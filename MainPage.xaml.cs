namespace MyDogsAge;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		GetDogsAge();
	}

	private void GetDogsAge()
	{

        var dogsAge = DateTime.Today.Subtract(DogDob.Date);

		double dogMonths = (dogsAge.Days / (365.2425 / 12));
		double dogWeeks = (dogsAge.Days / 7);

        lblDogsAge.Text = txtDogName.Text + " is; " + Environment.NewLine
            + dogMonths.ToString("0.0") + " months old"  + Environment.NewLine
            + dogWeeks.ToString("0.0") + " weeks old" + Environment.NewLine
            + dogsAge.TotalDays.ToString() + " days old," + Environment.NewLine;

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		GetDogsAge();
    }
}

