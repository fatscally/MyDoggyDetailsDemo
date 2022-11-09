using System.Text;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MyDoggyDetails.Utilities
{
    internal class AgeCalculator
    {

        public AgeCalculator(DateTime dateOfBirth)
        {

            DateOfBirth = dateOfBirth;

        }

        private TimeSpan dogsAge;
        //private int TotalDogDays;
        private int remainderDays; //the remainder after subtracting years, months etc.

        private DateTime dob;

        public DateTime DateOfBirth
        {
            set
            {
                dob = value;
                dogsAge = DateTime.Today.Subtract(dob);
                totalDogDays = dogsAge.Days;

                CalculateAge();
                //CalcMonths();

            }
        }


        /// <returns>Returns and int for every full year</returns>
        private void CalculateAge()
        {
            years = totalDogDays / 365;
            remainderDays = totalDogDays - (years * 365);   //remove the years

            months = (int)(remainderDays / (365.2425 / 12));

            remainderDays = remainderDays - (months * 30);  //remove the months

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

        public int TotalDogDays
        {
            get { return totalDogDays; }
        }


        private int years;
        public int Years
        {
            get
            {
                return years;
            }
        }

        private int months;
        public int Months
        {
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

        public string FormattedAge()
        {
            StringBuilder sb = new StringBuilder(32);

            if (years > 0) {
                sb.Append(years.ToString());
                sb.Append(" year, ");
                if (years > 1)
                    sb.Replace("year, ", "years, ");
            }

            if (days == 0)
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

            if (days == 0)
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

    }
}
