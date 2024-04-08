namespace MyDoggyDetails.Utilities.Pictures;

using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;


/// <summary>
/// This Pictures library will have to be interfaced for the different platforms.
/// The IImage interface in .NET MAUI provides methods for working with images, but the actual implementation of these methods depends on the platform-specific image loading services. On Windows, the image loading service used is Microsoft.Maui.Graphics.Win2D, which currently does not support the Resize method.
///
/// To resize an image on Windows in a.NET MAUI project, you can use the BitmapImage class from the System.Windows.Media.Imaging namespace, which is available in Windows desktop applications.
///
/// </summary>

public class PicturesAndroid : IDoggyPictures

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


    public async Task<byte[]> DownloadImageFromWeb(Uri uri)
    {
        byte[] byteArray = null;
        HttpClient client = new();
        Stream stream = await client.GetStreamAsync(uri).ConfigureAwait(false);


        BinaryReader reader = new BinaryReader(stream);
        byteArray = reader.ReadBytes(1470000);


        stream.Flush();
        stream.Close();
        client.Dispose();

        return byteArray;
    }

    //ANDROID: Working OK. :)  Produced about 10% smaller file over Resize for my needs.
    //WINDOWS: Using a small image DownsizeImage results in a 10x larger file! Disaster!! :(
    public byte[] DownsizeImage(byte[] imgBytes, int new_width, int new_height)
    {

        MemoryStream memory = new MemoryStream(imgBytes);


        IImage image;
        IImage newImage;
        byte[] rtnBytes = null;

        using (memory)
        {
            image = PlatformImage.FromStream(memory);
        }

        if (image != null)
        {
            newImage = image.Downsize(new_width, true);
            rtnBytes = newImage.AsBytes();
        }

        return rtnBytes;

    }


    //This function works on Android - Not on Windows - iPhone to be tested??
    public byte[] ResizeImage(byte[] imgBytes, int new_width, int new_height)
    {

        MemoryStream memory = new MemoryStream(imgBytes);


        IImage image;
        IImage newImage;
        byte[] rtnBytes = null;

        using (memory)
        {
            image = PlatformImage.FromStream(memory);
        }

        if (image != null)
        {
            newImage = image.Resize(new_width, new_height);
            rtnBytes = newImage.AsBytes();
        }

        return rtnBytes;

    }




    //public static class ImageResizer
    //{
    //    public static async Task<byte[]> ResizeImageWindows(byte[] imageData, float width, float height)
    //    {
    //        byte[] resizedData;

    //        using (var streamIn = new MemoryStream(imageData))
    //        {
    //            using (var imageStream = streamIn.AsRandomAccessStream())
    //            {
    //                var decoder = await BitmapDecoder.CreateAsync(imageStream);
    //                var resizedStream = new InMemoryRandomAccessStream();
    //                var encoder = await BitmapEncoder.CreateForTranscodingAsync(resizedStream, decoder);
    //                encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Linear;
    //                encoder.BitmapTransform.ScaledHeight = (uint)height;
    //                encoder.BitmapTransform.ScaledWidth = (uint)width;
    //                await encoder.FlushAsync();
    //                resizedStream.Seek(0);
    //                resizedData = new byte[resizedStream.Size];
    //                await resizedStream.ReadAsync(resizedData.AsBuffer(), (uint)resizedStream.Size, InputStreamOptions.None);
    //            }
    //        }

    //        return resizedData;
    //    }
    //}


}
