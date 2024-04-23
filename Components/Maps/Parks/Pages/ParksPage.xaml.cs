using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class ParksPage : ContentPage
{

    private ParksViewModel viewModel;

    public ParksPage()
    {
        InitializeComponent();

        viewModel = new ParksViewModel();
        BindingContext = viewModel;

        Content = viewModel.Map;

    }




    //void OnMapClicked(object sender, MapClickedEventArgs e)
    //{
    //    System.Diagnostics.Debug.WriteLine($"MapClick: {e.Location.Latitude}, {e.Location.Longitude}");
    //}




}