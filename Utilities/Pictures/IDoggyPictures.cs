
namespace MyDoggyDetails.Utilities.Pictures
{
    public interface IDoggyPictures
    {
        Task<byte[]> DownloadImageFromWeb(Uri uri);
        byte[] DownsizeImage(byte[] imgBytes, int new_width, int new_height);
        byte[] ResizeImage(byte[] imgBytes, int new_width, int new_height);
        void TakePhoto();
    }
}