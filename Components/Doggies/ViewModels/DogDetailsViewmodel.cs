using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Base;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;



namespace MyDoggyDetails.ViewModels;

//passed in from MyDoggiesPage
[QueryProperty("DogId", "DogId")]



public partial class DogDetailsViewmodel : BaseViewModel
{
    [RelayCommand]
    async Task TakePhoto(string param)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {

            FileResult photo;
            if (param == "Camera")
                photo = await MediaPicker.Default.CapturePhotoAsync();
            else
                photo = await MediaPicker.Default.PickPhotoAsync();


            if (photo != null)
            {
                // save the file into local storage
                Directory.CreateDirectory(Constants.MyDoggyPhotosPath);

                SelectedPhotoFilePath = Path.Combine(Constants.MyDoggyPhotosPath, photo.FileName);

                if (SelectedDoggyPhoto == null)
                    SelectedDoggyPhoto = new();


                SelectedDoggyPhoto = new DoggyPhotoModel() { DogGuid = SelectedDoggy.DogGuid, FileName = photo.FileName };


                if (SelectedDoggyPhotos == null)
                    SelectedDoggyPhotos = new();

                SelectedDoggyPhotos.Add(SelectedDoggyPhoto);


                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(SelectedPhotoFilePath);

                await sourceStream.CopyToAsync(localFileStream);


            }
        }
    }

    [ObservableProperty]
    private Image croppedImage;

    [ObservableProperty]
    private string datePickerMaxDate = DateTime.Today.ToString();

    [ObservableProperty]
    int dogId;
    partial void OnDogIdChanged(int value)
    {
        SelectedDoggy = new DoggiesViewmodel().Doggies.FirstOrDefault(x => x.Id == value);
    }

    [ObservableProperty]
    private DoggyTableModel selectedDoggy;

    [ObservableProperty]
    private ObservableCollection<DoggyPhotoModel> selectedDoggyPhotos;
    [ObservableProperty]
    private DoggyPhotoModel selectedDoggyPhoto;

    [ObservableProperty]
    private string selectedPhotoFilePath;
    


    [RelayCommand]
    public void SaveDogDetails()
    {
        new DoggyRepository().Save(SelectedDoggy);
    }

    [RelayCommand]
    public void SaveDoggyPhotos()
    {
        new DoggyRepository().Save(SelectedDoggyPhoto);
    }
}
