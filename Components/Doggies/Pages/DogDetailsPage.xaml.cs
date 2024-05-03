using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails.Pages;

public partial class DogDetailsPage : ContentPage
{
    DogDetailsViewmodel viewmodel;

    public DogDetailsPage()
    {
        InitializeComponent();

         viewmodel = this.BindingContext as DogDetailsViewmodel;
    }


    protected async void OnClickedRectangle(object sender, EventArgs e)
    {
        //https://github.com/jbowmanp1107/ImageCropper.Maui?tab=readme-ov-file#readme

        //the ImageCropper class needs to be updated to allow custom save paths.
        //until then, a file.move is necessary.

        imageView.Source = null;

        new ImageCropper.Maui.ImageCropper()
        {
            PageTitle = "Doggy Photos",
            AspectRatioX = 1,
            AspectRatioY = 1,
            CropShape = ImageCropper.Maui.ImageCropper.CropShapeType.Rectangle,
            SelectSourceTitle = "Select source",
            TakePhotoTitle = "Take Photo",
            PhotoLibraryTitle = "Photo Library",
            CancelButtonTitle = "Cancel",
            Success = (imageFile) =>
            {
                viewmodel.SelectedPhotoFilePath = imageFile;
                
                MoveTheFile(imageFile);

                Dispatcher.Dispatch(() =>
                {
                    imageView.Source = ImageSource.FromFile(imageFile);
                });
            },
            Failure = () =>
            {
                Console.WriteLine("Error capturing an image to crop.");
            }
        }.Show(this);

    }

    private void MoveTheFile(string file)
    {

    }


    //protected async void OnClickedRectangle(object sender, EventArgs e)
    //{
    //    DogDetailsViewmodel viewmodel = this.BindingContext as DogDetailsViewmodel;
    //    viewmodel.AddImageCommand.Execute(this);
    //}



    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        viewmodel.SaveDogDetailsCommand.Execute(null);
    }


}