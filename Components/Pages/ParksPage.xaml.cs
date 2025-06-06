using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class ParksPage : ContentPage
{


    public ParksPage(ParksViewModel parksViewModel)
    {
        InitializeComponent();

        BindingContext = parksViewModel;

        Content = parksViewModel.Map;

    }



}