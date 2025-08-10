using Microsoft.Maui.Graphics.Platform;
using MyDoggyDetails.Interfaces;

namespace MyDoggyDetails.Utilities.Pictures;

public class PicturesIOS : IDoggyPictures
{
    public async void TakePhoto()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo != null)
            {
                // Save the file to AppDataDirectory for iOS
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);
            }
        }
    }

    public async Task<byte[]> DownloadImageFromWeb(Uri uri)
    {
        using HttpClient client = new HttpClient();
        using Stream stream = await client.GetStreamAsync(uri).ConfigureAwait(false);
        using MemoryStream memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }

    public byte[] DownsizeImage(byte[] imgBytes, int new_width, int new_height)
    {
        using MemoryStream memory = new MemoryStream(imgBytes);
        Microsoft.Maui.Graphics.IImage image = PlatformImage.FromStream(memory);
        if (image == null)
            return null;

        Microsoft.Maui.Graphics.IImage newImage = image.Downsize(new_width, true);
        return newImage?.AsBytes();
    }

    public byte[] ResizeImage(byte[] imgBytes, int new_width, int new_height)
    {
        using MemoryStream memory = new MemoryStream(imgBytes);
        Microsoft.Maui.Graphics.IImage image = PlatformImage.FromStream(memory);
        if (image == null)
            return null;

        Microsoft.Maui.Graphics.IImage newImage = image.Resize(new_width, new_height);
        return newImage?.AsBytes();
    }
}