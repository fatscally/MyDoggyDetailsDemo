namespace MyDoggyDetails.Utilities
{
    public static class Extensions
    {
        public static DateTime ToDateTime(this string str)
            => Convert.ToDateTime(str);
    }
}
