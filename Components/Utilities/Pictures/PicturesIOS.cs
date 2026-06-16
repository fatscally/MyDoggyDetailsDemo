using Microsoft.Maui.Graphics.Platform;
using MyDoggyDetails.Interfaces;

namespace MyDoggyDetails.Utilities.Pictures;

public class PicturesIOS(IHttpClientFactory httpClientFactory) : IDoggyPictures
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory
        ?? throw new ArgumentNullException(nameof(httpClientFactory));

    public async Task<byte[]> DownloadImageFromWeb(Uri uri)
    {
        using var client = _httpClientFactory.CreateClient();
        using var stream = await client.GetStreamAsync(uri).ConfigureAwait(false);
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }

    public byte[] DownsizeImage(byte[] imgBytes, int new_width, int new_height)
    {
        using var memory = new MemoryStream(imgBytes);
        var image = PlatformImage.FromStream(memory);
        if (image == null) return null;
        return image.Downsize(new_width, true)?.AsBytes();
    }

    public byte[] ResizeImage(byte[] imgBytes, int new_width, int new_height)
    {
        using var memory = new MemoryStream(imgBytes);
        var image = PlatformImage.FromStream(memory);
        if (image == null) return null;
        return image.Resize(new_width, new_height)?.AsBytes();
    }
}
