namespace MyDoggyDetails.Utilities
{
    public static class Extensions
    {


       public static DateTime ToDateTime(this string str)
        {

            DateTime dt = Convert.ToDateTime(str);

            return dt;

        }

        /// <summary>
        /// Convert a nullable DateTime into a format for saving with Dapper
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDapperDateTimeFormat(this DateTime dateTime)
        {
            return ToDapperDateTimeFormat(dateTime);
        }


        /// <summary>
        /// Convert a nullable DateTime into a format for saving with Dapper
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>"NULL" or DateTime as string format "yyyy-mm-dd hh:mm:ss"</returns>
        public static string ToDapperDateTimeFormat(this DateTime? dateTime)
        {
            string dapperDate = "null";  //return "NULL" by default


            if (dateTime.HasValue)
            {
                //If it has value convert to date and then to string.
                DateTime dt = dateTime.Value;

                dapperDate = "'" +
                    dt.Year + "-" +
                    dt.Month.ToString("D").PadLeft(2, '0') + "-" +
                    dt.Day.ToString("D").PadLeft(2, '0') + " " +
                    dt.Hour.ToString().PadLeft(2, '0') + ":" +
                    dt.Minute.ToString().PadLeft(2, '0') + ":" +
                    dt.Second.ToString().PadLeft(2, '0') +
                    "'";
            }
            return dapperDate;
        }

        /// <summary>
        /// Return the String or Null for the database
        /// </summary>
        public static string AsValidatedString(this string? str)
        {

            if (str == null)
                return null;
            else
                return str.ToString();

        }

        /// <summary>
        /// Pass in the full path and return only the filename.
        /// </summary>
        /// <param name="path">c:\myfolder\myfile.txt</param>
        /// <returns>myfile.txt</returns>
        public static string GetFileNameFromPath(this string path)
        {

            try
            {

                int idx = path.LastIndexOf("\\", StringComparison.Ordinal);

            string pathOut = path.Substring(idx + 1); 

            return pathOut;
            }
            catch (Exception ex)
            {
     

                throw;
            }
            //return a substring starting from last forward slash position


        }


    }
}
