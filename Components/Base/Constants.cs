namespace MyDoggyDetails.Components.Base
{
    public static class Constants
    {
        public const string DatabaseFileName = "doggy.db3";
        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);


    }
}
