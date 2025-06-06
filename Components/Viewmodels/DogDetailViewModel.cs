using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Base;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;



namespace MyDoggyDetails.ViewModels;

//passed in from MyDoggiesPage
[QueryProperty("DogId", "DogId")]



public partial class DogDetailViewModel : BaseViewModel
{


    private readonly IDoggyService _doggyService;
    private readonly IDoggyPhotoRepository _photoRepository;


    public DogDetailViewModel(IDoggyService doggyService, IDoggyPhotoRepository photoRepository)
    {
        _doggyService = doggyService;
        _photoRepository = photoRepository;
    }

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
        SelectedDoggy = _doggyService.GetAllDoggiesAsync().Result.FirstOrDefault(x => x.Id == value);
    }

    [ObservableProperty]
    private DoggyModel selectedDoggy;

    [ObservableProperty]
    private ObservableCollection<DoggyPhotoModel> selectedDoggyPhotos;
    [ObservableProperty]
    private DoggyPhotoModel selectedDoggyPhoto;

    [ObservableProperty]
    private string selectedPhotoFilePath;


    [RelayCommand]
    public async Task SaveDogDetails()
    {
        await _doggyService.SaveDoggyAsync(SelectedDoggy);
    }

    [RelayCommand]
    public void SaveDoggyPhotos()
    {
        _photoRepository.SaveAsync(SelectedDoggyPhoto);
    }
}
