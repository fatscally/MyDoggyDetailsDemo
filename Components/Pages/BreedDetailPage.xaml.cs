using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class BreedDetailPage : ContentPage
{
	public BreedDetailPage(BreedDetailViewModel breedDetailViewModel)
	{
        BindingContext = breedDetailViewModel;
        InitializeComponent();
	}
}