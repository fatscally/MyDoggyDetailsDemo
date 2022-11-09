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

        TimeSpan dogsAge = DateTime.Today.Subtract(DogDob.Date);

        int dogDays = dogsAge.Days;
        int dogYears = dogDays / 365;
		double dogMonths = (dogsAge.Days / (365.2425 / 12));
		int dogWeeks = (dogsAge.Days / 7);
        int dogWeekDays = dogDays - (dogWeeks*7); 

        lblDogsAge.Text = txtDogName.Text + " is " + Environment.NewLine
            + dogYears.ToString() + " years" + Environment.NewLine
            + dogMonths.ToString() + " months old"  + Environment.NewLine
            + dogWeeks.ToString() + " weeks and " + dogWeekDays.ToString() + " days old" + Environment.NewLine
            + dogsAge.TotalDays.ToString() + " days old" + Environment.NewLine;

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

