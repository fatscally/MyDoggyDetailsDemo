using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class DogDetailsPage : ContentPage
{



    public DogDetailsPage()
    {
        InitializeComponent();
    }



    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        DoggiesViewmodel viewmodel = this.BindingContext as DoggiesViewmodel;
        viewmodel.SaveDogDetailsCommand.Execute(null);
    }
}