using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class DoggiesPage : ContentPage
{

	public DoggiesPage(DoggiesViewmodel vm)
	{
		InitializeComponent();
    }


    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        DoggiesViewmodel viewmodel = this.BindingContext as DoggiesViewmodel;
        viewmodel.LoadUpDoggies();  
    }


}