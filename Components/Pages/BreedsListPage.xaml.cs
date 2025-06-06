using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class BreedsListPage : ContentPage
{
	public BreedsListPage(BreedsListViewModel breedsListViewModel)
	{
		BindingContext = breedsListViewModel;
		InitializeComponent();
	}


}