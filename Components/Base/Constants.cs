namespace MyDoggyDetails.Base
{
    public static class Constants
    {
        public const string DatabaseFileName = "doggy.db3";
        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);


        public static string RestUrlDogs = DeviceInfo.Platform == DevicePlatform.Android ? "https://dog.ceo/api/" : "https://dog.ceo/api/";


        //https://dogapi.dog/docs/api-v2
        public static string RestUrlDogApi = DeviceInfo.Platform == DevicePlatform.Android ? "https://dogapi.dog/api/v2/" : "https://dogapi.dog/api/v2/";

        public static string BreedsPhotosPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "breedImages");

        public static string MyDoggyPhotosPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "doggyImages");



    }
}
