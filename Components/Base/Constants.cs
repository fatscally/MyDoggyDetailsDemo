namespace MyDoggyDetails.Base
{
    public static class Constants
    {
        public const string DatabaseFileName = "doggy.db3";
        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);

        public const string RestUrlDogs = "https://dog.ceo/api/";
        public const string RestUrlDogApi = "https://dogapi.dog/api/v2/";

        public static string BreedsPhotosPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "breedImages");
        public static string MyDoggyPhotosPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "doggyImages");
    }
}
