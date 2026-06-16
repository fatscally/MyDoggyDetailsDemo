using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.Base;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

[QueryProperty("DogId", "DogId")]

public partial class DogDetailViewModel : BaseViewModel
{
    private readonly IDoggyService _doggyService;
    private readonly IDoggyPhotoService _photoService;

    public DogDetailViewModel(IDoggyService doggyService, IDoggyPhotoService photoService)
    {
        _doggyService = doggyService ?? throw new ArgumentNullException(nameof(doggyService));
        _photoService = photoService ?? throw new ArgumentNullException(nameof(photoService));
    }

    [RelayCommand]
    async Task TakePhoto(string param)
    {
        if (!MediaPicker.Default.IsCaptureSupported) return;

        FileResult photo = param == "Camera"
            ? await MediaPicker.Default.CapturePhotoAsync()
            : await MediaPicker.Default.PickPhotoAsync();

        if (photo == null) return;

        Directory.CreateDirectory(Constants.MyDoggyPhotosPath);
        SelectedPhotoFilePath = Path.Combine(Constants.MyDoggyPhotosPath, photo.FileName);

        SelectedDoggyPhoto = new DoggyPhotoModel { DogGuid = SelectedDoggy.DogGuid, FileName = photo.FileName };

        if (SelectedDoggyPhotos == null)
            SelectedDoggyPhotos = new();
        SelectedDoggyPhotos.Add(SelectedDoggyPhoto);

        using Stream sourceStream = await photo.OpenReadAsync();
        using FileStream localFileStream = File.OpenWrite(SelectedPhotoFilePath);
        await sourceStream.CopyToAsync(localFileStream);
    }

    [ObservableProperty] private Image croppedImage;
    [ObservableProperty] private string datePickerMaxDate = DateTime.Today.ToString();
    [ObservableProperty] int dogId;

    partial void OnDogIdChanged(int value) => _ = LoadSelectedDoggyAsync(value);

    private async Task LoadSelectedDoggyAsync(int value)
    {
        var allDoggies = await _doggyService.GetAllDoggiesAsync();
        SelectedDoggy = allDoggies.FirstOrDefault(x => x.Id == value);
    }

    [ObservableProperty] private DoggyModel selectedDoggy;
    [ObservableProperty] private ObservableCollection<DoggyPhotoModel> selectedDoggyPhotos;
    [ObservableProperty] private DoggyPhotoModel selectedDoggyPhoto;
    [ObservableProperty] private string selectedPhotoFilePath;

    [RelayCommand]
    public async Task SaveDogDetails() => await _doggyService.SaveDoggyAsync(SelectedDoggy);

    [RelayCommand]
    public async Task SaveDoggyPhotos() => await _photoService.SaveDoggyPhotoAsync(SelectedDoggyPhoto);
}
