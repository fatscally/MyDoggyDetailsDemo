namespace MyDoggyDetails.Utilities
{
    internal class Pictures
    {


        //Code copied from 
        // https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker?view=net-maui-8.0&tabs=windows
        public async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
        }


    }
}
