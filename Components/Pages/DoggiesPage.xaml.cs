using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class DoggiesPage : ContentPage
{
    private readonly DoggyListViewModel _viewModel;
	public DoggiesPage(DoggyListViewModel doggyListViewModel)
	{

        _viewModel = doggyListViewModel;
        BindingContext = doggyListViewModel;

		InitializeComponent();

    }


    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _viewModel.LoadUpDoggiesAsync();  
    }


}