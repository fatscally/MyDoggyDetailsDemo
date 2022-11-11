using MyDoggyDetails.Data;
using MyDoggyDetails.Utilities;
using MyDoggyDetails.ViewModels;
using System.Reflection;

namespace MyDoggyDetails.Pages;

public partial class DoggiesPage : ContentPage
{

    
	public DoggiesPage(DoggiesViewmodel vm)
	{
		InitializeComponent();
        
        MoveDbToProperPlace();


        BindingContext = vm;

        GetDogsAge();
    }

    private void MoveDbToProperPlace()
    {
        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
        using (Stream stream = assembly.GetManifestResourceStream("MyDoggyDetails.Database.doggy.db3"))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                File.WriteAllBytes(DoggyRepository.dbPath, memoryStream.ToArray());
            }
        }
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