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
        DogDetailsViewmodel viewmodel = this.BindingContext as DogDetailsViewmodel;
        viewmodel.SaveDogDetailsCommand.Execute(null);
    }
}