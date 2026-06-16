using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using MyDoggyDetails.Interfaces;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace MyDoggyDetails.Utilities.Pictures;

public class PicturesAndroid(IHttpClientFactory httpClientFactory) : IDoggyPictures
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory
        ?? throw new ArgumentNullException(nameof(httpClientFactory));

    public async Task<byte[]> DownloadImageFromWeb(Uri uri)
    {
        using var client = _httpClientFactory.CreateClient();
        using var stream = await client.GetStreamAsync(uri).ConfigureAwait(false);
        using var memory = new MemoryStream();
        await stream.CopyToAsync(memory);
        return memory.ToArray();
    }

    public byte[] DownsizeImage(byte[] imgBytes, int new_width, int new_height)
    {
        using var memory = new MemoryStream(imgBytes);
        IImage image = PlatformImage.FromStream(memory);
        if (image == null) return null;
        return image.Downsize(new_width, true).AsBytes();
    }

    public byte[] ResizeImage(byte[] imgBytes, int new_width, int new_height)
    {
        using var memory = new MemoryStream(imgBytes);
        IImage image = PlatformImage.FromStream(memory);
        if (image == null) return null;
        return image.Resize(new_width, new_height).AsBytes();
    }
}
