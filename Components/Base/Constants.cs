namespace MyDoggyDetails.Base
{
    public static class Constants
    {
        public const string DatabaseFileName = "doggy.db3";
        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);

        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://pokeapi.co/api/v2/pokemon/" : "https://pokeapi.co/api/v2/pokemon/";

    }
}
