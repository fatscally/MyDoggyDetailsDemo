using System.Text;

namespace MyDoggyDetails.Utilities
{
    internal class AgeCalculator
    {

        public AgeCalculator(DateTime dateOfBirth)
        {

            DateOfBirth = dateOfBirth;

        }

        private TimeSpan tsDogsAge;
        //private int TotalDogDays;
        private int remainderDays; //the remainder after subtracting years, months etc.

        private DateTime dob;

        public DateTime DateOfBirth
        {
            set
            {
                dob = value;
                tsDogsAge = DateTime.Today.Subtract(dob);
                totalDogDays = tsDogsAge.Days;

                CalculateAge();

            }
        }


        /// <returns>Returns and int for every full year</returns>
        private void CalculateAge()
        {
            years = totalDogDays / 365;
            remainderDays = totalDogDays - (years * 365);   //remove the years

            months = (int)(remainderDays / (365.2425 / 12));

            remainderDays = (int)(remainderDays - (months * 30.25));  //remove the months

            weeks = remainderDays / 7;
            remainderDays= remainderDays - (weeks * 7);

            days = remainderDays;


        }

        //private void CalcMonths()
        //{
        //    //Remove the days for every year
        //    //remainder = TotalDogDays - (Years * 365);
        //    //months = (int)(remainder / (365.2425 / 12));
        //}


        //private void CalcWeeks()
        //{
        //    //Remove the days for every year
        //    int remainder = TotalDogDays - (Years * 365);

        //    days = remainder - (months * 30);
        //}
        //private void CalcDays()
        //{
        //    //Remove the days for every year
        //    int remainder = TotalDogDays - (Years * 365);

        //    days = remainder - (months * 30);
        //}


        private int totalDogDays;
        /// <summary>
        /// This is the number of days from dob to today converted from the timespan tsDogsAge.
        /// </summary>
        public int TotalDogDays
        {
            get { return totalDogDays; }
        }


        private int years;
        public int Years
        {
            //Note: a year has 365 days.  No leap years.
            get
            {
                return years;
            }
        }

        private int months;
        public int Months
        {
            //Note: A month has 30 days, never 28/29/31
            get
            {
                return months;
            }
        }

        private int weeks;
        public int Weeks
        {
            get
            {
                return weeks;
            }
        }

        private int days; 
        public int Days
        {
            get
            {
                return days;
            }
        }


        /// <summary>
        /// This takes the age and tries to format it into readable English text.
        /// </summary>
        /// <returns>A string like "1 year, 2 months and 4 days old."</returns>
        public string FormattedAge()
        {

            if(totalDogDays <= 0) { return string.Empty; }

            StringBuilder sb = new StringBuilder(32);

            if (years > 0) {
                sb.Append(years.ToString());
                sb.Append(" year, ");
                if (years > 1)
                    sb.Replace("year, ", "years, ");
            }

            if (sb.ToString().EndsWith(", ") && days == 0)  //if there are no days we need to remove the comma
            {
                sb.Replace(", ", " and ", sb.Length - 2, 2);
            }

            if (months > 0)
            {
                sb.Append(months.ToString());
                sb.Append(" month, ");
                if (months > 1)
                    sb.Replace("month, ", "months, ");
            }

            if (sb.ToString().EndsWith(", ") && days == 0)  //if there are no days we need to remove the  trailing comma
            {
                sb.Replace(", ", " and ", sb.Length-2,2);
            }

            if (weeks > 0) 
            {
                sb.Append(weeks.ToString());
                sb.Append(" week");
                if (weeks > 1)
                    sb.Replace("week", "weeks");
            }

            if (days > 0)
            {
                if(sb.ToString().EndsWith(", "))
                    sb.Replace(", ","",sb.Length-2,2);
                if(years>0 || months>0 || weeks>0)
                    sb.Append(" and ");
                sb.Append( days.ToString());
                sb.Append(" day ");
                if (days > 1)
                    sb.Replace("day ", "days "); 
            } 
            else
            {
                sb.Append(" ");
            }

            sb.Append("old");

            return sb.ToString();
        }

        /// <summary>
        /// This takes the age and tries to format it into readable English text.
        /// </summary>
        /// <returns>A string like "1yr, 2m."</returns>
        public string FormattedAgeShort()
        {

            if (totalDogDays <= 0) { return string.Empty; }

            StringBuilder sb = new StringBuilder(32);


                sb.Append(years.ToString());
                sb.Append("yr,");


                sb.Append(months.ToString());
                sb.Append("m.");



            return sb.ToString();
        }


    }
}
