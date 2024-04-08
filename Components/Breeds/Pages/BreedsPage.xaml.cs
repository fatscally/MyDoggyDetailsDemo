using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class BreedsPage : ContentPage
{
	public BreedsPage()
	{
		InitializeComponent();
	}

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        BreedsViewmodel viewmodel = this.BindingContext as BreedsViewmodel;
        viewmodel.GoToBreedDetailsPageCommand.Execute(viewmodel.SelectedBreed.Id);
    }
}